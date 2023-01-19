using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SensorScript : MonoBehaviour
{
    [SerializeField] private UnityEvent _trigerAlarm;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Pig>(out Pig pig))
        {
            Debug.Log("pigpig");
            _trigerAlarm?.Invoke();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Pig>(out Pig pig))
        {
            Debug.Log("pigpigOFFF");
            _trigerAlarm?.Invoke();
        }
    }
}
