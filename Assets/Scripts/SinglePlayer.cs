using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class SinglePlayer : MonoBehaviour
{
    public Transform myPosition;
    public Rigidbody2D myPhysics;
    public BoxCollider2D myBoundaries;
    public GameObject pong;
    public Transform pongPosition;
    public Rigidbody2D pongPhysics;
    public BoxCollider2D pongBoundaries;
    
    public ParticleSystem particles;
    public AudioSource musicSource;
    public AudioSource sfxSource;

    public BoxCollider2D floorBoundaries;

    public TextMeshProUGUI scoreText;

    public int jumpForce = 30000;
    public bool isGrounded = false;
    public int scoreNumber = 0;
    public int checkNumber = 0;
    public int highScoreNumber = 0;
    public int challengesFaced = 0;
    public float playerSpeed = 0.1f;


    void Start()
    {
        jumpForce = 30000;
        isGrounded = false;
        scoreNumber = 0;
        checkNumber = 0;
        highScoreNumber = 0;
        challengesFaced = 0;
        playerSpeed = 0.1f;
        setScore(scoreNumber);
        zeroForces(myPhysics);
        zeroForces(pongPhysics);
    }


    void Update()
    {
        setScore(scoreNumber);
        if (scoreNumber % 5.0f == 0 && scoreNumber!=checkNumber) //If score number is an multiple of 5
        {
            RandomChallenge(scoreNumber);
            checkNumber = scoreNumber;
        }

        if ((Input.GetKeyDown("space") || Input.GetKeyDown("up")) && isGrounded)
        {
            zeroForces(myPhysics);
            myPhysics.AddForce(new Vector2(0, jumpForce));
        }
        if (Input.GetKey("left"))
        {
            myPosition.Translate(new Vector3(-playerSpeed, 0, 0));
            myPosition.Rotate(new Vector3(0, 0, 0));
        }
        if (Input.GetKey("right"))
        {
            myPosition.Translate(new Vector3(playerSpeed, 0, 0));
            myPosition.Rotate(new Vector3(0, 0, 0));
        }
    }

    
    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.name == "Floor")
        {
            isGrounded = false;
        }
    }

    private void OnCollisionEnter2D (Collision2D other)
    {
        if (other.gameObject.name == "Pong")
        {
            pong.GetComponent<PongSingle>().Throw();
            if (isGrounded)
            {
                addScore(1);
            }
            else if (!isGrounded)
            {
                addScore(2);
            }
            else
            {
                Debug.Log("Scoring Error");
            }
        }

        if (other.gameObject.name == "Floor")
        {
            isGrounded = true;
        }
    }


    void setScore(int number)
    {
        scoreText.text = number.ToString();
    }
    void addScore(int number)
    {
        scoreNumber = scoreNumber + number;
    }
    void zeroForces(Rigidbody2D physicsObject)
    {
        physicsObject.AddForce(Vector2.zero);
    }
    
    /* private void Throw()
    {
        pongPhysics.AddForce(new Vector3(Random.Range(-200, 200), 250, 0));
    }*/

    void RandomChallenge(int scoreNumber)
    {
        double difficulty = Mathf.Sqrt(scoreNumber) / 2;
        SpeedUpScene();
        switch (difficulty)
        {
            case 1:
                break;
            case 2:
                break;
            case 3:
                break;
        }
    }

    void PlayerSlowDown()
    {
        playerSpeed *= 0.5f;
        Debug.Log("Slowdown!");
    }

    void ReversePlayerSlowDown()
    {
        playerSpeed *= 2;
        Debug.Log("Player Speed Normalized!");
    }

    void SpeedUpScene()
    {
        playerSpeed *= 2;
        pong.GetComponent<PongSingle>().pongSpeed *= 2;
        pong.GetComponent<PongSingle>().offsetJumpForce = pong.GetComponent<PongSingle>().jumpForce;
        pong.GetComponent<PongSingle>().jumpForce *= 1.5f;
    }

    void ReverseSpeedUpScene()
    {
        playerSpeed *= 0.5f;
        pong.GetComponent<PongSingle>().pongSpeed *= 0.5f;
        pong.GetComponent<PongSingle>().jumpForce *= 0.67f;
    }

    void JumpLower()
    {
        jumpForce *= 2/3;
        Debug.Log("Jump Low!");
    }
    void ReverseJumpLower()
    {
        jumpForce *= 3/2;
        Debug.Log("JumpLow!");
    }
}