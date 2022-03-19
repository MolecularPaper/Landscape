using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(BoxCollider))]
/// <summary>
/// 영역 내에 들어왔을경우 onEnter 이벤트를 발생시킴
/// </summary>
public class EventZone : MonoBehaviour
{
    [SerializeField] private EventDatas enterEvent;
    [SerializeField] private EventDatas stayEvent;
    [SerializeField] private EventDatas exitEvent;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player") {
            enterEvent.Invoke();
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player") {
            stayEvent.Invoke();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player") {
            exitEvent.Invoke();
            GetComponent<BoxCollider>().enabled = false;
        }
    }

    
}
