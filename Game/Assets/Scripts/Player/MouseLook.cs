using System.Collections;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    ///<summary>
    ///Структура enum, которая будет сопоставлять
    ///имена с параметрами
    ///</summary>>
    public enum RotationAxes
    {
        MouseXAndY = 0,
        MouseX = 1,
        MouseY = 2
    }
    [SerializeField]
    private RotationAxes axes = RotationAxes.MouseXAndY;
    [SerializeField]
    private float _sensitivityHorizontal = 9.0f;
    [SerializeField]
    private float _sensitivityVertical = 9.0f;
    [SerializeField]
    private float _maximumVert = 45.0f;
    [SerializeField]
    private float _minimumVert = -45.0f;
    [SerializeField]
    private float _rotationX = 0;

    void Start()
    {
        Rigidbody body = GetComponent<Rigidbody>();
        if (body != null)
        body.freezeRotation = true;
    }

    void FixedUpdate()
    {
        
        if (axes == RotationAxes.MouseX)
        {
            transform.Rotate(0, Input.GetAxis("Mouse X") * _sensitivityHorizontal, 0, Space.Self);
        }
        else if (axes == RotationAxes.MouseY)
        {
            // Поворот по вертикали
            _rotationX -= Input.GetAxis("Mouse Y") * _sensitivityVertical;
            // Фиксируем угол поворота
            _rotationX = Mathf.Clamp(_rotationX, _minimumVert, _maximumVert);

            // Сохраняем одинаковый угол поворота вокруг оси Y
            // т. е. вращение в горизонтальной плоскости отсутствует 
            float rotationY = transform.localEulerAngles.y;

            // Создаем новый вектор из сохраненых значений поворота
            // создаем новый, так как в случае преобразования эти значение
            // предназначены только для чтения
            transform.localEulerAngles = new Vector3(_rotationX, rotationY, 0);
        }
        else 
        {
            _rotationX -= Input.GetAxis("Mouse Y") * _sensitivityVertical;
            _rotationX = Mathf.Clamp(_rotationX, _minimumVert, _maximumVert);

            float delta = Input.GetAxis("Mouse X") * _sensitivityHorizontal;
            float rotationY = transform.localEulerAngles.y + delta;

            transform.localEulerAngles = new Vector3(_rotationX, rotationY, 0);
        }
    }
}
