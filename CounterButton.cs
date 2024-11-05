using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CounterButton : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _textButton;
    [SerializeField] private Button _button;
    
    public event Action Clicked;
    
    public TextMeshProUGUI TextButton => _textButton;

    private void OnEnable()
    {
        _button.onClick.AddListener(() => Clicked?.Invoke());
    }

    private void OnDisable()
    {
        _button.onClick.RemoveAllListeners();
    }
}
