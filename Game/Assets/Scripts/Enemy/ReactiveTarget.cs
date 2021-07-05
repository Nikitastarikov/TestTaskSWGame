using System.Collections;
using UnityEngine;

public class ReactiveTarget : MonoBehaviour
{
    /// <summary>
    /// Метод, вызванный сценарием стрельбы
    /// </summary>
    public void ReactToHit()
    {
        WanderingAI behavior = GetComponent<WanderingAI>();
        if (behavior != null)
        {
            behavior.Damage = 25f;
            if (behavior.HP <= 0)
            {
                Debug.Log("Убив");
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
