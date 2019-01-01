using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJump : MonoBehaviour {

    private Rigidbody rb;

    public float fallMultiplier = 2.5f;
    public float lowJumpMultiplier = 2f;

    [Range(0,20)]
    public float jumpVelocity;

    void Start () {
        rb = GetComponent<Rigidbody>();
	}
	
	void Update () {

        if (Input.GetButtonDown("Jump"))
        {
            rb.velocity = Vector3.up * jumpVelocity; // make the player jump

            if (rb.velocity.y < 0) // in the air fall slower and smoother
            {
                JumpModifiers(fallMultiplier);

            } else if (rb.velocity.y > 0 && !Input.GetButtonDown("Jump"))//quick tap on the jump
            {
                JumpModifiers(lowJumpMultiplier);
            }
        }		
	}

    void JumpModifiers(float mod)
    {
        rb.velocity += Vector3.up * Physics.gravity.y * (mod - 1) * Time.deltaTime;

    }
}
