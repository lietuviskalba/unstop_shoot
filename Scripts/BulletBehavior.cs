using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehavior : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        string otherTag = other.gameObject.tag;

        if (otherTag.Equals("Side_wall") || 
            otherTag.Equals("Ground_platform") || 
            other.Equals("Player"))
        {
            Destroy(gameObject);
        }
    }
}
