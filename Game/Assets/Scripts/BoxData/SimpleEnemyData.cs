using UnityEngine;

[CreateAssetMenu(fileName = "BoxData", menuName = "BoxData/SimpleEnemyData", order = 1)]
public class SimpleEnemyData : ScriptableObject
{

    [SerializeField] private float _hp = 30f;
    [SerializeField] private float _speed = 300f;
    [SerializeField] private float _damage = 10f;

    public float HP => _hp;
    public float Speed => _speed;
    public float Damage => _damage;

}