using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehavior : MonoBehaviour {

    private Rigidbody rb;

    Vector3 moveDir;
    public int switchDir;
    public float moveSpeed;
    private bool hasLanded;

	void Start () {

        rb = GetComponent<Rigidbody>();
        hasLanded = false;
	}
	
	void Update () {

        if (hasLanded == true)
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
        else if (other.gameObject.tag.Equals("Ground_platform"))
        {          
            hasLanded = true;
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

    public void SetMoveDir(int dir)
    {
        switchDir = dir;
    }

    public int GetMoveDir()
    {
        return switchDir;
    }
}
