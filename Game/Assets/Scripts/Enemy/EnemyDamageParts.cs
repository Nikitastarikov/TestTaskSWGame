using UnityEngine;

public class EnemyDamageParts : MonoBehaviour
{
    [SerializeField] private GameObject _enemyOb;
    public void ReactToHit(float damage)
    {
        ReactiveTarget behavior = _enemyOb.GetComponent<ReactiveTarget>();
        if (behavior != null)
        {
            behavior.ReactToHit(damage);
        }
    }
}
