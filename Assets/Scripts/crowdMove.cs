using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class crowdMove : MonoBehaviour
{
    public float Speed=10f;
    private Transform crowdTrans;
    private Transform  playerTrans;
    private GameObject playerObj;
    // Start is called before the first frame update
    void Start()
    {
        crowdTrans = GetComponent<Transform>();
        playerObj = GameObject.FindWithTag("Cyborg");
        playerTrans = playerObj.GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        crowdTrans.position += Speed * Time.deltaTime * crowdTrans.forward;
        destroyBack(gameObject);
    }

    void destroyBack(GameObject enemy)
    {
        //Debug.Log(enemy.transform.position.z);
        if (enemy.transform.position.z < playerTrans.position.z - 10)
        {
            Destroy(enemy);
       
        }
    }
    
}
