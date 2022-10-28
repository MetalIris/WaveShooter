using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Bonus : MonoBehaviour
{
    [SerializeField] private string _bonusName;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Player")
        {
            switch (_bonusName)
            {
                case "Coin":
                    int coins = PlayerPrefs.GetInt("Coin");
                    PlayerPrefs.SetInt("Coin", coins + 1);
                    Debug.Log("1");
                    Destroy(gameObject);
                    break;
            }
        }
    }
}
