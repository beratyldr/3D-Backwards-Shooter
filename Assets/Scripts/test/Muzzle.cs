using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Muzzle : MonoBehaviour
{
    RaycastHit hit;
    public GameObject bullet;
    public GameObject RayPoint;
    public float menzil=50f;
    public float fireSpeed=10f;
    
    
    Vector3 newPosForTrans;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("Fire", 0f, 1f);
        RayPoint.GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

   
    void Fire()
    {
          
            GameObject newBullet=Instantiate(bullet, RayPoint.transform.position, Quaternion.identity);
            newBullet.transform.position += fireSpeed * Time.deltaTime * transform.forward;
        if (Physics.Raycast(RayPoint.transform.position,-RayPoint.transform.forward, out hit, menzil))
        {

            
            if (hit.transform.tag == "crowd")
            {
                Debug.Log("çarpýþma");
                Destroy(hit.transform.gameObject);
            }
        }

    }
}
