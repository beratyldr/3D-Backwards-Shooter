using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    //Stores how long it takes to get from one tile to the other
    public float moveSpeed;
    //Where is this player trying to get to
    private Vector3 targetPos;
    void Start()
    {
        targetPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, targetPos, moveSpeed * Time.deltaTime);
    }
    public void Move(Vector3 moveDirection)
    {
        targetPos += moveDirection;
    }
}
   

