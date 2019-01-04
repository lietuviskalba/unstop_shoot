using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehavior : Character {

    public static int countEnemies;
    public float speedRange;
    public float unstuckBlast;
    private int currPos;
    private int prevPos;

    public override void Start()
    {
        base.Start();
        RandEnemySpeed(speedRange);
        InvokeRepeating("CheckIfIdle", 5f, 3f);
    }

    public float RandEnemySpeed(float range)
    {
        float tempSpeed = moveSpeed;
        float minSpeed = tempSpeed - range;
        float maxSpeed = tempSpeed + range;
        moveSpeed = Random.Range(minSpeed, maxSpeed);
        return moveSpeed;
    }

    public override void OnCollisionEnter(Collision other)
    {
        base.OnCollisionEnter(other); // use this to also include the parents logic

        otherTag = other.gameObject.tag;

        if (otherTag.Equals("Enemy"))
        {
            ChangeDirOnHit();
        }
        else if (otherTag.Equals("Player"))
        {
            Score.hasLost = true;
            Destroy(other.gameObject);
        }
    }

    void CheckIfIdle()
    {
        currPos = (int)transform.position.x;

        if(currPos == prevPos)
        {
            EnemyUnstuck(currPos);
        }
        else
        {
            prevPos = currPos;
        }

    }

    void EnemyUnstuck(float xDir)
    {
        Vector3 blastDir = new Vector3(xDir, 1, 0);
        rb.AddForce(blastDir * 50f);
    }
}
