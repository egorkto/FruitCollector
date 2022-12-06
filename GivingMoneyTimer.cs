using System;
using System.Collections;
using UnityEngine;

public class GivingMoneyTimer
{
    public event Action TimeUp;

    public IEnumerator StartTimer()
    {
        while (true)
        {
            yield return new WaitForSeconds(1);
            TimeUp?.Invoke();
        }
    }
}
