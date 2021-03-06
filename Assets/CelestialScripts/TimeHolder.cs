﻿using UnityEngine;
using System.Collections;
using System.Threading;
using UnityEngine.EventSystems;

public class TimeHolder : MonoBehaviour {

    public int fixedHour = 11;
    public bool useFixedTime = true;
    
    static long _displayedTimeTicks;

    DFTime realTime = new DFTime();
    
    public static DFTime DisplayedTime
    {
        get
        {
            return new DFTime(_displayedTimeTicks);
        }
        set
        {
            Interlocked.Exchange(ref _displayedTimeTicks, value.Ticks);
        }
    }

    void Update()
    {
        if (Input.GetButtonDown("PauseTime") && EventSystem.current.currentSelectedGameObject == null)
        {
            if (useFixedTime == false)
                StopTime();
            else
                useFixedTime = false;
        }
        if (Input.GetButtonDown("TimeForward") && EventSystem.current.currentSelectedGameObject == null)
        {
            StopTime();
            fixedHour += 1;
        }
        if (Input.GetButtonDown("TimeReverse") && EventSystem.current.currentSelectedGameObject == null)
        {
            StopTime();
            fixedHour -= 1;
        }
        if (fixedHour >= 24)
            fixedHour -= 24;
        if (fixedHour < 0)
            fixedHour += 24;

        realTime = DFConnection.Instance.DFTime;

        if (useFixedTime)
            DisplayedTime = new DFTime(realTime.Year, realTime.Month, realTime.Day, fixedHour, 0);
        else
            DisplayedTime = realTime;
    }

    void StopTime()
    {
        if (useFixedTime == true)
            return; //Nothingto do.
        if (realTime.Minute > 30)
            fixedHour = realTime.Hour + 1;
        else
            fixedHour = realTime.Hour;
        useFixedTime = true;
    }
}
