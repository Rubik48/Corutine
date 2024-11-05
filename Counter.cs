using System;
using System.Collections;
using UnityEngine;

public class Counter : MonoBehaviour
{
    [SerializeField] private CounterButton _counterButton;

    private bool _isActive = false;
    private float _time = 0f;
    private float _timeDelay = 1f;
    private Coroutine _countTime;

    public event Action ChagedTime;

    public float Time => _time;

    private void OnEnable()
    {
        _counterButton.Clicked += Run;
    }

    private void OnDisable()
    {
        _counterButton.Clicked -= Run;
    }

    private void Start()
    {
        ChangeTextButton();
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
            _countTime = StartCoroutine(CountTime());
            _isActive = true;
        }
        
        ChangeTextButton();
    }

    private void ChangeTextButton()
    {
        _counterButton.TextButton.text = _isActive ? "Stop" : "Run";
    }

    private IEnumerator CountTime()
    {
        var wait = new WaitForSecondsRealtime(_timeDelay);

        while (true)
        {
            yield return wait;
            _time++;
            ChagedTime?.Invoke();
        }
    }
}
