using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PongSingle : MonoBehaviour
{
    //Lava Borders For Next Challenge?
    public float jumpForce = 200;
    public float offsetJumpForce = 1;
    public float pongSpeed = 250;

    public ParticleSystem particles;
    public AudioSource musicSource;
    public AudioSource sfxSource;

    public GameObject gameOverSkull;
    public GameObject game;
    public GameObject over;

    void Start()
    {
        jumpForce = 200;
        pongSpeed = 250;
    }

    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.name == "LeftBorder")
        {
            gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector3(Random.Range(10, jumpForce), pongSpeed, 0));
        }
        if (other.gameObject.name == "RightBorder")
        {
            gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector3(Random.Range(-jumpForce, -10), pongSpeed, 0));
        }
        if (other.gameObject.name == "Floor")
        {
            StartCoroutine(Dead());
            Debug.Log("You Dead");
        }
    }

    public void Throw()
    {
        gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector3(Random.Range(Random.Range
            (-jumpForce,-offsetJumpForce), Random.Range(offsetJumpForce, jumpForce)), pongSpeed, 0));
    }

    IEnumerator Dead()
    {
        particles.Play();
        gameOverSkull.SetActive(true);
        game.SetActive(true);
        over.SetActive(true);
        yield return new WaitForSeconds(5);
        SceneManager.LoadScene(0);
    }
}