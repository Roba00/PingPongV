using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TitleScreen : MonoBehaviour
{   
    public Button startSinglePlayer;
    public Button startMultiPlayer;
    public Button startChallengeMode;
    public Button startAdventureMode;

    void Start()
    {
        startSinglePlayer.onClick.AddListener(StartSinglePlayer);
        startMultiPlayer.onClick.AddListener(StartMultiPlayer);
        //startChallengeMode.onClick.AddListener(StartChallengeMode);
        //startAdventureMode.onClick.AddListener(StartAdventureMode);
    }

    void Update()
    {
        
    }

    void StartSinglePlayer()
    {
        SceneManager.LoadScene(1);
    }
    void StartMultiPlayer()
    {
        SceneManager.LoadScene(2);
    }
    void StartChallengeMode()
    {
        SceneManager.LoadScene(3);
    }
    void StartAdventureMode()
    {
        SceneManager.LoadScene(4);
    }
}
