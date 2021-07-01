using System.Collections;
using UnityEngine;

public class RayShooter : MonoBehaviour
{
    private Camera _camera;
    void Start()
    {
        _camera = GetComponent<Camera>();

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
        // Реакция на нажатие кнопки мыши
        if (Input.GetMouseButtonDown(0))
        {
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
        GameObject sphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        sphere.transform.position = position;

        // Ключевое слово yield указывает сопрограмме
        // когда следует остановиться
        yield return new WaitForSeconds(1);

        // Удаляем этот GameObject и очищаем память
        Destroy(sphere); 
    }
}
