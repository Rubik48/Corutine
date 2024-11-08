using System;
using System.Collections;
using UnityEngine;

public class Counter : MonoBehaviour
{
    [SerializeField] private CounterButton _button;

    private bool _isActive = false;
    private float _value = 0f;
    private float _timeDelay = 1f;
    private Coroutine _countTime;
    
    public bool IsActive => _isActive;

    public event Action ValueChanged;

    public float Value => _value;

    private void OnEnable()
    {
        _button.Clicked += Run;
    }

    private void OnDisable()
    {
        _button.Clicked -= Run;
    }

    private void Run()
    {
        if (_isActive)
        {
            StopCoroutine(_countTime);
            _isActive = false;
        }
        else
        {
            _countTime = StartCoroutine(RunStopWatch());
            _isActive = true;
        }
    }
    
    private IEnumerator RunStopWatch()
    {
        var wait = new WaitForSecondsRealtime(_timeDelay);

        while (true)
        {
            yield return wait;
            
            _value++;
            ValueChanged?.Invoke();
        }
    }
}
