using System;
using TMPro;
using UnityEngine;

public class CounterView : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _text;
    [SerializeField] private Counter _counter;

    private void OnEnable()
    {
        _counter.ChagedTime += ChangeTime;
    }

    private void OnDisable()
    {
        _counter.ChagedTime -= ChangeTime;
    }

    private void Start()
    {
        ChangeTime();
    }

    private void ChangeTime()
    {
        _text.text = "Count: " + _counter.Time;
    }
}
