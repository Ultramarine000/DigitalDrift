using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor.EditorTools;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.PlayerLoop;
using UnityEngine.UI;

public class PlayerSetupMenuController : MonoBehaviour
{
    [SerializeField]
    private int PlayerIndex;

    //[SerializeField]
    //private TextMeshProUGUI titleText;
    //[SerializeField]
    //private Text titleSelectText;


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

    [SerializeField]
    public GameObject switchBtn,confirmBtn,quitBtn, rileyFrame,aprilFrame, riley, april,pickTitle,waitTitle,player1,player2;


    private float ignoreInputTime = 1f;
    private bool inputEnable;


    public void SetPlayerIndex(int pi)
    {
        PlayerIndex = pi;
        //title2Text = SetText("Player " + (pi + 1).ToString());
        //titleSelectText.text = "Player " + (pi + 1).ToString();

        ignoreInputTime = Time.time + ignoreInputTime;

        //give start model index same as PlayerIndex
        PlayerConfigurationManager.Instance.SetPlayerModel(PlayerIndex, PlayerIndex);

        if (pi == 1)
        {
            player2.SetActive(true);
            switchBtn.SetActive(true);
            //confirmBtn.GetComponent<Button>().Select();
            EventSystem.current.firstSelectedGameObject = switchBtn;
            confirmBtn.SetActive(true);
            quitBtn.SetActive(true);
            rileyFrame.SetActive(true);
            riley.SetActive(true);
            aprilFrame.SetActive(false);
            april.SetActive(false);
            PlayerConfigurationManager.Instance.SetRileyPosForP0();
            SetAprilPosForP1();
            waitTitle.SetActive(false);
            pickTitle.SetActive(true);
            PlayerConfigurationManager.Instance.CloseP0WaitingTitle();
        }
        else
        {
            player1.SetActive(true);
        }
        
    }

    void Update()
    {
        if (Time.time > ignoreInputTime)
        {
            inputEnable = true;
        }
        //Debug.Log(april.GetComponent<RectTransform>().position);

        //Debug.Log("Player " + PlayerIndex + ": " + EventSystem.current.currentSelectedGameObject);
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

    public void SwitchCharacterInfo()
    {
        if (!inputEnable)
        {
            return;
        }

        PlayerConfigurationManager.Instance.Switch();        
    }

    public void SwitchFrame()
    {
        bool state = rileyFrame.activeSelf;
        rileyFrame.SetActive(!state);
        riley.SetActive(!state);

        state = aprilFrame.activeSelf;
        aprilFrame.SetActive(!state);
        april.SetActive(!state);
    }

    public void ConfirmCharacter()
    {
        if (PlayerIndex == 1)
        {
            mapPanel.SetActive(true);
            firstMapButton.Select();

            //menuPanel.SetActive(false);
            switchBtn.SetActive(false);
            confirmBtn.SetActive(false);
            quitBtn.SetActive(false);
            pickTitle.SetActive(false);
        }
    }

    public void SetRileyPosForP0()
    {
        if(PlayerIndex == 0)
        {
            RectTransform rileyTrans = riley.GetComponent<RectTransform>();
            //flip
            Vector3 s = rileyTrans.localScale;
            s.x *= -1;
            rileyTrans.localScale = s;

            Vector3 p = rileyTrans.position;
            p.x -= 188.86f;
            rileyTrans.position = p;
        }
        
    }
    void SetAprilPosForP1()
    {
        if (PlayerIndex == 1)
        {
            RectTransform aprilTrans = april.GetComponent<RectTransform>();
            //flip
            Vector3 s = aprilTrans.localScale;
            s.x *= -1;
            aprilTrans.localScale = s;

            Vector3 p = aprilTrans.position;
            p.x += 197.39f;
            aprilTrans.position = p;
        }
    }
    public void CloseP0WaitingTitle()
    {
        waitTitle.SetActive(false);
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

    public void OpenReadyPanel()
    {
        if(PlayerIndex == 0)
        {
            readyPanel.SetActive(true);
            readyButton.Select();
        }
       
    }

    public void ReadyPlayer()
    {
        if (!inputEnable)
        {
            return;
        }
        PlayerConfigurationManager.Instance.ReadyPlayer(PlayerIndex);
        readyButton.gameObject.SetActive(false);

        //Debug.Log(PlayerIndex + "is redy");
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
