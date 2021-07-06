using UnityEngine;

[CreateAssetMenu(fileName = "BoxData", menuName = "BoxData/PlayerData", order = 1)]
public class PlayerData : ScriptableObject
{

    [SerializeField] private float _speed = 6f;
    [SerializeField] private float _jump_force = 10f;
    [SerializeField] private float _hp = 100f;

    public float HP => _hp;
    public float Jump_force => _jump_force;

    public float Speed => _speed;
}