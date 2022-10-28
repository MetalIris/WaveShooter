using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExpPickUp : MonoBehaviour

{
    public GameObject _playerGetSchore;
    private PlayerMovement playerScript;
    private ExpBar healthBar;



    private void Start()
    {
        playerScript = FindObjectOfType<PlayerMovement>();
        healthBar = FindObjectOfType<ExpBar>();
    }
    private void OnTriggerEnter(Collider other)
    {
        {
            if (other.gameObject.CompareTag("Player"))
            {
                healthBar.Expfill += 0.25f;
                playerScript._schoreCount++;
                Destroy(gameObject);

            }
        }
    }

}
