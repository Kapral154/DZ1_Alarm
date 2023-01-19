using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlarmScript : MonoBehaviour
{
    [SerializeField] private float _soundIncreaseRate;

    private AudioSource _alarmAudio;
    private bool _isAlarmWent;

    void Start()
    {
        _isAlarmWent = false;
        _alarmAudio = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (_isAlarmWent == true)
        {
            _alarmAudio.volume += _soundIncreaseRate * Time.deltaTime;
        }
        else
        {
            _alarmAudio.volume -= _soundIncreaseRate * Time.deltaTime;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Pig"))
        {
            _alarmAudio.Play();
            _isAlarmWent = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Pig"))
        {
            _isAlarmWent = false;
        }
    }
}
