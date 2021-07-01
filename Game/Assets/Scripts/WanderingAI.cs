using System.Collections;
using UnityEngine;

public class WanderingAI : MonoBehaviour
{
    [SerializeField]
    private float speed = 3.0f;
    /// <summary>
    /// Расстояние, с которого начинается реакция на препятствие
    /// </summary>
    [SerializeField]
    private float obstacleRange = 5.0f;
    [SerializeField]
    private GameObject _firemallPrefab;
    private GameObject _fireball;
    private bool _alive;

    private void Start()
    {
        _alive = true;
    }

    private void FixedUpdate()
    {
        if (_alive)
        {
            // Непрерывное движение в каждом кадре
            transform.Translate(0, 0, speed * Time.deltaTime);

            // Луч находится в том же положение и нацеливается
            // в том же направлении, что и персонаж
            Ray ray = new Ray(transform.position, transform.forward);
            RaycastHit hit;
            if (Physics.SphereCast(ray, 0.75f, out hit))
            {
                GameObject hitObject = hit.transform.gameObject;
                if (hitObject.GetComponent<PlayerCharacter>())
                {
                    if (_fireball == null)
                    {
                        _fireball = Instantiate(_firemallPrefab) as GameObject;
                        _fireball.transform.position = transform.TransformPoint(Vector3.forward * 1.5f);
                        _fireball.transform.rotation = transform.rotation;
                    }
                }
                else if (hit.distance < obstacleRange)
                {
                    // Поворот с наполовину случайным выбором нового направления
                    float angle = Random.Range(-110, 110);
                    transform.Rotate(0, angle, 0);
                }
            }
        }
    }

    public void SetAlive(bool alive)
    {
        _alive = alive;
    }
}
