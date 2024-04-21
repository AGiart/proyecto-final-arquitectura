using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerController : MonoBehaviour
{
    [SerializeField]
    Image timer;

    [SerializeField]
    float maxTime;

    float _currentTime;

    private void Start()
    {
        _currentTime = maxTime;
    }

    private void Update()
    {
        _currentTime -= Time.deltaTime;
        if(_currentTime < 0)
        {
            PlayerHealthController player = FindAnyObjectByType<PlayerHealthController>();
            player.Die();
            return;
        }

        timer.fillAmount = _currentTime / maxTime;
    }

}
