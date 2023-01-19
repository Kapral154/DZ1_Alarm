using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]

public class AlarmScript : MonoBehaviour
{
    private AudioSource _alarmAudio;
    private bool _isAlarmWent;

    void Awake()
    {
        _isAlarmWent = false;
        _alarmAudio = GetComponent<AudioSource>();
    }

    public void StartAlarm()
    {
        Debug.Log("go");

        _isAlarmWent = !_isAlarmWent;
        StartCoroutine(TurnVolyme(_isAlarmWent));
    }

    private IEnumerator TurnVolyme(bool _true)
    {
        Debug.Log(_true);

        if (_true == true)
        {
            for (float i = 0f; i < 1f; i += 0.01f)
            {
                _alarmAudio.volume = i;

                yield return new WaitForSeconds(0.1f);
            }
        }
        else if (_true == false)
        {
            for (float i = 1f; i > 0; i -= 0.01f)
            {
                _alarmAudio.volume = i;

                yield return new WaitForSeconds(0.1f);
            }
        }
    }
}
