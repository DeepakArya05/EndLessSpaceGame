using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class platformSpawner : MonoBehaviour
{
    public float moveSpeed=0f;
    [SerializeField] GameObject trackPrefab;
    float distanceOfDeletion = -1000f;

    private void Update()
    {
        gameObject.transform.Translate(-Vector3.forward * moveSpeed * Time.deltaTime);
        if(gameObject.transform.position.z<= distanceOfDeletion)
        {
            Destroy(gameObject.transform.GetChild(0).gameObject);
            distanceOfDeletion = distanceOfDeletion - 1000f;
            GameObject temp = Instantiate(trackPrefab, Vector3.zero, Quaternion.identity);
            temp.transform.position = new Vector3(0, 0, gameObject.transform.GetChild(gameObject.transform.childCount - 1).transform.position.z + 1000f);
            temp.transform.parent = gameObject.transform;
        }
    }

}
