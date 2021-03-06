using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponPickup : Pickup
{
    public GameObject weaponToPickup;

    // Start is called before the first frame update
    public override void Start()
    {

    }

    // Update is called once per frame
    public override void Update()
    {
        transform.Rotate(0f, 10f * Time.deltaTime, 0f, Space.Self);
    }
    public override void OnTriggerEnter(Collider other)
    {
        Pawn otherPawn = other.GetComponent<Pawn>();
        if (otherPawn != null)
        {
            otherPawn.EquipWeapon(weaponToPickup);
        }
        base.OnTriggerEnter(other);
    }
}
