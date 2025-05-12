using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody playerRb;
    public float jumpForce;
    public float gravityModifier;
    public AudioClip jumpSound;
    public AudioClip crashSound;
    private AudioSource playerAudio;
    public bool canDoubleJump = false;
    public float dash = 2;
    public bool isDashing = false;
    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        Physics.gravity *= gravityModifier;
        playerAudio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    public bool isOnGround = true;
    public ParticleSystem dirtParticle;
    public int jumpCount = 0;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isOnGround && !gameOver && jumpCount < 2)
        {
            playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isOnGround = false;
            dirtParticle.Stop();
            playerAudio.PlayOneShot(jumpSound, 1f);
            jumpCount += 1;
        }
        JumpCountCheck();
    }
    
        private void JumpCountCheck()
    {
        if (jumpCount >= 2)
        {
            isOnGround = false;
            jumpCount = 0;
        }
        else if (jumpCount == 1 && !gameOver)
        {
            isOnGround = true;
        }

        // Dash  with the B Key
        if (Input.GetKeyDown(KeyCode.B))
        {
            isDashing = true;
        }
        if (Input.GetKeyUp(KeyCode.B))
        {
            isDashing = false;
        }

    }
    public bool gameOver = false;
    public ParticleSystem explosionParticle;
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isOnGround = true;
            dirtParticle.Play();
        }
        else if (collision.gameObject.CompareTag("Obstacle"))
        {
            gameOver = true;
            Debug.Log("You Suck!");
            explosionParticle.Play();
            dirtParticle.Stop();
            playerAudio.PlayOneShot(crashSound, 1.0f);
        }
    }
}
