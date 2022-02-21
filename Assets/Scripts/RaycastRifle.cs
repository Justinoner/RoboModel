using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaycastRifle : Weapon
{
    public Transform firePoint;
    public GameObject muzzleFlashParticlePrefab;
    public GameObject hitTargetParticlePrefab;

    // Start is called before the first frame update
    public override void Start()
    {
        base.Start();
    }

    

    // Update is called once per frame
    public override void Update()
    {
        base.Update();
    }

    public void RaycastShoot()
    {
        Instantiate(muzzleFlashParticlePrefab, firePoint.position, firePoint.rotation);

        RaycastHit hitInfo;
        if (Physics.Raycast(firePoint.position, firePoint.transform.forward, out hitInfo)) 
        {

            Instantiate(hitTargetParticlePrefab, hitInfo.point, Quaternion.LookRotation(hitInfo.normal));

            Health otherHealth = hitInfo.collider.gameObject.GetComponent<Health>();

            if(otherHealth != null)
            {
                otherHealth.TakeDamage(damageDone);
            }
        }



    }
}
