using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class PlayerConfigurationManager : MonoBehaviour
{
    [SerializeField]
    private List<PlayerConfiguration> playerConfigs;
    [SerializeField]
    private int MaxPlayers = 2;
    public GameObject title;
    public static PlayerConfigurationManager Instance { get; private set; }

    public List<PlayerSetupMenuController> setupMenus;

    private void Awake()
    {
        if (Instance != null)
        {
            Debug.Log("[Singleton] Trying to instantiate a seccond instance of a singleton class.");
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(Instance);
            playerConfigs = new List<PlayerConfiguration>();
        }

    }

    public void HandlePlayerJoin(PlayerInput pi)
    {
        Debug.Log("player joined " + pi.playerIndex);
        //--------------
        title.SetActive(false);
        pi.transform.SetParent(transform);

        if (!playerConfigs.Any(p => p.PlayerIndex == pi.playerIndex))//Make sure the role has been added
        {
            playerConfigs.Add(new PlayerConfiguration(pi));
        }
    }

    public List<PlayerConfiguration> GetPlayerConfigs()
    {
        return playerConfigs;
    }

    public void SetPlayerColor(int index, Material color)
    {
        playerConfigs[index].playerMaterial = color;
    }
    public void SetPlayerModel(int index, int modeIndex)
    {
        playerConfigs[index].modeIndex = modeIndex;
    }
    public void SetPlayerMap(int index, int mapIndex)
    {
        playerConfigs[index].mapIndex = mapIndex;
    }
    public void SetLastWinnerIndex(int index, int winnerIndex)
    {
        playerConfigs[index].lastWinnerIndex = winnerIndex;
    }

    public void ReadyPlayer(int index)
    {
        //Debug.Log("once");
        playerConfigs[index].isReady = true;
        //if (playerConfigs.Count == MaxPlayers && playerConfigs.All(p => p.isReady == true))
        if (playerConfigs[1].isReady)
        {
            if (playerConfigs[1].mapIndex == 0) SceneManager.LoadScene("Level-1");
            else if (playerConfigs[1].mapIndex == 1) SceneManager.LoadScene("Level-1");
            else if (playerConfigs[1].mapIndex == 2) SceneManager.LoadScene("Level-1");
        }
    }
    public void Switch()
    {
        int k = playerConfigs[0].modeIndex;
        playerConfigs[0].modeIndex = playerConfigs[1].modeIndex;
        playerConfigs[1].modeIndex = k;

        //Debug.Log("once");
        //Debug.Log(playerConfigs[0].modeIndex + " and " + playerConfigs[1].modeIndex);
        setupMenus[0].SwitchFrame();
        setupMenus[1].SwitchFrame();
    }
    public void SetRileyPosForP0()
    {
        setupMenus[0].SetRileyPosForP0();
    }
    public void CloseP0WaitingTitle()
    {
        setupMenus[0].CloseP0WaitingTitle();
    }
}

public class PlayerConfiguration
{
    public PlayerConfiguration(PlayerInput pi)//Pass in the input signal pi to create an instance of PlayerConfiguration
    {
        PlayerIndex = pi.playerIndex;//The number contained in the pi passed in at creation is recorded as the player number
        Input = pi;//pi is saved individually as Input
    }

    public PlayerInput Input { get; private set; }
    public int PlayerIndex { get; private set; }
    public bool isReady { get; set; }
    public Material playerMaterial { get; set; }
    public int modeIndex { get; set; }
    public int mapIndex { get; set; }
    public int lastWinnerIndex { get; set; }
}