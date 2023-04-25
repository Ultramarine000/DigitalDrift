using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogTrigger : MonoBehaviour
{
    private bool playerInRange;

    [Header("Ink JSON")]
    [SerializeField] private TextAsset inkJSON;

    private bool hasBeenPlayed = false;

    private void Awake()
    {
        playerInRange = false;
    }
    private void Update()
    {
        if (playerInRange && !DialogueManager.GetInstance().dialogueIsPlaying && !hasBeenPlayed)
        {
            DialogueManager.GetInstance().EnterDialogueMode(inkJSON);
            hasBeenPlayed = true;
            gameObject.SetActive(false);
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
        DialogueManager.GetInstance().EnterDialogueMode(inkJSON);
        Destroy(gameObject.GetComponent<DialogTrigger>());
    }
}
