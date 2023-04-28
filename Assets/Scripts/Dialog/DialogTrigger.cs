using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogTrigger : MonoBehaviour
{
    private bool playerInRange;

    [Header("Ink JSON")]
    [SerializeField] private TextAsset inkJSON;
    [SerializeField] private int priority;

    private bool hasBeenPlayed = false;

    private void Awake()
    {
        playerInRange = false;
    }
    private void Update()
    {
        if (playerInRange && !hasBeenPlayed)
        {
            if(!DialogueManager.GetInstance().dialogueIsPlaying)
            {
                DialogueManager.GetInstance().EnterDialogueMode(inkJSON, priority);
                hasBeenPlayed = true;
                //gameObject.SetActive(false);
                Destroy(gameObject.GetComponent<DialogTrigger>());
            }
            else
            {
                if(priority > DialogueManager.GetInstance().GetCurrentPriority()) //insert dialogue has higher priority
                {
                    //interupt
                    DialogueManager.GetInstance().EnterDialogueMode(inkJSON, priority);
                    Debug.Log("interupt");
                }
            }
            
        }
    }

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            playerInRange = true;
        }
    }

    public void EnterDialogueMode()
    {
        DialogueManager.GetInstance().EnterDialogueMode(inkJSON, priority);
        Destroy(gameObject.GetComponent<DialogTrigger>());
    }

    public void EnterDialogueModeNoDis()
    {
        DialogueManager.GetInstance().EnterDialogueMode(inkJSON, priority);
    }
}
