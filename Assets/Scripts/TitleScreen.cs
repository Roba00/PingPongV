using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TitleScreen : MonoBehaviour
{   
    public Button startSinglePlayer;

    void Start()
    {
        startSinglePlayer.onClick.AddListener(StartSinglePlayer);
    }

    void Update()
    {
        
    }

    void StartSinglePlayer()
    {
        SceneManager.LoadScene(1);
    }
}
