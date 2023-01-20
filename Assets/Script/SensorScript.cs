using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SensorScript : MonoBehaviour
{
    [SerializeField] private UnityEvent _triggeringAlarm;
    [SerializeField] private UnityEvent _turnAlarm;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Pig>(out Pig pig))
        {
            _triggeringAlarm.Invoke();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Pig>(out Pig pig))
        {
            _turnAlarm.Invoke();
        }
    }
}
