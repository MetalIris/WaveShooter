using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Upgrade : MonoBehaviour
{
    [SerializeField] private int _price = 10;

    [SerializeField] private string _healthUpgrade;
    [SerializeField] private string _damageUpgrade;
    [SerializeField] private string _gunSpeedUpgrade;

    public Image[] emptyIconDamage;
    public Image[] emptyIconHealth;
    public Image[] emptyIconGunSpeed;
    public Sprite fillIconHealth;

    //private int _upgradeLimit = 8;

    private void Start()
    {
        IconsHealthUpdate();
        IconsDamageUpdate();
        IconsSpeedUpdate();
    }
    public void UpgradeHealth()
    {
        int count = PlayerPrefs.GetInt(_healthUpgrade);
        int coins = PlayerPrefs.GetInt("Coin");

        if(coins >= _price)
        {
            if (count < 6)
            {
                count++;
                PlayerPrefs.SetInt(_healthUpgrade, count);
                emptyIconHealth[count - 1].overrideSprite = fillIconHealth;
                PlayerPrefs.SetInt("Coin", coins - _price);
            }
        }
    }

    public void UpgradeDamage()
    {
        int count = PlayerPrefs.GetInt(_damageUpgrade);
        int coins = PlayerPrefs.GetInt("Coin");
        if (count < 6)
        {
            if(coins >= _price)
            {
                count++;
                PlayerPrefs.SetInt(_damageUpgrade, count);

                emptyIconDamage[count - 1].overrideSprite = fillIconHealth;
                PlayerPrefs.SetInt("Coin", coins - _price);
            }

        }
        
    }

    public void UpgradeGunSpeed()
    {
        int count = PlayerPrefs.GetInt(_gunSpeedUpgrade);
        int coins = PlayerPrefs.GetInt("Coin");
        if(coins >= _price)
        {
            if (count < 6)
            {
                count++;
                PlayerPrefs.SetInt(_gunSpeedUpgrade, count);

                emptyIconGunSpeed[count - 1].overrideSprite = fillIconHealth;
                PlayerPrefs.SetInt("Coin", coins - _price);
            }
        }

    }
    //===============================================================================
    public void IconsHealthUpdate()
    {
        int count = PlayerPrefs.GetInt(_healthUpgrade);

        for(int i = 0; i < count; i++)
        {
            emptyIconHealth[i].overrideSprite = fillIconHealth;
        }
    }
    public void IconsDamageUpdate()
    {
        int count = PlayerPrefs.GetInt(_damageUpgrade);

        for (int i = 0; i < count; i++)
        {
            emptyIconDamage[i].overrideSprite = fillIconHealth;
        }
    }

    public void IconsSpeedUpdate()
    {
        int count = PlayerPrefs.GetInt(_gunSpeedUpgrade);

        for (int i = 0; i < count; i++)
        {
            emptyIconGunSpeed[i].overrideSprite = fillIconHealth;
        }
    }
}

