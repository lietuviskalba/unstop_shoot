using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehavior : MonoBehaviour {

    private Rigidbody rb;

    Vector3 moveDir;

    [Range(0,20)]
    public float moveSpeed;
    [Range(0, 20)]
    public float jumpVelocity;
    private float fallMultiplier = 2.5f;
    public int switchDir;
    private bool hasLanded;
    private bool isMoving;

	void Start () {

        rb = GetComponent<Rigidbody>();
        isMoving = false;
	}
	
	void Update ()
    {
        Movement();
    }

    private void Movement()
    {
        if (isMoving == true)
        {
            moveDir = new Vector3(1 * GetMoveDir(), 0, 0);
            rb.velocity = moveDir * moveSpeed;
        }
    }

    void OnCollisionEnter(Collision other)
    {        
        if (other.gameObject.tag.Equals("Bullet"))
        {
            Destroy(gameObject);
            Destroy(other.gameObject);
        }
        else if (other.gameObject.tag.Equals("Enemy"))
        {
            ChangeDirOnHit();
        }
        else if (other.gameObject.tag.Equals("Player"))
        {
            Destroy(other.gameObject);
        }
        else if (other.gameObject.tag.Equals("Side_wall"))
        {
            ChangeDirOnHit();
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag.Equals("Jump_pad"))
        {
            isMoving = false;
            hasLanded = false;
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

    void ChangeDirOnHit()
    {
        if (moveDir.x >= 1)
        {
            switchDir = -1;
        }
        else if (moveDir.x <= -1)
        {
            switchDir = 1;
        }
    }
    private void JumpLaunch()
    {
        Vector3 jumpLaunchDir = new Vector3(GetMoveDir(), 1, 0);
        rb.velocity = jumpLaunchDir * jumpVelocity;
        if (rb.velocity.y < 0)
        {
            rb.velocity += Vector3.up * Physics.gravity.y * (fallMultiplier - 1) * Time.deltaTime;
        }
    }

    public void SetMoveDir(int dir)
    {
        switchDir = dir;
    }
    public int GetMoveDir()
    {
        return switchDir;
    }
}
