using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pig : MonoBehaviour
{
    [SerializeField] private Transform _pointAttack;
    [SerializeField] private Transform _pointRescue;
    [SerializeField] private float _speed;
    [SerializeField] private float _courage;   

    private bool _isFearfully;
    private bool _isAttack;
    private float _startCourage;
    private float _levelFear;


    // Start is called before the first frame update
    void Start()
    {
        _isAttack = true;
        _isFearfully = false;
        _courage = 10;
        _levelFear = 1;
        _startCourage = _courage;
    }

    // Update is called once per frame
    void Update()
    {
        if (_isFearfully)
        {
            _courage -= _levelFear * Time.deltaTime;

            if (_courage <= 0)
            {
                _isAttack = false;
            }
        }
        else if (_isFearfully == false && _courage <= _startCourage)
        {
            _courage += _levelFear * Time.deltaTime;

            if (_courage >= _startCourage)
            {
                _isAttack = true;
            }
        }

        if (_isAttack == false)
        {
            transform.position = Vector2.MoveTowards(transform.position, _pointRescue.position, _speed * Time.deltaTime);
            transform.eulerAngles = new Vector3(0, 180, 0);

        }
        else if (_isAttack == true)
        {
            transform.position = Vector2.MoveTowards(transform.position, _pointAttack.position, _speed * Time.deltaTime);
            transform.eulerAngles = new Vector3(0, 0, 0);
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.TryGetComponent<AlarmScript>(out AlarmScript alarm))
        {
            _isFearfully = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.TryGetComponent<AlarmScript>(out AlarmScript alarm))
        {
            _isFearfully = false;
        }
    }
}
