using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class charctrl : MonoBehaviour {
    public CharacterController characterctrl;
    public bool isjumping = false;
    Vector3 movedirection = Vector3.zero;
    public float movementspeed = 1f;
    public float jumpSpeed = 1f;

    // Use this for initialization
    void Start () {
        characterctrl = GetComponent<CharacterController>();
        
    }
	
	// Update is called once per frame
	void Update () {
        movedirection.x = Input.GetAxis("Horizontal")*movementspeed;
        movedirection.z = Input.GetAxis("Vertical")*movementspeed;
        movedirection = transform.TransformDirection(movedirection);
        if (characterctrl.isGrounded)
        {
            isjumping = false;

            if (Input.GetButtonDown("Jump"))
            {
                isjumping = true;
                movedirection.y = jumpSpeed;
            }
        }
        else
        {
            movedirection.y += Physics.gravity.y * Time.deltaTime;
        }
        characterctrl.Move(movedirection * Time.deltaTime);
    }
}
