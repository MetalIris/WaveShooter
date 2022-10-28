using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    
    //р≥г≥дбад≥
    private Rigidbody enemyRB;
    //швидк≥сть
    [SerializeField] private float moveSpeed;
    //компонент гравц€
    public PlayerMovement thePlayer;
    //позиц≥€ спавну
    private Vector3 _spawnPosition;
 
    private void Start()
    {
        _spawnPosition = transform.position;    
        enemyRB = GetComponent<Rigidbody>();
        thePlayer = FindObjectOfType<PlayerMovement>();
    }

    private void FixedUpdate()
    {
        enemyRB.velocity = (transform.forward * moveSpeed);
    }
    private void Update()
    {
        transform.LookAt(thePlayer.transform.position);
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("AttackZone"))
        {
            gameObject.tag = "Enemy";
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.GetComponent<EnemyScript>())
        {
            if(transform.position == _spawnPosition)
            {
                transform.position = new Vector3(transform.position.x + Random.Range(-3,3), transform.position.y, transform.position.z + Random.Range(-3, 3));
            }
        }
    }
}

