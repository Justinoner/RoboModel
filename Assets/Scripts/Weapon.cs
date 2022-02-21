using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Weapon : MonoBehaviour


{
    [Header("Events")]
    public UnityEvent OnShoot;
    public UnityEvent OnPulltrigger;
    public UnityEvent OnReleaseTrigger;
    public UnityEvent OnAlternateAttackStart;
    public UnityEvent OnAlternateAttackEnd;
    public UnityEvent OnReload;
    [Header("States")]
    public bool isAutoFiring;
    [Header("Data")]
    public float fireDelay; //seconds between shots
    public float countdown;
    public float damageDone;
    public Transform RHPoint;
    public Transform LHPoint;

    // Start is called before the first frame update
    public virtual void Start()
    {
        countdown = fireDelay;
    }

    // Update is called once per frame
    public virtual void Update()
        
    {
        //subract the time it took to play the last frame from our countdown
        countdown -= Time.deltaTime;
        if (isAutoFiring && countdown <= 0)
        {
            //shoot
            Shoot();
            //reset timer
            countdown = fireDelay;
        }
    }
    public void Shoot()
    {
        OnShoot.Invoke();
    }

    public void StartAutoFire()
    {
        isAutoFiring = true;
    }

    public void EndAutoFire()
    {
        isAutoFiring = false;
    }

    public void ToggleAutoFire()
    {
        isAutoFiring = !isAutoFiring;
    }
}
