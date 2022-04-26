using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Player")]
    public Pawn pawn;
    public Camera playerCamera;
    public int lives;

    public AudioSource Shoot_Sound;


    void Start()
    {
        Shoot_Sound = GetComponent<AudioSource>();
        //declares this is the player object once player is spawned
        GameManager.instance.Player = this;

        //make sure cam is loaded
        if (playerCamera == null)
        {
            Debug.LogWarning("Error: No cam set!");
            playerCamera = FindObjectOfType<Camera>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (pawn == null) return;

        //send move command to pawn
        Vector3 moveVector = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));

        //helps player move where they are facing
        moveVector = pawn.transform.InverseTransformDirection(moveVector);

        //Limit the vector magnitude to 1
        moveVector = Vector3.ClampMagnitude(moveVector, 1.0f);

        //read Fire button inputs

        GetButtonInputs();

        // Tell the pawn to move
        pawn.Move(moveVector);
        //Rotate player to face mouse
        RotateToMouse();

    }

    private void GetButtonInputs()
    {
        if (Input.GetButtonDown("Fire1"))
            if (pawn != null)
            {
                if (pawn.weapon != null)
                {

                    pawn.weapon.OnPulltrigger.Invoke();

                }

            }
        if (Input.GetButtonUp("Fire1"))
        {
            Shoot_Sound.Play();
            pawn.weapon.OnReleaseTrigger.Invoke();
        }
        if (Input.GetButtonDown("Fire2"))
        {
            pawn.weapon.OnAlternateAttackStart.Invoke();
        }
        if (Input.GetButtonUp("Fire2"))
        {
            pawn.weapon.OnAlternateAttackEnd.Invoke();
        }


    }
    void RotateToMouse()
    {
        //Create a plane object(mathematical reperesentaion of all points in 2d)
        Plane groundPlane;

        //set plane so it is the X,Z plane the player is standing on
        groundPlane = new Plane(Vector3.up, pawn.transform.position);
        //cast ray from our camera toward the plane. through our mouse cursor
        float distance;
        Ray cameraRay = playerCamera.ScreenPointToRay(Input.mousePosition);
        groundPlane.Raycast(cameraRay, out distance);
        //find where that ray hits the plane
        Vector3 raycastPoint = cameraRay.GetPoint(distance);
        //rotate towards that point
        pawn.RotateTowards(raycastPoint);
    }
}
