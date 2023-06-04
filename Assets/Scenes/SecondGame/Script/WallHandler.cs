using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallHandler : MonoBehaviour
{
    [SerializeField] private GameObject[] wallPrefab;
    [SerializeField] private GameObject player;
    int currentPos = 0;
    private void Update()
    {
        if (((int)player.transform.position.y)%4==0 && currentPos != (int)(player.transform.position.y))
        {
            currentPos = (int)(player.transform.position.y);
            GameObject x = Instantiate(wallPrefab[Random.Range(0, 2)], new Vector3(transform.position.x,gameObject.transform.GetChild(transform.childCount-1).gameObject.transform.position.y+4,0), Quaternion.identity);
            x.transform.parent = gameObject.transform;
            Destroy(gameObject.transform.GetChild(0).gameObject);
        }
    }

}
