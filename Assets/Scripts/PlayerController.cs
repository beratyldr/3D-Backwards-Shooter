using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Vector3 fp;   //First touch position
    private Vector3 lp;   //Last touch position
    private Vector3 newPosForTrans;
    private float dragDistance;
    private Transform localTrans;//minimum distance for a swipe to be registered
    public float Speed = 10f;
    public float swipeSpeed = 0.1f;

    void Start()
    {
        dragDistance = Screen.height * 15 / 100; //dragDistance is 15% height of the screen
        localTrans = GetComponent<Transform>();
    }

    void Update()
    {   
        if (Input.touchCount == 1) // user is touching the screen with a single touch
        {
            Touch touch = Input.GetTouch(0); // get the touch
            if (touch.phase == TouchPhase.Began) //check for the first touch
            {
                fp = touch.position;
                lp = touch.position;
            }
            else if (touch.phase == TouchPhase.Moved) // update the last position based on where they moved
            {
                lp = touch.position;
                if (Mathf.Abs(lp.x - fp.x) > dragDistance || Mathf.Abs(lp.y - fp.y) > dragDistance)
                {//It's a drag
                 //check if the drag is vertical or horizontal
                    if (Mathf.Abs(lp.x - fp.x) > Mathf.Abs(lp.y - fp.y))
                    {   //If the horizontal movement is greater than the vertical movement...
                        //float xDiff = lp.x - fp.x;
                        if ((lp.x > fp.x))  //If the movement was to the right)
                        {   //Right swipe
                            newPosForTrans.x = localTrans.position.x + swipeSpeed;
                            //newPosForTrans.x.Distance(2, -2);
                            newPosForTrans.y = localTrans.position.y;
                            newPosForTrans.z = localTrans.position.z;
                            localTrans.position = newPosForTrans;
                            Debug.Log(localTrans.position.x);
                        }
                        else
                        {
                            newPosForTrans.x = localTrans.position.x - swipeSpeed;
                            newPosForTrans.y = localTrans.position.y;
                            newPosForTrans.z = localTrans.position.z;
                            localTrans.position = newPosForTrans;
                            Debug.Log(localTrans.position.x);
                        }
                    }

                }
                else
                {   //It's a tap as the drag distance is less than 20% of the screen height
                    Debug.Log("Tap");
                }
            }
            else if (touch.phase == TouchPhase.Ended) //check if the finger is removed from the screen
            {
                lp = touch.position;  //last touch position. Ommitted if you use list

                //Check if drag distance is greater than 20% of the screen height
              
            }
        }
        //localTrans.position += Speed * Time.deltaTime * localTrans.forward;
    }
}
