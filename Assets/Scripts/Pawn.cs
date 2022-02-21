using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pawn : MonoBehaviour
{
    [Header("Components")]
    private Animator anim;

    [Header("Data")]
    public Weapon weapon;
    public float moveSpeed = 1; //MPS
    public float rotateSpeed = 180; //Degree.PS

    [Header("Transforms")]
    public Transform weaponMountPoint;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();   
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void UnequipWeapon()
    {
        Destroy(weapon.gameObject);

        weapon = null;
    }
    public void EquipWeapon( GameObject weaponPrefabToEquip )
    {
        UnequipWeapon();

        GameObject newWeapon = Instantiate(weaponPrefabToEquip, weaponMountPoint.position, weaponMountPoint.rotation);

        newWeapon.transform.parent = weaponMountPoint;

        weapon = newWeapon.GetComponent<Weapon>();
        //todo
    }

    public void Move()
    {
        Move(transform.forward);
    }

    public void Move(Vector3 moveVector )
    {
        //apply speed
        moveVector = moveVector * moveSpeed;
        //send parameters into animator
        anim.SetFloat("Right", moveVector.x);
        anim.SetFloat("Forward", moveVector.z);
    }
    public void RotateTowards (Vector3 targetPoint)
    {
        //find rotation that would be looking at that target point
        //find the vector to the point
        Vector3 targetVector = targetPoint - transform.position;
        //find rotation down that vector
        Quaternion targetRotation = Quaternion.LookRotation(targetVector, Vector3.up);

        //change my rotation (slowly) towrds that targeted rotation
        transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, rotateSpeed * Time.deltaTime);
    }
}
