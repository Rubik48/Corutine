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
        _button.onClick.AddListener(OnButtonClick);
    }

    private void OnDisable()
    {
        _button.onClick.RemoveListener(OnButtonClick);
    }

    private void Start()
    {
        ChangeTextButton();
    }

    private void OnButtonClick()
    {
        ChangeTextButton();
        
        Clicked?.Invoke();
    }

    private void ChangeTextButton()
    {
        _textButton.text = _counter.IsActive ? "Stop" : "Run";
    }

}
