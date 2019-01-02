using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehavior : MonoBehaviour
{

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag.Equals("Side_wall"))
        {
            Destroy(gameObject);
        }
    }
}
