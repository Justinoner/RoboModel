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



    // Start is called before the first frame update
    void Start()
    {
        // start at max health
        //currentHealth = maxHealth;****

        //Do find cube
       // LameExplosion exploderTouse = GameObject.Find("Cube").GetComponent<LameExplosion>();
        //
        //OnDie.AddListener(exploderTouse.Explode);
        
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("Current health" + currentHealth);
        GameManager.instance.mainGameCanvas.UpdateHealthbar(currentHealth, maxHealth);

        //if (Input.GetKeyDown(KeyCode.Space))
        //{
         //   TakeDamage(1);
       // }
    }
    public void Heal ( float amountToHeal)
    {
        currentHealth += amountToHeal;
        OnHeal.Invoke();
    }
    public void TakeDamage(float amountOfDamage) 
    {
        //call the OnTakeDamge event
        OnTakeDamage.Invoke();
        Debug.Log("damaged" + name + "***"+ amountOfDamage);

        //subract health
        currentHealth -= amountOfDamage;

        //if our health <= 0, we die
        if (currentHealth <= 0)
        {
            //call the die event
            OnDie.Invoke();
        }
        else
        {
            // don't go over max health
            currentHealth = Mathf.Min(currentHealth, maxHealth);
        }
    }
}
