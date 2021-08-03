using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireSystem : MonoBehaviour
{
    RaycastHit hit;
    public GameObject projectile;
    public GameObject rayPoint;
    public float GunTimer=0;
    public float FireRate = 1f;
    //public ParticleSystem MuzzleFlash;
    public float Menzil=50;
    public float lastfired;
    public GameObject playerObj;
    Transform playerTrans;

    // Start is called before the first frame update
    void Start()
    {
        playerTrans = playerObj.GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
       
        if (Time.time > GunTimer)
        {
            playerTrans = playerObj.GetComponent<Transform>();
            GameObject bullet = Instantiate(projectile, transform.position, Quaternion.identity);
            bullet.GetComponent<Rigidbody>().AddForce(-transform.forward * 10,ForceMode.Impulse);       
            GunTimer = Time.time + FireRate;
            
           
        }
    }

}
