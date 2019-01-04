using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour {

    protected Rigidbody rb;

    protected string otherTag;
    private float changeDir;
    public bool isMoving;

    Vector3 moveDir;

    [Range(0, 20)]
    public float moveSpeed;   
    [Range(5, 20)]
    public float jumpVelocity;
    protected float fallMultiplier = 2.5f;

    public virtual void Start()
    {
        rb = GetComponent<Rigidbody>();
        isMoving = false; // No movement until touching ground
        ChangeDirGS = 1; // Set a default dir
    }

    void Update()
    {
        Movement();
    }

    protected void Movement()
    {
        if(isMoving == true)
        {
            moveDir = new Vector3(ChangeDirGS, 0, 0);
            rb.velocity = moveDir * moveSpeed;

            if (this.gameObject.name.Equals("Player"))
            {
                transform.rotation = Quaternion.LookRotation(moveDir); //Make the rot for shot emmiter face correctly
            }
        }              
    }
    protected void JumpLaunch()
    {
        Vector3 jumpLaunchDir = new Vector3(ChangeDirGS / 3, 1, 0); //Jump dir and arc
        rb.velocity = jumpLaunchDir * jumpVelocity;
        if (rb.velocity.y < 0) // smoother landing
        {
            rb.velocity += Vector3.up * Physics.gravity.y * (fallMultiplier - 1) * Time.deltaTime;
        }
    }
    protected void ChangeDirOnHit()
    {
        if (moveDir.x >= 1)
        {
            ChangeDirGS = -1;
        }
        else if (moveDir.x <= -1)
        {
            ChangeDirGS = 1;
        }
    }

    public float ChangeDirGS
    {
        get
        {
            return changeDir;
        }
        set
        {
            changeDir = value;
        }
    }

    public virtual void OnCollisionEnter(Collision other)
    {
        otherTag = other.gameObject.tag;

        if (otherTag.Equals("Side_wall"))
        {          
            ChangeDirOnHit();
        }
    }
    protected void OnTriggerEnter(Collider other)
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
        else if (otherTag.Equals("Bullet"))
        {
            if (tag.Equals("Enemy"))
            {
                Destroy(gameObject);
                Destroy(other.gameObject);
                EnemyBehavior.countEnemies--;
                Score.score++;
            }
        }
    }
    protected void OnTriggerExit(Collider other)
    {
        otherTag = other.gameObject.tag;

        if (otherTag.Equals("Ground_platform"))
        {
            isMoving = false;
        }
    }
}
