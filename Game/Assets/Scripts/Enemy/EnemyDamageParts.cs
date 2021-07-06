using UnityEngine;

public class EnemyDamageParts : MonoBehaviour
{
    [SerializeField] private GameObject _enemyOb;
    public void ReactToHit(GameObject hitObject)
    {
        ReactiveTarget behavior = _enemyOb.GetComponent<ReactiveTarget>();

        if (behavior != null)
        {
            if (hitObject.name == "LegtUpLegForTakingDamage")
            {
                behavior.ReactToHit(15f);
            }
            else if (hitObject.name == "RighttUpLegForTakingDamage")
            {
                behavior.ReactToHit(15f);
            }
            else if (hitObject.name == "HeadForTakingDamage")
            {
                behavior.ReactToHit(100f);
            }
            else if (hitObject.name == "LeftUpLegForTakingDamage")
            {
                behavior.ReactToHit(20f);
            }
            else if (hitObject.name == "RightUpLegForTakingDamage")
            {
                behavior.ReactToHit(20f);
            }
            
        }
    }
}
