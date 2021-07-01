using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
[AddComponentMenu("Control Script/FPS Input")]
public class FPSInput : MonoBehaviour
{
    [SerializeField] private PlayerData PlayerDataOb;
    [SerializeField] private float _gravity = -9.8f;
    private float _jSpeed;
    private CharacterController _charController;

    void Start()
    {
        _charController = GetComponent<CharacterController>();
    }

    private void Update()
    {
        float deltaX = Input.GetAxis("Horizontal") * PlayerDataOb.Speed;
        float deltaZ = Input.GetAxis("Vertical") * PlayerDataOb.Speed;

        if (_charController.isGrounded)
        {
            _jSpeed = 0f;
            if (Input.GetKeyDown(KeyCode.Space))
            {
                _jSpeed = PlayerDataOb.Jump_force;
            }
        }
        _jSpeed += _gravity * Time.deltaTime * 3;
        Vector3 movement = new Vector3(deltaX, _jSpeed, deltaZ); ;
        // Ограничим движение по диагонали той же скоростью, что
        // и движение параллельно осям, это нужно чтобы перс двигался
        // по диагонали с той же скоростью, что и по прямой
        movement = Vector3.ClampMagnitude(movement, PlayerDataOb.Speed);

        movement *= Time.deltaTime;
        // Преобразуем вектор движения от локальных к глобальным координатам
        movement = transform.TransformDirection(movement);
        _charController.Move(movement);
    }
}
