using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinSpawn : MonoBehaviour
{
    [SerializeField] private float Xsize;
    [SerializeField] private float Zsize;

    [SerializeField] private GameObject _coin;
    [SerializeField] private Vector3 _curPos;
    [SerializeField] private GameObject _curCoin;

    void AddNewCoin()
    {
        RandomPos();
        _curCoin = GameObject.Instantiate(_coin,_curPos,Quaternion.identity) as GameObject;
    }

    void RandomPos()
    {
        _curPos = new Vector3(Random.Range(Xsize * -1, Xsize), 0.25f, Random.Range(Zsize * -1, Zsize));
    }

    private void Update()
    {
        if(!_curCoin)
        {
            AddNewCoin();
        }
        else
        {
            return;
        }    
    }
}
