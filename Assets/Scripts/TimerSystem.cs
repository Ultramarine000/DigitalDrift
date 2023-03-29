using UnityEngine;
using System.Collections;
using System;

public class TimerSystem : MonoBehaviour
{
    Timer timer;
    public int length = 10;
    public bool isCountdown = true;
    void Start()
    {
        // ������ʱ��
        timer = Timer.createTimer("GameTime");
        //��ʼ��ʱ
        timer.startTiming(length, isCountdown, OnComplete, OnProcess);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha0))
        {
            Debug.Log("Pause");
            timer.pauseTimer();//��ͣ
        }
        if (Input.GetKeyDown(KeyCode.Alpha9))
        {
            Debug.Log("Resume");
            timer.connitueTimer();//����
        }
        if (Input.GetKeyDown(KeyCode.Alpha8))
        {
            Debug.Log("Restart");
            timer.reStartTimer();//���¼�ʱ
        }
        if (Input.GetKeyDown(KeyCode.Alpha7))
        {
            Debug.Log("change length to ��20");
            timer.changeTargetTime(20);//����Ŀ��ʱ��
        }
    }

    // ��ʱ�����Ļص�
    void OnComplete()
    {
        Debug.Log("��ʱ���");
    }

    // ��ʱ���Ľ���
    void OnProcess(float p)
    {
        Debug.Log(FormatTime(p));
    }

    /// <summary>
    /// ��ʽ��ʱ��
    /// </summary>
    /// <param name="seconds">��</param>
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
}
