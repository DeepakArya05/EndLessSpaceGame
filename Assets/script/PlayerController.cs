using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 0f;
    Rigidbody rb;
    [SerializeField] GameObject cam;
    [SerializeField] platformSpawner ps;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        float xInput = Input.GetAxis("Horizontal");

        Vector3 dir = new Vector3(xInput, 0, 0)*moveSpeed;
        rb.velocity = dir;

    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("obstacle"))
        {
            cam.transform.parent = null;
            gameObject.SetActive(false);
            ps.enabled = false;
            //Time.timeScale = 0;
        }
        else if(other.CompareTag("boarder"))
        {
            cam.transform.parent = null;
            gameObject.SetActive(false);
            ps.enabled = false;
            //Time.timeScale = 0;
        }

    }

}
