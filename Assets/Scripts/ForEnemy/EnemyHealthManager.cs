using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealthManager : MonoBehaviour
{
    [SerializeField] private GameObject _partickleDeath;
    //��������� ������
    public PlayerMovement thePlayer;
    //����
    [SerializeField] private GameObject _expDrop;
    //��������� ��������
    WaveSpawner spawn;
    //������� ��
    [SerializeField] private int currentHealth;
    //��
    public int Health;

    private void Start()
    {
        currentHealth = Health;

        thePlayer = FindObjectOfType<PlayerMovement>();

        spawn = thePlayer.GetComponentInChildren<WaveSpawner>();
    }

    private void Update()
    {
        if(currentHealth <= 0)
        {
            
            spawn.enemiesKilled++;
            Die();
        }
    }

    //����� �������� ����� ����������
    public void HurtEnemy(int damage)
    {
        currentHealth -= damage;
    }

    //�������-�����-������
    public void Die()
    {
        Instantiate(_partickleDeath, transform.position, transform.rotation);
        Instantiate(_expDrop, transform.position, Quaternion.identity);
        Destroy(gameObject);
        //Destroy(partickleDeath,2f);

    }
}
