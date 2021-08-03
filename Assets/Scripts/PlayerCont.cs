using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerCont : MonoBehaviour
{
    private Touch touch;
    public float speedModifier;
    public float moveSpeed=2f;
    private Transform localTrans;
    // Start is called before the first frame update
    void Start()
    {
        localTrans=GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount > 0)
        {
            touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Moved)
            {

                if(localTrans.position.x >=-1 && localTrans.position.x <= 1)
                {
                    localTrans.position = new Vector3(
                    localTrans.position.x + touch.deltaPosition.x * speedModifier,
                    localTrans.position.y,
                    localTrans.position.z
                    );
                }
                else if(localTrans.position.x>1)
                {
                    localTrans.position = new Vector3(1, localTrans.position.y, localTrans.position.z);
                }
                else if (transform.position.x <-1)
                {
                    localTrans.position = new Vector3(-1, localTrans.position.y, localTrans.position.z);
                }
            }
        }
        localTrans.position += moveSpeed * Time.deltaTime * localTrans.forward;

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
        if (collision.gameObject.tag == "end")
        {
            Destroy(gameObject);
            Destroy(collision.gameObject);
            SceneManager.LoadScene("WinScene");
        }
    }
}
