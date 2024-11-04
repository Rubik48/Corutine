using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _timerText;
    [SerializeField] private Button _timerButton;
    
    private TextMeshProUGUI _timerButtonText;
    private float _timer = 0f;
    private float _stepTime = 1f;
    private bool _isActive = false;

    private void Start()
    {
        _timerButtonText = _timerButton.GetComponentInChildren<TextMeshProUGUI>();
        
        UpdateTimerText();
        UpdateTextButton();
        
        _timerButton.onClick.AddListener(RunTimer);
    }

    private void RunTimer()
    {
        if (_isActive == true)
        {
            StopAllCoroutines();
            _isActive = false;
        }
        else
        {
            StartCoroutine(TimerRoutine());
            _isActive = true;
        }
        
        UpdateTextButton();
    }

    private IEnumerator TimerRoutine()
    {
        while(true)
        {
            yield return new WaitForSecondsRealtime(_stepTime);
            _timer++;
            UpdateTimerText();
        }
    }

    private void UpdateTimerText()
    {
        _timerText.text = "Счетчик: " + _timer;
    }

    private void UpdateTextButton()
    {
        _timerButtonText.text = _isActive ? "Stop" : "Start";
    }
}
