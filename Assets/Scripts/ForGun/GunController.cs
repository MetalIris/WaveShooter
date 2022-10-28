using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunController : MonoBehaviour
{
    public int damageToGive;//�����, ��� ����� ������ ����

    public Transform firePoint;//����� �������

    public bool isFiring; //�������� �� �������

    public BulletController bullet; //������ ���

    public float bulletSpd;//�������� ���

    public float shotCounter;//������� �������

    


    private PlayerMovement playerScript;//������ ������

    private ExpBar expBar;

    private int _upgradeCount = 0; //������� ��������

    [SerializeField] private float bulletDamping; //time between shots

    




    public int test1; //������� ��������

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
