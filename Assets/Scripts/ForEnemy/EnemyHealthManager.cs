using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealthManager : MonoBehaviour
{
    [SerializeField] private GameObject _partickleDeath;
    //компонент гравця
    public PlayerMovement thePlayer;
    //дроп
    [SerializeField] private GameObject _expDrop;
    //компонент спавнеру
    WaveSpawner spawn;
    //поточне ХП
    [SerializeField] private int currentHealth;
    //ХП
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

    //метод завдання шкоди противнику
    public void HurtEnemy(int damage)
    {
        currentHealth -= damage;
    }

    //партікли-досвід-смерть
    public void Die()
    {
        Instantiate(_partickleDeath, transform.position, transform.rotation);
        Instantiate(_expDrop, transform.position, Quaternion.identity);
        Destroy(gameObject);
        //Destroy(partickleDeath,2f);

    }
}
