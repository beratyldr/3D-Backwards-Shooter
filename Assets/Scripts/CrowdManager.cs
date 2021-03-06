using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CrowdManager : MonoBehaviour
{
    public GameObject enemyObj;
    public GameObject playerObj;// The prefab to be spawned.
    public float spawnTime = 1f;            // How long between each spawn.
    private Vector3 spawnPosition;
    Transform playerTrans;
    public bool stopSpawning = false;
    public int enemyNumber = 0;
    private int enemySpawnNumber = 0;
    public float randomRx;
    public float randomRz;
    public float y;
    public int stopSpawningCount = 10;
    // Use this for initialization
    void Start()
    {
        // Call the Spawn function after a delay of the spawnTime and then continue to call after the same amount of time.
        InvokeRepeating("Spawn", spawnTime, spawnTime);
        
    }
    void Update()
    {
        if (playerObj != null)
        { 
            playerTrans = playerObj.GetComponent<Transform>();
        }
       
    }
    void Spawn()
    {

        spawnPosition.x = Random.Range(-randomRx, randomRx);
        spawnPosition.y = y;
        spawnPosition.z = Random.Range(playerTrans.position.z + 20, playerTrans.position.z + randomRz);

        GameObject a = Instantiate(enemyObj, spawnPosition, Quaternion.identity);
        a.transform.forward = -a.transform.forward;
        enemyNumber++;
        enemySpawnNumber++;

        if (enemyNumber <0)
        {
            CancelInvoke("Spawn");
            SceneManager.LoadScene("WinMenu");
            
        }
        if (enemySpawnNumber >=stopSpawningCount)
        {
           
            SceneManager.LoadScene("WinScene");
            CancelInvoke("Spawn");
        }



    }
  
}
