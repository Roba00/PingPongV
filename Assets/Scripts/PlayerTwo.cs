using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class PlayerTwo : MonoBehaviour
{
    public Transform playerTwoPosition;
    public Rigidbody2D playerTwoPhysics;
    public BoxCollider2D playerTwoBoundaries;

    public Transform pongPosition;
    public Rigidbody2D pongPhysics;
    public BoxCollider2D pongBoundaries;

    public BoxCollider2D floorBoundariesTwo;

    public TextMeshProUGUI scoreTextTwo;

    public int jumpForce = 30000;
    public int scoreNumber = 0;
    public bool isGrounded = false;


    void Start()
    {
        scoreNumber = 0;
        setScore(scoreNumber);
        zeroForces(playerTwoPhysics);
        zeroForces(playerTwoPhysics);
        zeroForces(pongPhysics);
    }


    void Update()
    {
        setScore(scoreNumber);
        if (Input.GetKeyDown("w") && isGrounded)
        {
            zeroForces(playerTwoPhysics);
            playerTwoPhysics.AddForce(new Vector2(0, -jumpForce));
        }
        if (Input.GetKey("a"))
        {
            playerTwoPosition.Translate(new Vector3(-0.1f, 0, 0));
            playerTwoPosition.Rotate(new Vector3(0, 0, 0));
        }
        if (Input.GetKey("d"))
        {
            playerTwoPosition.Translate(new Vector3(0.1f, 0, 0));
            playerTwoPosition.Rotate(new Vector3(0, 0, 0));
        }
    }

    
    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.tag == "Floor")
        {
            isGrounded = false;
        }
    }

    private void OnCollisionEnter2D (Collision2D other)
    {
        if (other.gameObject.name == "Pong")
        {
            Throw();
            addScore(1);
        }

        if (other.gameObject.tag == "Floor")
        {
            isGrounded = true;
        }
    }


    void setScore(int number)
    {
        scoreTextTwo.text = number.ToString();
    }
    void addScore(int number)
    {
        scoreNumber = scoreNumber + number;
    }
    void zeroForces(Rigidbody2D physicsObject)
    {
        physicsObject.AddForce(Vector2.zero);
    }
    
    private void Throw()
    {
        pongPhysics.AddForce(new Vector3(Random.Range(-200, 200), 250, 0));
    }
}
