using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ExpBar : MonoBehaviour
{
    [SerializeField] private Image bar;
    public float Expfill;


    public GameObject _choosePanels;
    void Start()
    {
        Expfill = 0f;
    }

    void Update()
    {
        bar.fillAmount = Expfill;
    }
}
