using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerSetupMenuController : MonoBehaviour
{
    [SerializeField]
    private int PlayerIndex;

    //[SerializeField]
    //private TextMeshProUGUI titleText;
    [SerializeField]
    private Text titleSelectText;


    [SerializeField]
    private GameObject readyPanel;

    [SerializeField]
    private GameObject mapPanel;

    [SerializeField]
    private GameObject menuPanel;

    [SerializeField]
    private Button readyButton;

    [SerializeField]
    private Button firstMapButton;

    private float ignoreInputTime = 1.5f;
    private bool inputEnable;

    public void SetPlayerIndex(int pi)
    {
        PlayerIndex = pi;
        //title2Text = SetText("Player " + (pi + 1).ToString());
        titleSelectText.text = "Player " + (pi + 1).ToString();
        ignoreInputTime = Time.time + ignoreInputTime;
    }

    void Update()
    {
        if (Time.time > ignoreInputTime)
        {
            inputEnable = true;
        }
    }

    /*public void SetColor(Material color)
    {
        if(!inputEnable)
        {
            return;
        }
        PlayerConfigurationManager.Instance.SetPlayerColor(PlayerIndex, color);
        readyPanel.SetActive(true);
        readyButton.Select();
        menuPanel.SetActive(false);
    }*/

    public void SetCharacter(int modeIndex)
    {
        if (!inputEnable)
        {
            return;
        }
        PlayerConfigurationManager.Instance.SetPlayerModel(PlayerIndex, modeIndex);
        if (PlayerIndex == 0)
        {
            mapPanel.SetActive(true);
            firstMapButton.Select();
            menuPanel.SetActive(false);

        }
        else if (PlayerIndex == 1)
        {
            menuPanel.SetActive(false);
            readyPanel.SetActive(true);
            readyButton.Select();
        }
    }

    public void SetMap(int mapIndex)
    {
        if (!inputEnable)
        {
            return;
        }
        PlayerConfigurationManager.Instance.SetPlayerMap(PlayerIndex, mapIndex);
        //Debug.Log(PlayerIndex + " chosed map " + mapIndex);
        readyPanel.SetActive(true);
        readyButton.Select();
        mapPanel.SetActive(false);
    }

    public void ReadyPlayer()
    {
        if (!inputEnable)
        {
            return;
        }
        PlayerConfigurationManager.Instance.ReadyPlayer(PlayerIndex);
        readyButton.gameObject.SetActive(false);
    }
    public void ContinueGame(int lastWinnerIndex)
    {
        if (!inputEnable)
        {
            return;
        }
        PlayerConfigurationManager.Instance.SetLastWinnerIndex(PlayerIndex, lastWinnerIndex);
    }
}
