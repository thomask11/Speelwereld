using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class charctrl : MonoBehaviour {
    public GameObject cameraSlave;
    public Camera cam;
    public CharacterController characterctrl;
    public bool isjumping = false;
    Vector3 movedirection = Vector3.zero;
    Vector3 cameraRotateAngle = Vector3.forward;
    public float movementspeed = 1f;
    public float jumpSpeed = 1f;

    // Use this for initialization
    void Start () {
        characterctrl = GetComponent<CharacterController>();

        Cursor.lockState = CursorLockMode.Locked;
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

        transform.RotateAround(transform.position, transform.up, Input.GetAxis("Mouse X"));

        cameraRotateAngle = cameraSlave.transform.right * -Input.GetAxis("Mouse Y");
        cameraSlave.transform.RotateAround(transform.position, cameraRotateAngle, cameraRotateAngle.magnitude);

        if (Input.GetButtonDown("Cancel"))
        {
            Cursor.lockState = CursorLockMode.None;
        }
    }
}
