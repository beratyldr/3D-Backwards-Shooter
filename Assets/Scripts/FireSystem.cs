using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireSystem : MonoBehaviour
{
    public GameObject projectile;
    public GameObject rayPoint;
    public float GunTimer=0;
    public float FireRate = 1f;
    public float lastfired;

    // Start is called before the first frame update
    void Start()
    {
        rayPoint.GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
       
        if (Time.time > GunTimer)
        {
            GameObject bullet = Instantiate(projectile, rayPoint.transform.position, Quaternion.identity);
            bullet.transform.rotation = Quaternion.Euler(90, 90, 0);
            bullet.GetComponent<Rigidbody>().AddForce(-rayPoint.transform.forward * 10,ForceMode.Impulse);
            
            GunTimer = Time.time + FireRate;
            
           
        }
    }

}
