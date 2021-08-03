using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwipeDetection : MonoBehaviour
{
    public Player player;
    private Vector2 startPos;
    public int pixelDistToDetect = 50;
    private bool fingerDown;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       
            if (fingerDown == false && Input.touchCount > 0 && Input.touches[0].phase == TouchPhase.Moved)
            {
                // If so, we're going to set the startPos to the first touch's position, 
                startPos = Input.touches[0].deltaPosition;
            // ... and set fingerDown to true to start checking the direction of the swipe.
                 Debug.Log("basildi");
                fingerDown = true;
            }
        if (fingerDown)
        {
             if (Input.touches[0].deltaPosition.x <= startPos.x - pixelDistToDetect)
            {
                fingerDown = false;
                //Move left
                player.Move(Vector3.left);
            }
            //Did we swipe right?
            else if (Input.touches[0].deltaPosition.x >= startPos.x + pixelDistToDetect)
            {
                fingerDown = false;
                //Move right
                player.Move(Vector3.right);
            }
        }
    }
}
