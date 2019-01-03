using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMover : MonoBehaviour {

    private Rigidbody rb;

    private string otherTag;
    private float changeDir;
    private float fallMultiplier = 2.5f;
    [Range(0, 20)]
    public float jumpVelocity;
    [Range(0, 20)]
    public float walkSpeed;

    public bool isMoving;
    public bool isShootingStoped;

    void Start () {
        rb = GetComponent<Rigidbody>();
    
        changeDir = 1; // Set a default direction
        isMoving = false;
	}

	void FixedUpdate ()
    {
        NavigationButtons();
        Movement();
    }

    private void NavigationButtons()
    {
        if (Input.GetKey("a"))
        {
            SetNewDir(-1);
        }
        else if (Input.GetKey("d"))
        {
            SetNewDir(1);
        }
    }
    public void SetNewDir(int dir)
    {
        changeDir = dir;
    }
    private void Movement()
    {
        if(isMoving == true){
            Vector3 moveDir = new Vector3(changeDir, 0, 0);
            transform.rotation = Quaternion.LookRotation(moveDir); //Make the rot shot emmiter, based of player rot
            rb.velocity = moveDir * walkSpeed;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        otherTag = other.gameObject.tag;
        if (otherTag.Equals("Jump_pad"))
        {
            isMoving = false;
            JumpLaunch();
        }
        else if (otherTag.Equals("Ground_platform"))
        {
            isMoving = true;
        }
    }
    void OnTriggerExit(Collider other)
    {
        if (otherTag.Equals("Ground_platform"))
        {
            isMoving = false;
        }
    }

    private void JumpLaunch()
    {
        Vector3 jumpLaunchDir = new Vector3(changeDir / 2, 1, 0);
        rb.velocity = jumpLaunchDir * jumpVelocity;
        if (rb.velocity.y < 0)
        {
            rb.velocity += Vector3.up * Physics.gravity.y * (fallMultiplier - 1) * Time.deltaTime;
        }
    }
}