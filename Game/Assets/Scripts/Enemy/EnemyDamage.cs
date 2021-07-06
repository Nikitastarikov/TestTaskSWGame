using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == ("Player"))
        {
            //Debug.Log("damage");
            other.GetComponent<HPController>().HP -= 10;
        }
    }
}
