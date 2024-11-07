using System;
using TMPro;
using UnityEngine;

public class CounterView : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _text;
    [SerializeField] private Counter _counter;

    private void OnEnable()
    {
        _counter.ValueChanged += ChangeTime;
    }

    private void OnDisable()
    {
        _counter.ValueChanged -= ChangeTime;
    }

    private void Start()
    {
        ChangeTime();
    }

    private void ChangeTime()
    {
        _text.text = "Count: " + _counter.Value;
    }
}
