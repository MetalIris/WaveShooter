using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HurtManager : MonoBehaviour
{
    public int damageToGive;

    public void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            other.gameObject.GetComponent<PlayerMovement>().HurtPlayer(damageToGive);
        }
    }
}
