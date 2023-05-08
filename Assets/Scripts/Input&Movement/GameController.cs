using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEditor.Rendering;

public class GameController : MonoBehaviour
{
    private static GameController instance;

    public bool isPausing = false;
    [SerializeField]
    private Transform[] playerSpawns;
    [SerializeField]
    private GameObject playerPrefab2D, playerPrefab3D;
    //[SerializeField]
    //private bool noTimeLeft = false;

    public static List<GameObject> playerList = new List<GameObject>();

    [Header("Panel Display Control")]
    public GameObject continuePanel;
    public Button resumeBtn;
    public GameObject finishPanel;
    public Button finishBackMenuBtn;
    public Text finishText;
    public GameObject camera3DBlack;

    public int playerCount = 0;
    public int currentBlockNum = 0;
    public Text blockNumText;

    
    public PlayerConfiguration[] playerConfigs;
    [SerializeField] private TextAsset inkJSON_NotEnough;
    [SerializeField] private int priority;
    public GameObject blackScreen;
    void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("Found more than one Gameontroller in the scene");
        }
        instance = this;

        AddPlayer();
    }
    public static GameController GetInstance()
    {
        return instance;
    }
    public GameObject GetGameObject()
    {
        return gameObject;
    }

    void AddPlayer()
    {
        //ªÒ»°playerConfig
        playerConfigs = PlayerConfigurationManager.Instance.GetPlayerConfigs().ToArray();
        for (int i = 0; i < playerConfigs.Length; i++)
        {
            if (playerConfigs[i].modeIndex == 0)
            {
                var player = Instantiate(playerPrefab2D, playerSpawns[0].position, playerSpawns[0].rotation, gameObject.transform);
                //Debug.Log("player " + playerConfigs[i].PlayerIndex + "select character 2D");
                player.GetComponent<PlayerInputHandler>().InitializePlayer(playerConfigs[i]);
                //player.GetComponent<PlayerInputHandler>().playerInputActions._2DPlayer.Enable();
                playerList.Add(player.gameObject);
                playerCount++;
            }
            else if (playerConfigs[i].modeIndex == 1)
            {
                //playerConfigs[i].
                var player = Instantiate(playerPrefab3D, playerSpawns[1].position, playerSpawns[1].rotation, gameObject.transform);
                player.GetComponent<PlayerInputHandler>().InitializePlayer(playerConfigs[i]);
                //player.GetComponent<PlayerInputHandler>().playerInputActions._3DPlayer.Enable();
                player.GetComponentInChildren<CInputHandler>().horizontal = playerConfigs[i].Input.actions.FindAction("Sight");
                playerList.Add(player.gameObject);
                playerCount++;
            }

        }
    }
    void Update()
    {
        ShowCurrentBlockNum();
        
    }
    void ShowCurrentBlockNum()
    {
        //string strOri = "current blocks:\n";
        blockNumText.text = currentBlockNum.ToString();
    }

    public void ShowContinuePanel()
    {
        isPausing = true;
        gameObject.GetComponent<TimerSystem>().PauseTimer();        
        continuePanel.SetActive(true);
        resumeBtn.Select();
    }
    public void ResumeBtn()
    {
        isPausing = false;
        continuePanel.SetActive(false);
        gameObject.GetComponent<TimerSystem>().ContinueTimer();
        
    }
    public void MenuBtn()
    {
        Destroy(PlayerConfigurationManager.GetInstance().gameObject);
        SceneManager.LoadScene("StartMenu");
        FindObjectOfType<AudioManager>().StopPlaying("LevelMusic");
        FindObjectOfType<AudioManager>().Play("MainMenuTheme");
        FindObjectOfType<AudioManager>().StopPlaying("ComputingAmbienceSFX");
    }
    public void QuitBtn()
    {
        Application.Quit();
    }
    

    public void GameOver()
    {
        //over dialog + panel
        DialogueManager.GetInstance().EnterDialogueMode(inkJSON_NotEnough, priority);
        //end
        blackScreen.SetActive(true);
        camera3DBlack.SetActive(true);
        finishText.text = "Game Over - You failed";
        finishPanel.SetActive(true);
        finishBackMenuBtn.Select();
        FindObjectOfType<AudioManager>().StopPlaying("LevelMusic");
        FindObjectOfType<AudioManager>().Play("GameOver");
    }

    public void LevelFinished()
    {
        isPausing = true;
        gameObject.GetComponent<TimerSystem>().PauseTimer();
        gameObject.GetComponentInChildren<Mover3D>().StopPlayerVelocity();
        gameObject.GetComponentInChildren<Mover3D>().enabled = false;
        finishText.text = "Level-1 Compete";
        finishPanel.SetActive(true);
        finishBackMenuBtn.Select();
        FindObjectOfType<AudioManager>().StopPlaying("LevelMusic");
        FindObjectOfType<AudioManager>().Play("Cheering");
    }
    public void Reborn()
    {
        //Destroy(playerPrefab3D);

        //reborn Player3D
        PlayerConfiguration p;// find 3D player input(shown as PlayerConfiguration p)  by find modeIndex == 1
        if (playerConfigs[0].modeIndex == 1)
        {
            p = playerConfigs[0];
        }
        else p = playerConfigs[1];

        var player = Instantiate(playerPrefab3D, playerSpawns[1].position, playerSpawns[1].rotation, gameObject.transform);
        player.GetComponent<PlayerInputHandler>().InitializePlayer(p);
        player.GetComponentInChildren<CInputHandler>().horizontal = playerConfigs[1].Input.actions.FindAction("Sight");
    }
    //void IsWin()
    //{
    //    int isAlive = playerCount;
    //    for (int i = 0; i < playerList.Count; i++)
    //    {
    //        if (isdead[i] == true)
    //        {
    //            isAlive--;

    //        }
    //    }
    //    if (isAlive == 1)
    //    {
    //        GameOver();
    //        isAlive = playerCount;
    //        playerList.Clear();

    //    }
    //}
    //public void GameOver()
    //{

    //    for (int i = 0; i < playerList.Count; i++)
    //    {
    //        Debug.Log("GameOver");
    //        if (playerList[i] != null)
    //        {
    //            Debug.Log("player" + (i + 1) + "Win");


    //            for (int j = 0; j < playerCount; j++)
    //            {
    //                PlayerConfigurationManager.Instance.SetLastWinnerIndex(j, i);
    //                settleText.SetText("Player " + (i + 1).ToString() + " got the winner !");
    //            }
    //            continuePanel.SetActive(true);
    //        }


    //    }
    //}
   
}
