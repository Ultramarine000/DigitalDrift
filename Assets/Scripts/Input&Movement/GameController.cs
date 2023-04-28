using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
public class GameController : MonoBehaviour
{
    private static GameController instance;

    [SerializeField]
    private Transform[] playerSpawns;
    [SerializeField]
    private GameObject playerPrefab2D, playerPrefab3D;
    //[SerializeField]
    //private bool noTimeLeft = false;

    public static List<GameObject> playerList = new List<GameObject>();
    public GameObject continuePanel;
    public int playerCount = 0;
    public int currentBlockNum = 0;
    public Text blockNumText;

    private bool[] isdead = new bool[4];
    
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

    public void GameOver()
    {
        //over dialog + panel
        DialogueManager.GetInstance().EnterDialogueMode(inkJSON_NotEnough, priority);
        //end
        blackScreen.SetActive(true);
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
    public void ChangeToSettleScene()
    {
        SceneManager.LoadScene("SettleAccount");
    }
}
