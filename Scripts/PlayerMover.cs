using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMover : MonoBehaviour {

    private Rigidbody rb;
    
    private int changeDir;
    private float fallMultiplier = 2.5f;
    [Range(0, 20)]
    public float jumpVelocity;
    [Range(0, 20)]
    public float walkSpeed;

    public bool isMoving;
    public bool isShootingStoped;

    void Start () {
        rb = GetComponent<Rigidbody>();
    
        changeDir = 1;

        isMoving = false;
	}

	void FixedUpdate ()
    {
        NavigationButtons();
        Movement();
    }

    private void Movement()
    {
        if(isMoving == true){
            Vector3 moveDir = new Vector3(1 * changeDir, 0, 0);
            transform.rotation = Quaternion.LookRotation(moveDir);
            rb.velocity = moveDir * walkSpeed;
        }
    }

    private void NavigationButtons()
    {
        if (Input.GetKey("a"))
        {
            MoveLeftButton();
        }
        else if (Input.GetKey("d"))
        {
            MoveRightButton();
        }
    } 
    public void MoveLeftButton()
    {
        changeDir = -1;
    }
    public void MoveRightButton()
    {
        changeDir = 1;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag.Equals("Jump_pad"))
        {
            isMoving = false;
            JumpLaunch();
        }
        else if (other.gameObject.tag.Equals("Ground_platform"))
        {
            isMoving = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag.Equals("Ground_platform"))
        {
            isMoving = false;
        }
    }

    private void JumpLaunch()
    {
        Vector3 jumpLaunchDir = new Vector3(changeDir - 0.5f, 1, 0);
        rb.velocity = jumpLaunchDir * jumpVelocity;
        if (rb.velocity.y < 0)
        {
            rb.velocity += Vector3.up * Physics.gravity.y * (fallMultiplier - 1) * Time.deltaTime;
        }
    }
}