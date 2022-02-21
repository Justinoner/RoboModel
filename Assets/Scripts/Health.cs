using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

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
        currentHealth = maxHealth;

        //Do find cube
        LameExplosion exploderTouse = GameObject.Find("Cube").GetComponent<LameExplosion>();
        OnDie.AddListener(exploderTouse.Explode);
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            TakeDamage(1);
        }
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
            currentHealth = Mathf.Max(currentHealth, maxHealth);
        }
    }
}