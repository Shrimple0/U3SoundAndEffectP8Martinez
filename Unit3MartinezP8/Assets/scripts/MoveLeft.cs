using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLeft : MonoBehaviour
{
    // Start is called before the first frame update
    private float speed = 30;
    private PlayerController playerControllerScript;

    void Start()
    {
        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    // Update is called once per frame 
    private float leftBound = -15;
    void Update()
    {
        if (playerControllerScript.gameOver == false)
        {
            if (playerControllerScript.isDashing == true)
            {
                transform.Translate(Vector3.left * speed * Time.deltaTime * playerControllerScript.dash);
            }
            else
            {
                transform.Translate(Vector3.left * speed * Time.deltaTime);
            }
        }

    }
}