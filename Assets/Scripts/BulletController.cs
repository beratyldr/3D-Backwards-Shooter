using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{

    private Transform bulletTrans;
    private Transform playerTrans;
    private GameObject playerObj;
    // Start is called before the first frame update
    void Start()
    {
        bulletTrans = GetComponent<Transform>();
        playerObj = GameObject.FindWithTag("Cyborg");
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
        if (bulletTrans.position.z > playerTrans.position.z + 20)
        {
            Destroy(gameObject); 

        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "crowd")
        {
            Destroy(gameObject);
            Destroy(collision.gameObject);
            Debug.Log("destroyed");
        }
        
    }
}
