using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserRifle : Weapon
{
    public Transform firePoint;
    public GameObject projectilePrefab;
    public float projectileMoveSpeed;
    public float projectileLifespan;

    // Start is called before the first frame update
    public override void Start()
    {
        //run start fuctnion from parent
        base.Start();
    }

    // Update is called once per frame
   public override void Update()
    {
        // run the update function from parent
        base.Update();
    }

    public void ShootPlasmaSphere()
    {
        GameObject projectile = Instantiate(projectilePrefab, firePoint.position, firePoint.rotation) as GameObject;
        Projectile projectileScript = projectile.GetComponent<Projectile>();
        Debug.Log("zap zap zap");
        if (projectileScript != null)
        {
            projectileScript.damageDone = damageDone;
            projectileScript.lifespan = projectileLifespan;
            projectileScript.moveSpeed = projectileMoveSpeed;
        }
    }
}
