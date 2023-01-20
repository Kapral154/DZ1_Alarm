using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]

public class AlarmScript : MonoBehaviour
{
    [SerializeField] private AudioSource _alarmSound;

    private Coroutine _startAlarm;
    private Coroutine _stopAlarm;
    private float _maxVolyme = 1f;
    private float _minVolume = 0f;

    private void Start()
    {
        _alarmSound = GetComponent<AudioSource>();
    }

    public void TriggeringAlarm()
    {
        _alarmSound.Play();

        if (_stopAlarm != null)
        {
            StopCoroutine(_stopAlarm);
        }

        _startAlarm = StartCoroutine(AlarmOperation(_maxVolyme));
    }

    public void TurnAlarm()
    {
        if (_startAlarm != null)
        {
            StopCoroutine(_startAlarm);
        }

        _stopAlarm = StartCoroutine(AlarmOperation(_minVolume));
    }

    private IEnumerator AlarmOperation(float target)
    {
        float spedAudio = 0.1f;

        while (_alarmSound.volume != target)
        {
            _alarmSound.volume = Mathf.MoveTowards(_alarmSound.volume, target, spedAudio * Time.deltaTime);

            if (_alarmSound.volume == _minVolume)
            {
                _alarmSound.Stop();
            }
            yield return null;
        }
    }
}

