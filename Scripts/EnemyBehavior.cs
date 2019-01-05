using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehavior : Character {

    public float speedRange;
    private float currPos;
    private float prevPos;

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
            GameObject[] uis = GameObject.FindGameObjectsWithTag("Level_UI");
            foreach(GameObject ui in uis)
            {
                ui.SetActive(false);
            }
            Destroy(other.gameObject);
        }
    }

    void CheckIfIdle()
    {
        currPos = transform.position.x;

        if(currPos.ToString("F1").Equals(prevPos.ToString("F1")))
        {
            //gameObject.GetComponent<Renderer>().material.color = Color.magenta;
            BlastOutStuckOb();
        }
        else
        {
            prevPos = currPos;
        }
    }

    private void BlastOutStuckOb()
    {
        Vector3 jumpLaunchDir = new Vector3(1, 1, 0); //Jump dir and arc
        rb.velocity = jumpLaunchDir * 25f;
    }
}
