using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class obstacleHandler : MonoBehaviour
{
    [SerializeField] GameObject obstaclePrefab;
    // Start is called before the first frame update
    void Start()
    {
        for(int i=0;i<Random.Range(10,20); i++)
        {
            GameObject temp = Instantiate(obstaclePrefab, new Vector3(Random.Range(-150, 150), 30, Random.Range(transform.position.z - 500, transform.position.z + 500)), Quaternion.identity);
            temp.transform.parent = gameObject.transform;

        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
