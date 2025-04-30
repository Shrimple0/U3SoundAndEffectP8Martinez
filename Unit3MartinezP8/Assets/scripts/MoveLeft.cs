using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLeft : MonoBehaviour
{
    // Start is called before the first frame update
    private float speed = 30;
   
    void Start()
    {
  
    }

    // Update is called once per frame 
    private float leftBound = -15;
    void Update()
    {
        transform.Translate(Vector3.left * Time.deltaTime * speed);
    }
}
