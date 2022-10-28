using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowScript : MonoBehaviour
{
    [SerializeField] private Transform objToFollow; //об'Їкт, за €ким сл≥дкуЇ камера

    private Vector3 deltaPos;// р≥зниц€ по вектор3 м≥ж двома об'Їктами

    [SerializeField]
    float leftLimit;
    [SerializeField]
    float rightLimit;
    [SerializeField]
    float bottomLimit;
    [SerializeField]
    float topLimit;

    private void Start()
    {
        deltaPos = transform.position - objToFollow.position;
    }

    private void Update()
    {
        transform.position = objToFollow.position + deltaPos;

        transform.position = new Vector3(Mathf.Clamp(transform.position.x, leftLimit, rightLimit),  transform.position.y, Mathf.Clamp(transform.position.z, bottomLimit, topLimit));
    }
}
