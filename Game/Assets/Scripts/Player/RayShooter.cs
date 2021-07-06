using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayShooter : MonoBehaviour
{
    [SerializeField] private Ak47Data _ak47Data;
    [SerializeField] private Camera _camera;
    [SerializeField] private ParticleSystem _muzzleFlash;
    [SerializeField] private AudioClip _rechargeSFX;
    [SerializeField] private AudioClip _shotSFX;
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private GameObject _prefabShotSphere;
    [SerializeField] private GameObject _counterUI;
    [SerializeField] private float _fireRate = 10f;
    private float _nextFire = 0f;
    private int _storeVolume = 0;
    private int _totalCartridges = 0;

    void Start()
    {
        _storeVolume = _ak47Data.StoreVolume;
        _totalCartridges = _ak47Data.TotalCartridges;
        // Скрываем указатель мыши в центре экрана
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        _counterUI.GetComponent<CartridgeCounter>().Count(_storeVolume, _totalCartridges);
    }

    private void OnGUI()
    {
        if (PauseController.pause_bool == false)
        {
            // Небольшое смещение с учетом размера прицела
            int size = 12;
            float posX = _camera.pixelWidth / 2 - size / 4;
            float posY = _camera.pixelHeight / 2 - size / 2;
            // Отоброжаем на экране символ
            GUI.Label(new Rect(posX, posY, size, size), "*");
        }
        
    }

    void Update()
    {
        if (PauseController.pause_bool == false && (_totalCartridges > 0 || _storeVolume > 0))
        {
            Shoot();
        }
    }

    void Shoot()
    {
        // Реакция на нажатие кнопки мыши
        if (Input.GetMouseButton(0) && Time.time > _nextFire)
        {
            _nextFire = Time.time + 1f / _fireRate;
            _audioSource.PlayOneShot(_shotSFX);
            _muzzleFlash.Play();
            _storeVolume -= 1;
            _counterUI.GetComponent<CartridgeCounter>().Count(_storeVolume, _totalCartridges);

            Recharge();

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
                GameObject hitObject = hit.collider.transform.gameObject;
                ReactiveTarget target = hitObject.GetComponent<ReactiveTarget>();
                
                if (target != null)
                {
                    target.ReactToHit(25f);
                }
                else if (hitObject != null && hitObject.tag == "ForTakingDamage")
                {
                    hitObject.GetComponent<EnemyDamageParts>().ReactToHit(hitObject);
                }
                else
                {
                    // Запуск корутины в ответ на попадание
                    StartCoroutine(SphereIndicator(hit.point));
                }
            }
        }
    }

    private void Recharge()
    {
        if (_storeVolume == 0 && _totalCartridges > 0)
        {
            _nextFire = Time.time + 2f / _fireRate;
            _audioSource.PlayOneShot(_rechargeSFX); 
            _totalCartridges -= 30;
            _storeVolume = 30;
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
