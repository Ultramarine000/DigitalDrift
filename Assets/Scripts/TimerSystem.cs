using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System;

public class TimerSystem : MonoBehaviour
{
    Timer timer;
    GameController gameController;
    public int length = 10;
    public bool isCountdown = true;

    public int curMin,curSec;

    public Text leftTime;

    private int penaltyTime = 0;
    public BatteryController batteryController;
    private void Awake()
    {
        gameController = GetComponent<GameController>();
    }
    void Start()
    {
        // 创建计时器
        timer = Timer.createTimer("GameTime");
        //开始计时
        timer.startTiming(length, isCountdown, OnComplete, OnProcess);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha0))
        {
            Debug.Log("Pause");
            timer.pauseTimer();//暂停
        }
        if (Input.GetKeyDown(KeyCode.Alpha9))
        {
            Debug.Log("Resume");
            timer.connitueTimer();//继续
        }
        if (Input.GetKeyDown(KeyCode.Alpha8))
        {
            Debug.Log("Restart");
            timer.reStartTimer();//重新计时
        }
        if (Input.GetKeyDown(KeyCode.Alpha7))
        {
            Debug.Log("change length to ：20");
            timer.changeTargetTime(20);//更改目标时间
        }
        if (Input.GetKeyDown(KeyCode.T))
        {
            //Debug.Log(timer.GetTimeNow());
            //timer.SubPenaltyTime(60);
            timer.AddBonusTime(60);
            
        }if (Input.GetKeyDown(KeyCode.P))
        {
            //Debug.Log(timer.GetTimeNow());
            timer.SubPenaltyTime(60);
        }
    }

    // 计时结束的回调
    void OnComplete()
    {
        string strOri = "Time until shutdown: ";
        leftTime.text = strOri + "00:00";
        batteryController.SetZero();
        Debug.Log("计时完成");
        gameController.GameOver();
    }

    // 计时器的进程
    void OnProcess(float p)
    {
        string strOri = "Time until shutdown: ";
        leftTime.text = strOri + FormatTime(p);
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
    public void TouchDeathZone(int pt)
    {
        float lastTime = timer.GetTimeNow();
        if (lastTime <= pt)
        {
            timer.SubPenaltyTime(pt);
            gameController.GameOver();
        }
        else
        {
            timer.SubPenaltyTime(pt);

            //reborn panel
            gameController.Reborn();
        }
        
    }

    public void SetPenaltyTime(int pt)
    {
        penaltyTime = pt;
    }
}
