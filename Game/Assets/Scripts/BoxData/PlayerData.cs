using UnityEngine;

[CreateAssetMenu(fileName = "BoxData", menuName = "BoxData/PlayerData", order = 1)]
public class PlayerData : ScriptableObject
{

    [SerializeField] private float _speed = 6f;
    [SerializeField] private float _jump_force = 300f;
    public float Jump_force => _jump_force;

    public float Speed => _speed;
}