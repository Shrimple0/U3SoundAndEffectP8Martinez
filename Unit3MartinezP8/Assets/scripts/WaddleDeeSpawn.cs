using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaddleDeeSpawn : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject WaddleDeePrefab;
    private Vector3 spawnPos = new Vector3(15, 1, 0);
    private float startDelay = 2;
    private float repeatRate = 2;
    private PlayerController playerControllerScript;
    void Start()
    {
        InvokeRepeating("SpawnObstacle", startDelay, repeatRate);
        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    void SpawnObstacle()
    {
        if (playerControllerScript.gameOver == false)
        {
            Instantiate(WaddleDeePrefab, spawnPos, WaddleDeePrefab.transform.rotation);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
