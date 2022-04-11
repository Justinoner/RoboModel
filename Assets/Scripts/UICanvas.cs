using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UICanvas : MonoBehaviour
{
    public Image healthBar;
    public Text countdownTimer;
    public Button myButton;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateCountdownTimer(float secondsRemaining)
    {
        countdownTimer.text = Mathf.Ceil(secondsRemaining) + "seconds remain.";
    }
    public void UpdateHealthbar (float currentHealth, float maxHealth)
    {
        healthBar.fillAmount = currentHealth / maxHealth;
    }
}
