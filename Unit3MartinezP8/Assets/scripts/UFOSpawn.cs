using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UFOSpawn : MonoBehaviour
{
    public GameObject[] UFOPrefab;
    private Vector3 spawnPos = new Vector3(20, 9, 0);
    private float startDelay = 1.0f;
    private float repeatRate = 1.5f;
    private PlayerController playerControllerScript;

    // Start is called before the first frame update
    void Start()
    {
        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();
        InvokeRepeating("SpawnObstacle", startDelay, repeatRate);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void SpawnObstacle()
    {
        if (playerControllerScript.gameOver == false)
        {
            int obstacleIndex = Random.Range(0, UFOPrefab.Length);
            Vector3 SpawnManager = spawnPos;
            Instantiate(UFOPrefab[obstacleIndex], spawnPos, UFOPrefab[obstacleIndex].transform.rotation);
        }
    }
}
