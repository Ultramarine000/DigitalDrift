using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeBonus : MonoBehaviour
{
    public int bonusSeconds;
    private TimerSystem timerSystem;
    private void Awake()
    {
        timerSystem = GameObject.FindGameObjectWithTag("GameController").GetComponent<TimerSystem>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            timerSystem.AddBonusTime(bonusSeconds);
            if(gameObject.GetComponentInParent<DialogTrigger>() != null)
                gameObject.GetComponentInParent<DialogTrigger>().EnterDialogueMode();
            Destroy(gameObject);
        }
    }
}
