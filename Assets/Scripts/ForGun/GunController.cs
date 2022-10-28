using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunController : MonoBehaviour
{
    public int damageToGive;//шкода, €ка завдаЇ ворогу кул€

    public Transform firePoint;//точка стр≥льби

    public bool isFiring; //перев≥рка на стр≥льбу

    public BulletController bullet; //скрипт кул≥

    public float bulletSpd;//швидк≥сть кул≥

    public float shotCounter;//к≥льк≥сть постр≥л≥в

    


    private PlayerMovement playerScript;//скрипт гравц€

    private ExpBar expBar;

    private int _upgradeCount = 0; //к≥льк≥сть апгрейд≥в

    [SerializeField] private float bulletDamping; //time between shots

    




    public int test1; //тестове значенн€

    private void Start()
    {
        playerScript = FindObjectOfType<PlayerMovement>();
        expBar = FindObjectOfType<ExpBar>();

        DamageStatsUpdate();
        GunSpeedStatsUpdate();
    }

    private void Update()
    {       
        LevelUp();
        Shoot();
    }

    private void LevelUp()
    {
        if(_upgradeCount < 5)
        {
            if (expBar.Expfill >= 1)
            {
                expBar.Expfill = 0;
                playerScript._schoreCount = 0;
                Time.timeScale = 0;
                expBar._choosePanels.SetActive(true);
            }
        }
    }
    private void Shoot()
    {
        if (isFiring)
        {
            shotCounter -= Time.deltaTime;
            if (shotCounter <= 0)
            {
                shotCounter = bulletDamping;
                BulletController newBullet = Instantiate(bullet, firePoint.position, firePoint.rotation) as BulletController;

                newBullet.bulletSpeed = bulletSpd;
            }
        }
        else
        {
            shotCounter = 0;
        }
    }

    public void FirstLeftUpgrade()
    {
        _upgradeCount++;
        Time.timeScale = 1;
        expBar._choosePanels.SetActive(false);
        bulletDamping -= 0.05f;
    }
    public void FirstRightUpgrade()
    {
        _upgradeCount++;
        Time.timeScale = 1;
        expBar._choosePanels.SetActive(false);
        damageToGive += 1;
    }

    public void DamageStatsUpdate()
    {
        damageToGive = PlayerPrefs.GetInt("Damage") + 1;
    }
    public void GunSpeedStatsUpdate()
    {
        test1 = PlayerPrefs.GetInt("GunSpeed");
        bulletDamping = 1 - (float)test1/10;
    }
}
