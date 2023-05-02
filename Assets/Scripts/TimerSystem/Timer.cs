using UnityEngine;

public delegate void CompleteEvent();
public delegate void UpdateEvent(float t);

public class Timer : MonoBehaviour
{
    UpdateEvent updateEvent;
    CompleteEvent onCompleted;
    bool isLog = true;  //Whether to print messages
    float timeTarget;   // Timing time
    float timeStart;    
    float offsetTime;   
    bool isTimer;       // Whether to start timer
    bool isDestory = true;     // Whether destory after end
    bool isEnd;
    bool isIgnoreTimeScale = false;  // Whether to ignore the time rate //and fix line 51 isIgnoreTimeScale = false
    bool isRepeate;     
    float now;          //Current time Counting up
    float downNow;          //Current time counting down
    bool isDownNow = false;

    // Whether or not to use the game's real time //Does not depend on the game's time speed
    float TimeNow
    {
        get { return isIgnoreTimeScale ? Time.realtimeSinceStartup : Time.time; }
    }

    /// <summary>
    /// Create timer: name Multiple timer objects can be created based on the name
    /// </summary>
    public static Timer createTimer(string gobjName = "Timer")
    {
        GameObject g = new GameObject(gobjName);
        Timer timer = g.AddComponent<Timer>();
        return timer;
    }

    /// <summary>
    /// 开始计时
    /// </summary>
    /// <param name="time_">targetTime</param>
    /// <param name="isDownNow">isDown</param>
    /// <param name="onCompleted_">onCompleted</param>
    /// <param name="update">callback</param>
    /// <param name="isIgnoreTimeScale_">isIgnoreTimeScale_</param>
    /// <param name="isRepeate_">isRepeate_</param>
    /// <param name="isDestory_">isDestory_</param>
    public void startTiming(float timeTarget, bool isDownNow = false,
        CompleteEvent onCompleted_ = null, UpdateEvent update = null,
        bool isIgnoreTimeScale = false, bool isRepeate = false, bool isDestory = true,
        float offsetTime = 0, bool isEnd = false, bool isTimer = true)
    {
        this.timeTarget = timeTarget;
        this.isIgnoreTimeScale = isIgnoreTimeScale;
        this.isRepeate = isRepeate;
        this.isDestory = isDestory;
        this.offsetTime = offsetTime;
        this.isEnd = isEnd;
        this.isTimer = isTimer;
        this.isDownNow = isDownNow;
        timeStart = TimeNow;

        if (onCompleted_ != null)
            onCompleted = onCompleted_;
        if (update != null)
            updateEvent = update;
    }

    void Update()
    {
        if (isTimer)
        {
            now = TimeNow - offsetTime - timeStart;
            downNow = timeTarget - now;
            //Debug.Log(downNow);
            if (updateEvent != null)
            {
                if (isDownNow)
                {
                    updateEvent(downNow);
                }
                else
                {
                    updateEvent(now);
                }
            }
            if (now > timeTarget)
            {
                if (onCompleted != null)
                {
                    onCompleted();
                }
                if (!isRepeate)
                    destory();
                else
                    reStartTimer();
            }
        }
    }

    /// <summary>
    /// Get time left
    /// </summary>
    /// <returns></returns>
    public float GetTimeNow()
    {
        return Mathf.Clamp(timeTarget - now, 0, timeTarget);
    }

    /// <summary>
    /// time over
    /// </summary>
    public void destory()
    {
        isTimer = false;
        isEnd = true;
        if (isDestory)
            Destroy(gameObject);
    }

    float _pauseTime;
    /// <summary>
    /// pause timer
    /// </summary>
    public void pauseTimer()
    {
        if (isEnd)
        {
            if (isLog) Debug.LogWarning("The timer has ended！");
        }
        else
        {
            if (isTimer)
            {
                isTimer = false;
                _pauseTime = TimeNow;
            }
        }
    }

    /// <summary>
    /// resuem
    /// </summary>
    public void connitueTimer()
    {
        if (isEnd)
        {
            if (isLog) Debug.LogWarning("The timer has ended! Please start a new timer!");
        }
        else
        {
            if (!isTimer)
            {
                offsetTime += (TimeNow - _pauseTime);
                isTimer = true;
            }
        }
    }

    /// <summary>
    /// restart
    /// </summary>
    public void reStartTimer()
    {
        timeStart = TimeNow;
        offsetTime = 0;
    }

    /// <summary>
    /// Change target time
    /// </summary>
    /// <param name="time_"></param>
    public void changeTargetTime(float time_)
    {
        timeTarget = time_;
        timeStart = TimeNow;
    }


    /// <summary>
    /// 游戏暂停调用
    /// </summary>
    /// <param name="isPause_"></param>
    void OnApplicationPause(bool isPause_)
    {
        if (isPause_)
        {
            pauseTimer();
        }
        else
        {
            connitueTimer();
        }
    }

    public void AddBonusTime(int bt)
    {
        offsetTime += bt;
    }
    public void SubPenaltyTime(int pt)
    {
        offsetTime -= pt;
    }
}
