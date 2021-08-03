using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{

    private Transform bulletTrans;
    private Transform playerTrans;
    private GameObject playerObj;
    private GameObject crowdManager;
    public float range=20;
    // Start is called before the first frame update
    void Start()
    {
        bulletTrans = GetComponent<Transform>();
        playerObj = GameObject.FindWithTag("Cyborg");
        crowdManager = GameObject.FindWithTag("crowdManager");
        playerTrans = playerObj.GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
            destroyBack();
   
    }

    void destroyBack()
    {
        //Debug.Log(enemy.transform.position.z);
        if (bulletTrans!=null && playerTrans != null && bulletTrans.position.z > playerTrans.position.z + range)
        {
            Destroy(gameObject); 

        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "crowd")
        {
            crowdManager.GetComponent<CrowdManager>().enemyNumber--;
            Destroy(gameObject);
            Destroy(collision.gameObject);
            Debug.Log("destroyed");
        }
        if (collision.gameObject.tag == "end")
        {
            Destroy(gameObject);
           
        }
    }
}
