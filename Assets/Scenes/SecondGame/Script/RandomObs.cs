using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomObs : MonoBehaviour
{
    [SerializeField] private playerController pc;
    [SerializeField] private GameObject obsPrefab;
    [SerializeField] private Transform[] spawnPoints;

    private float timer = 6f;

    private void Start()
    {
        timer = Random.Range(3, 8);
    }

    private void Update()
    {
        transform.Translate(Vector3.up * Time.deltaTime * pc.moveSpeed);
        if(timer<=0)
        {
            Instantiate(obsPrefab, spawnPoints[Random.Range(0, spawnPoints.Length)].position, Quaternion.identity);
            timer = Random.Range(3, 8);                                                           
        }
        else
        {
            timer -= Time.deltaTime;
        }
    }

}
