using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    public float bulletSpeed;//швидкість кулі

    public Rigidbody rb;//рб об'єкта

    [SerializeField] private float acceleration;//прискорення кулі

    public GameObject fireTarget;//ціль для стрільби  

    private GunController gunControlScript;

    private int damageGive;

    private void Start()
    {
        gunControlScript = FindObjectOfType<GunController>();
        damageGive = gunControlScript.damageToGive;

        rb = GetComponent<Rigidbody>();
        Destroy(gameObject,2);
    }
    private void Update()
    {
        fireTarget = GameObject.FindGameObjectWithTag("Enemy");

        if(fireTarget)
        {
            rb.AddForce(transform.forward * acceleration);

            transform.position = Vector3.MoveTowards(transform.position, fireTarget.transform.position, bulletSpeed);
            //знайти противника і рухатись до нього
            //transform.Translate(Vector3.forward * bulletSpeed * Time.deltaTime);
        }
        else
        {
            transform.Translate(Vector3.forward * bulletSpeed);
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag(("Enemy")))
        {
            other.gameObject.GetComponent<EnemyHealthManager>().HurtEnemy(damageGive);
            Destroy(gameObject);
        }
    }

    
}
