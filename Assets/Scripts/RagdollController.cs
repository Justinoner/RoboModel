using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RagdollController : MonoBehaviour
{
    public bool isRagdoll;
    private Rigidbody mainRigidbody;
    private Collider mainCollider;
    private Animator animator;
    private List<Rigidbody> ragdollRigidbodies;
    private List<Collider> ragdollColliders;
    // Start is called before the first frame update
    void Start()
    {
        //load variables
        mainRigidbody = GetComponent<Rigidbody>();
        mainCollider = GetComponent<Collider>();
        animator = GetComponent<Animator>();

        ragdollColliders = new List<Collider>(GetComponentsInChildren<Collider>());
        ragdollRigidbodies = new List<Rigidbody>(GetComponentsInChildren<Rigidbody>());

        ragdollRigidbodies.Remove(mainRigidbody);
        ragdollColliders.Remove(mainCollider);

        if (isRagdoll) {
            ActivateRagdoll();
        }
        else
        {
            DeactivateRagdoll();
        }
    }

    // Update is called once per frame
    void Update()
    {
        //test code
        if(Input.GetKeyDown(KeyCode.P))
        {
            ToggleRagdoll();
        }
        //Delete me
    }

    public void ToggleRagdoll()
    {
        isRagdoll = !isRagdoll;
        if (isRagdoll)
        {
            ActivateRagdoll();
        }
        else
        {
            DeactivateRagdoll();
        }
    }
    
    public void ActivateRagdoll ()
    {
        //Turn Off all anim, rigid body, 
        foreach ( Collider collider in ragdollColliders)
        {
            collider.enabled = true;
        }
        //turn On all main collider, rigid body, anim
        foreach (Rigidbody rb in ragdollRigidbodies)
        {
            rb.isKinematic = false;
        }

        //turn Off main collider
        mainCollider.enabled = false;
        //turn Off anim
        animator.enabled = false;
        // turn Off rigid
        mainRigidbody.isKinematic = true;


    }

    public void DeactivateRagdoll ()
    {
        //turn of colliders
        foreach (Collider collider in ragdollColliders)
        {
            collider.enabled = false;
        }
        //turn of rigidbody
        foreach (Rigidbody rb in ragdollRigidbodies)
        {
            rb.isKinematic = true;
        }
        //Turn Off all anim, rigid body, 
        mainCollider.enabled = true;
        //turn On all main collider, rigid body, anim
        mainRigidbody.isKinematic = false;
        //turn On anim
        animator.enabled = true;


    }
}
