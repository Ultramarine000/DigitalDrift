using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatteryController : MonoBehaviour
{
    private TimerSystem timerSystem;
    public List<BatterySingle> batList;
    private bool isfirstTimePassed = false;
    public bool isCounting = true;
    void Start()
    {
        timerSystem = GameObject.FindGameObjectWithTag("GameController").GetComponent<TimerSystem>();
        for (int i = 0; i < batList.Count; i++)
        {
            batList[i].FillChange(batList.Count);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(isCounting)
        {
            int retSN;
            if (isfirstTimePassed == false && timerSystem.curMin == 0 && timerSystem.curMin == 0)
            {
                isfirstTimePassed = true;
                retSN = batList.Count;
                batList[0].FillChange(retSN);
            }
            else if (timerSystem.curMin != batList.Count)
            {
                retSN = SetSlotNum();
                batList[timerSystem.curMin].FillChange(retSN);
                for (int i = batList.Count - 1; i > timerSystem.curMin; i--)
                {
                    batList[i].FillChange(0);
                }
                for (int i = 0; i < timerSystem.curMin; i++)
                {
                    batList[i].FillChange(5);
                }
            }
        }        
    }
    int SetSlotNum()
    {
        if (timerSystem.curSec > 48)
            return 5;
        else if (timerSystem.curSec > 36)
            return 4;
        else if (timerSystem.curSec > 24)
            return 3;
        else if (timerSystem.curSec > 12)
            return 2;
        else if (timerSystem.curSec > 0)
            return 1;
        else if (timerSystem.curSec == 0)
            return 0;
        else
            return 5;
    }
    public void SetZero()
    {
        batList[0].FillChange(0);
        isCounting = false;
    }
}
