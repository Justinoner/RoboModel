using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IKController : MonoBehaviour
{
    public Pawn pawn;
   
    private float rightHandleWeight = 1.0f;
    private float leftHandleWeight = 1.0f;
    
    public Animator anim;

    private void Awake()
    {
        anim = GetComponent<Animator>();
        pawn = GetComponent<Pawn>();
    }

    public void OnAnimatorIK(int layerIndex)
    {
        if(pawn.weapon == null)
        {
            anim.SetIKPositionWeight(AvatarIKGoal.RightHand, 0.0f);
            anim.SetIKPositionWeight(AvatarIKGoal.LeftHand, 0.0f);
            anim.SetIKRotationWeight(AvatarIKGoal.RightHand, 0.0f);
            anim.SetIKRotationWeight(AvatarIKGoal.LeftHand, 0.0f);
            //exit out of function
            return;
        }

        if(pawn.weapon.RHPoint == null)
        {
            anim.SetIKPositionWeight(AvatarIKGoal.RightHand, 0.0f);
            anim.SetIKRotationWeight(AvatarIKGoal.RightHand, 0.0f);

        }
        else
        {
            anim.SetIKPosition(AvatarIKGoal.RightHand, pawn.weapon.RHPoint.position);
            anim.SetIKRotation(AvatarIKGoal.RightHand, pawn.weapon.RHPoint.rotation);
            anim.SetIKRotationWeight(AvatarIKGoal.RightHand, 1.0f);
            anim.SetIKPositionWeight(AvatarIKGoal.RightHand, 1.0f);

        }

        if (pawn.weapon.LHPoint == null)
        {
            anim.SetIKPositionWeight(AvatarIKGoal.LeftHand, 0.0f);
            anim.SetIKRotationWeight(AvatarIKGoal.RightHand, 0.0f);

        }
        else
        {
            anim.SetIKPosition(AvatarIKGoal.LeftHand, pawn.weapon.LHPoint.position);
            anim.SetIKRotation(AvatarIKGoal.LeftHand, pawn.weapon.LHPoint.rotation);
            anim.SetIKRotationWeight(AvatarIKGoal.LeftHand, 1.0f);
            anim.SetIKPositionWeight(AvatarIKGoal.LeftHand, 1.0f);

        }
    }
}
