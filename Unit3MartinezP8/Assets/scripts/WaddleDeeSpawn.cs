using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaddleDeeSpawn : MonoBehaviour
{
    public GameObject[] WaddleDeePrefab;
    private Vector3 spawnPos = new Vector3(8, 2, 0);
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
            int obstacleIndex = Random.Range(0, WaddleDeePrefab.Length);
            Vector3 SpawnManager = spawnPos;
            Instantiate(WaddleDeePrefab[obstacleIndex], spawnPos, WaddleDeePrefab[obstacleIndex].transform.rotation);
        }
    }
}