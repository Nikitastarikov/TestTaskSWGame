using System.Collections;
using UnityEngine;

public class ReactiveTarget : MonoBehaviour
{
    public void ReactToHit(float damage)
    {
        WanderingAI behavior = GetComponent<WanderingAI>();
        if (behavior != null)
        {
            Debug.Log("damage = " + damage);
            behavior.Damage = damage;
            behavior.HP -= damage;
            if (behavior.HP <= 0)
            {
                //Debug.Log("Убив");
                behavior.SetAlive(false);
                StartCoroutine(Die());
            }    
        }
    }

    /// <summary>
    /// Опрокидывание врага и его уничтожение
    /// </summary>
    private IEnumerator Die()
    { 
        yield return new WaitForSeconds(2.5f);

        Destroy(this.gameObject);
    }
}
