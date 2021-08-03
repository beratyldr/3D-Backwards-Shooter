using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine;

public class RunAndMove : MonoBehaviour
{
    private Rigidbody rb;
    private Transform localTrans;
    private Vector3 lastMousePos;
    private Vector3 mousePos; 
    private Vector3 newPosForTrans;
    public float Speed = 10f;
    public float swipeSpeed = 2f;
    public Camera m_MainCam;
    // Start is called before the first frame update
    void Start()
    {
        localTrans = GetComponent<Transform>();

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0)) { 
            mousePos = m_MainCam.ScreenToViewportPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y,10f));
            
            float xDiff = mousePos.x - lastMousePos.x;
           
            newPosForTrans.x = localTrans.position.x + xDiff * swipeSpeed;
            //newPosForTrans.y = localTrans.position.y;
            newPosForTrans.z = localTrans.position.z;

            localTrans.position = newPosForTrans;
            lastMousePos = mousePos;
            
        }

        localTrans.position += Speed * Time.deltaTime * localTrans.forward;


    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "crowd")
        {
            Destroy(gameObject);
            Destroy(collision.gameObject);
            Debug.Log("Your Death");
            SceneManager.LoadScene("LoseMenu");
        }

    }
}
