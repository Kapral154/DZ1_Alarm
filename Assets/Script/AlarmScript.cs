using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class AlarmScript : MonoBehaviour
{
    [SerializeField] private float _soundIncreaseRate;

    private AudioSource _alarmAudio;
    private bool _isAlarmWent;

    void Awake()
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

    public void Change()
    {
        Debug.Log("trivoga");
        _alarmAudio.Play();
        _alarmAudio.volume += _soundIncreaseRate * Time.deltaTime;
    }
    //private void OnTriggerEnter2D(Collider2D collision)
    //{
    //    if (collision.TryGetComponent<Pig>(out Pig pig))
    //    {
    //        _alarmAudio.Play();
    //        _isAlarmWent = true;
    //    }
    //}

    //private void OnTriggerExit2D(Collider2D collision)
    //{
    //    if (collision.TryGetComponent<Pig>(out Pig pig))
    //    {
    //        _isAlarmWent = false;
    //    }
    //}
}
