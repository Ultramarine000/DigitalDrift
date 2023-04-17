using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathZone : MonoBehaviour
{
    private GameController gameController;
    private TimerSystem timerSystem;
    public int penaltySeconds;
    // Start is called before the first frame update
    void Awake()
    {
        gameController = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
        timerSystem = gameController.GetComponent<TimerSystem>();
    }

    private void Start()
    {
        timerSystem.SetPenaltyTime(penaltySeconds);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            //gamecontroller 销毁角色 播放特效 生成新的在原点
            timerSystem.TouchDeathZone(penaltySeconds);
        }
    }
}
