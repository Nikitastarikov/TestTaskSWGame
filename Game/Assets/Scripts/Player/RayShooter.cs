using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayShooter : MonoBehaviour
{
    [SerializeField] private Camera _camera;
    [SerializeField] private Transform _bulletSpawn;
    [SerializeField] private ParticleSystem _muzzleFlash;
    [SerializeField] private AudioClip _shotSFX;
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private GameObject _prefabShotSphere;

    void Start()
    {
        // Скрываем указатель мыши в центре экрана
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void OnGUI()
    {
        // Небольшое смещение с учетом размера прицела
        int size = 12;
        float posX = _camera.pixelWidth / 2 - size / 4;
        float posY = _camera.pixelHeight / 2 - size / 2;
        // Отоброжаем на экране символ
        GUI.Label(new Rect(posX, posY, size, size), "*");
    }

    void Update()
    {
        Shoot();
    }

    void Shoot()
    {
        // Реакция на нажатие кнопки мыши
        if (Input.GetMouseButtonDown(0))
        {
            _audioSource.PlayOneShot(_shotSFX);
            _muzzleFlash.Play();

            // Середина экрана это половина его высоты
            // и половина его ширины
            Vector3 point = new Vector3(_camera.pixelWidth / 2, _camera.pixelHeight / 2, 0);
            // Создания луча в точке, середины экрана
            Ray ray = _camera.ScreenPointToRay(point);
            RaycastHit hit;
            // Испущенный луч заполняет информацией переменную,
            // на которую имеется ссылка
            if (Physics.Raycast(ray, out hit))
            {
                // Получаем объект, в который попал луч
                GameObject hitObject = hit.transform.gameObject;
                ReactiveTarget target = hitObject.GetComponent<ReactiveTarget>();

                if (target != null)
                {
                    Debug.Log("Hit to " + target.name);
                    target.ReactToHit();
                }
                else
                {
                    // Запуск корутины в ответ на попадание
                    StartCoroutine(SphereIndicator(hit.point));
                }
            }
        }
    }

    private IEnumerator SphereIndicator(Vector3 position)
    {
        GameObject sphere = Instantiate(_prefabShotSphere) as GameObject;//GameObject.CreatePrimitive(PrimitiveType.Sphere);
        sphere.transform.position = position;

        // Ключевое слово yield указывает сопрограмме
        // когда следует остановиться
        yield return new WaitForSeconds(1);

        // Удаляем этот GameObject и очищаем память
        Destroy(sphere); 
    }
}
