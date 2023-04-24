using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.UI;

public class SpawnPlayerSetupMenu : MonoBehaviour
{
    public GameObject playerSetupMenuPrefab;
    private PlayerConfigurationManager manager;

    private GameObject rootMenu;
    public PlayerInput input;

    private void Awake()
    {
        rootMenu = GameObject.Find("MainLayout");
        manager = gameObject.GetComponentInParent<PlayerConfigurationManager>();
        if (rootMenu != null)
        {
            var menu = Instantiate(playerSetupMenuPrefab, rootMenu.transform);//Generate prefab at the root position
            input.uiInputModule = menu.GetComponentInChildren<InputSystemUIInputModule>();
            manager.setupMenus.Add(menu.GetComponent<PlayerSetupMenuController>());
            menu.GetComponent<PlayerSetupMenuController>().SetPlayerIndex(input.playerIndex);
        }

    }
}