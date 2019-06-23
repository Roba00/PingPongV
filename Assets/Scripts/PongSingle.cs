using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PongSingle : MonoBehaviour
{
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Border")
        {
            gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector3(Random.Range(-200, 200), 250, 0));
        }
        if (other.gameObject.name == "Floor")
        {
            Debug.Log("You Dead");
            SceneManager.LoadScene(0);
        }
    }
}