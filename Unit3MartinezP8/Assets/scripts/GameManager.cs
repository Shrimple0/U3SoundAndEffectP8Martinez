using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public float speed = 30f;
    private int score = 0;
    public bool IsDashing { get; set; } = false;
    public bool GameOver { get; set; } = false;
    public float Speed
    {
        get => IsDashing ? speed * 2 : speed;
    }

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating(nameof(IncreaseScore), 1f, 1f);
    }

    void IncreaseScore()
    {
        if (!GameOver)
        {
            if (IsDashing)
            {
                score += 2;
            }
            else
            {
                score++;
            }

            Debug.Log(score);
        }
    }
}