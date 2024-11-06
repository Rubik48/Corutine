using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CounterButton : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _textButton;
    [SerializeField] private Button _button;
    [SerializeField] private Counter _counter;

    public event Action Clicked;

    private void OnEnable()
    {
        _button.onClick.AddListener(() => Clicked?.Invoke());
        Clicked += ChangeTextButton;
    }

    private void OnDisable()
    {
        _button.onClick.RemoveListener(() => Clicked?.Invoke());
        Clicked -= ChangeTextButton;
    }

    private void Start()
    {
        ChangeTextButton();
    }

    private void ChangeTextButton()
    {
        _textButton.text = _counter.IsActive ? "Stop" : "Run";
    }

}
