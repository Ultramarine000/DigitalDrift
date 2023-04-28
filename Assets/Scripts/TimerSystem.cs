using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System;

public class TimerSystem : MonoBehaviour
{
    Timer timer;
    public int length = 10;
    public bool isCountdown = true;

    public int curMin,curSec;

    public Text leftTime;

    private int penaltyTime = 0;
    public BatteryController batteryController;

    private int curBlockNum = 0;
    void Start()
    {
        Time.timeScale = 1;//游戏加速

        // 创建计时器
        timer = Timer.createTimer("GameTime");
        //开始计时
        timer.startTiming(length, isCountdown, OnComplete, OnProcess);
    }

    void Update()
    {
        curBlockNum = GameController.GetInstance().currentBlockNum;
        Time.timeScale = 1 + curBlockNum * 0.2f;

        if(DialogueManager.GetInstance().dialogueIsPlaying)
        {
            timer.pauseTimer();
        }
        else
            timer.connitueTimer();//继续
        //if (Input.GetKeyDown(KeyCode.Alpha0))
        //{
        //    Debug.Log("Pause");
        //    timer.pauseTimer();//暂停
        //}
        //if (Input.GetKeyDown(KeyCode.Alpha9))
        //{
        //    Debug.Log("Resume");
        //    timer.connitueTimer();//继续
        //}
        //if (Input.GetKeyDown(KeyCode.Alpha8))
        //{
        //    Debug.Log("Restart");
        //    timer.reStartTimer();//重新计时
        //}
        //if (Input.GetKeyDown(KeyCode.Alpha7))
        //{
        //    Debug.Log("change length to ：20");
        //    timer.changeTargetTime(20);//更改目标时间
        //}
        //if (Input.GetKeyDown(KeyCode.T))
        //{
        //    //Debug.Log(timer.GetTimeNow());
        //    //timer.SubPenaltyTime(60);
        //    timer.AddBonusTime(60);
            
        //}if (Input.GetKeyDown(KeyCode.P))
        //{
        //    //Debug.Log(timer.GetTimeNow());
        //    timer.SubPenaltyTime(60);
        //}
    }

    // 计时结束的回调
    void OnComplete()
    {
        string strOri = "Shutdown";
        leftTime.text = strOri;
        batteryController.SetZero();
        Debug.Log("计时完成");
        GameController.GetInstance().GameOver();
    }

    // 计时器的进程
    void OnProcess(float p)
    {
        //string strOri = "Shutdown:\n";
        leftTime.text = FormatTime(p);
        curMin = GetMinutes(p);
        curSec = GetSec(p);
        //Debug.Log(FormatTime(p));
    }

    /// <summary>
    /// 格式化时间
    /// </summary>
    /// <param name="seconds">秒</param>
    /// <returns></returns>
    public static string FormatTime(float seconds)
    {
        TimeSpan ts = new TimeSpan(0, 0, Convert.ToInt32(seconds));
        string str = "";
        if (ts.Hours > 0)
        {
            str = ts.Hours.ToString("00") + ":" + ts.Minutes.ToString("00") + ":" + ts.Seconds.ToString("00");
        }
        if (ts.Hours == 0 && ts.Minutes > 0)
        {
            str = ts.Minutes.ToString("00") + ":" + ts.Seconds.ToString("00");
        }
        if (ts.Hours == 0 && ts.Minutes == 0)
        {
            str = "00:" + ts.Seconds.ToString("00");
        }
        return str;
    }
    public static int GetMinutes(float seconds)
    {
        TimeSpan ts = new TimeSpan(0, 0, Convert.ToInt32(seconds));
        return ts.Minutes;
    }public static int GetSec(float seconds)
    {
        TimeSpan ts = new TimeSpan(0, 0, Convert.ToInt32(seconds));
        return ts.Seconds;
    }
    public void AddBonusTime(int bt)
    {
        timer.AddBonusTime(bt);
        //batteryController.ForeBackRefresh();
    }
    public void TouchDeathZone(int pt, GameObject player, TextAsset costText, int p)
    {
        float lastTime = timer.GetTimeNow();
        if (lastTime <= pt)
        {
            timer.SubPenaltyTime(pt);
            Destroy(player);

            GameController.GetInstance().GameOver();
        }
        else
        {
            DialogueManager.GetInstance().EnterDialogueMode(costText, p);

            timer.SubPenaltyTime(pt);
            //reborn panel
            GameController.GetInstance().Reborn();
            //Destroy(player);
        }

    }

    public void SetPenaltyTime(int pt)
    {
        penaltyTime = pt;
    }
}
