using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    public float bulletSpeed;//�������� ���

    public Rigidbody rb;//�� ��'����

    [SerializeField] private float acceleration;//����������� ���

    public GameObject fireTarget;//���� ��� �������  

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
            //������ ���������� � �������� �� �����
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
