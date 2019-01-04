using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControll : MonoBehaviour {

    public GameObject player;

    public Vector3 minBoundPos;
    public Vector3 maxBoundPos;

    Vector3 offset;

	void Start () {

        offset = transform.position - player.transform.position;
	}
	
	void LateUpdate () {

        if (player != null)
        transform.position = player.transform.position + offset;
        CameraBounds();
	}

    void CameraBounds()
    {
        transform.position = new Vector3(
            Mathf.Clamp(transform.position.x, minBoundPos.x, maxBoundPos.x),
            Mathf.Clamp(transform.position.y, minBoundPos.y, maxBoundPos.y),
            transform.position.z);
    }
}
