using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{

    [SerializeField] private Image bar;
    public float Healthfill;
    private int healthAmount;

    void Start()
    {
        Healthfill = 1f;
        Healthfill = healthAmount;
    }

    void Update()
    {
        bar.fillAmount = Healthfill;
    }
}
