using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    [Header("Values")]
    public float maxHealth;
    public float currentHealth;
    [Header("Events")]
    public UnityEvent OnTakeDamage;
    public UnityEvent OnDie;
    public UnityEvent OnHeal;
    public UICanvas Healthbar;



    // Start is called before the first frame update
    void Start()
    {
        if (gameObject.GetComponent<PlayerController>())
        {
            Healthbar = GameObject.Find("mainGameCanvas").GetComponent<UICanvas>();
            if (Healthbar != null)
            {
                // start at max health
                Healthbar.UpdateHealthbar(currentHealth, maxHealth);
            }
        }
        
        



    }

    // Update is called once per frame
    void Update()
    {


        
    }
    public void Heal(float amountToHeal)
    {
        currentHealth += amountToHeal;
        OnHeal.Invoke();
        if (Healthbar != null)
        {
            Healthbar.UpdateHealthbar(currentHealth, maxHealth);
        }
    }
    public void TakeDamage(float amountOfDamage)
    {
        //call the OnTakeDamge event
        OnTakeDamage.Invoke();
        Debug.Log("damaged" + name + "***" + amountOfDamage);

        //subract health
        currentHealth -= amountOfDamage;

        //if our health <= 0, we die
        if (currentHealth <= 0)

        {
            Debug.Log("Dead");
            //call the die event
            OnDie.Invoke();

            GameManager.instance.HandlePersonKilled(this.gameObject);
            Destroy(this.gameObject);
        }
        else
        {
            // don't go over max health
            currentHealth = Mathf.Min(currentHealth, maxHealth);
        }
        if (Healthbar != null)
        {
            Healthbar.UpdateHealthbar(currentHealth, maxHealth);
        }
    }
}
