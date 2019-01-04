using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMarkers : MonoBehaviour {

    public GameObject mark;

    void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.F))
        {
            Instantiate(mark, transform.position, Quaternion.identity);
        }
    }
}
