using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehavior : Character {

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
            Destroy(other.gameObject);
        }
    }
}
