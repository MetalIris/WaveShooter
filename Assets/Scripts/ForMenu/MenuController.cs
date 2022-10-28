using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class MenuController : MonoBehaviour
{
    [SerializeField] private GameObject InGameMenu;
    [SerializeField] private GameObject InGame;
    [SerializeField] private GameObject PlayableComponents;

    [SerializeField] private TextMeshProUGUI _coinCountInGame;
    [SerializeField] private TextMeshProUGUI _coinCountInMenu;

    private int _healthUp;

    private void Awake()
    {
        _coinCountInGame.text = PlayerPrefs.GetInt("Coin").ToString();
        _coinCountInMenu.text = PlayerPrefs.GetInt("Coin").ToString();
    }
    private void Update()
    {
        GetCoins();
    }
    public void StartGame()
    {
        InGame.SetActive(true);
        InGameMenu.SetActive(false);
        PlayableComponents.SetActive(true);

    }
    public void ExitGame()
    {
        Application.Quit();
    }


    public void GetCoins()
    {
        _coinCountInGame.text = PlayerPrefs.GetInt("Coin").ToString();
        _coinCountInMenu.text = PlayerPrefs.GetInt("Coin").ToString();
    }
}
