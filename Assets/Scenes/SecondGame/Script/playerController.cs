using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class playerController : MonoBehaviour
{


    [SerializeField] internal float moveSpeed;
    [SerializeField] private GameObject timerTextParent;
    
    [SerializeField] private ParticleSystem playerBurstEffect;

    internal static bool left = false;
    internal static bool right = false;

    private bool startTimer = false;
    private float timer = 5f;
    private bool hasRun = false;
    // Start is called before the first frame update
    void Start()
    {
        startTimer = true;
        //playerBurstEffect = gameObject.GetComponent<ParticleSystem>();
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.up * Time.deltaTime * moveSpeed);
        
        if(left && transform.position.x>=-1.5f)
        {
            transform.Translate(-Vector3.right * Time.deltaTime * moveSpeed);
        }
        else if (right && transform.position.x <= 1.5f)
        {
            transform.Translate(Vector3.right * Time.deltaTime * moveSpeed);
        }

        if(startTimer)
        {
            timer -= Time.deltaTime;
            timerTextParent.transform.GetChild(0).gameObject.GetComponent<TextMeshProUGUI>().text = ((int)timer).ToString();
        }
        if(timer<=0)
        {
             gameObject.GetComponent<MeshRenderer>().enabled = false;
             moveSpeed = 0;
             startTimer = false;
           // playerBurstEffect.Play();
            if (!hasRun)
            {
                playerBurstEffect.Play();
                hasRun = true;
            }
            playerBurstEffect = null;
            //gameObject.SetActive(false);
            
            Invoke("GameOver", 2.5f);
            //StartCoroutine(destroyWait());
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("triggerEnter");
        if (other.gameObject.tag == "Enemy")
        {
            gameObject.GetComponent<MeshRenderer>().enabled = false;
            moveSpeed = 0;

            playerBurstEffect.Play();   
            playerBurstEffect = null;
            Invoke("GameOver", 2.5f);
            //StartCoroutine(destroyWait());
            
        }
    }

   

    /*IEnumerator destroyWait()
    {
        gameObject.GetComponent<MeshRenderer>().enabled = false;
        moveSpeed = 0;
        startTimer = false;
        playerBurstEffect.Play();
        playerBurstEffect = null;

        yield return new WaitForSeconds(2.5f);

        
        GameOver();
        //gameObject.GetComponent<MeshRenderer>().enabled = false;
        //moveSpeed = 0;
    }*/

    private void OnTriggerExit(Collider other)
    {
        Debug.Log("triggerExit");
        if(other.gameObject.tag=="blueWall")
        {
            startTimer = true;
            timer = 5f;
            timerTextParent.SetActive(true);
        }
    }

    private void GameOver()
    {
        SceneManager.LoadScene(2);
        hasRun = false;
    }


}
