using System.Threading.Tasks;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Jobs;

[System.Serializable]
public class EventData
{
    public UnityEvent unityEvent;
    public float delay;

    public IEnumerator Delay()
    {
        yield return new WaitForSeconds(delay);
        unityEvent.Invoke();

        yield return null;
    }
}

[System.Serializable]
public class EventDatas
{
    public List<EventData> events;

    public void Invoke()
    {
        foreach (var item in events) {
            CoroutineHandler.Start_Coroutine(item.Delay());
        }
    }
}
