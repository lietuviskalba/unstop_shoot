using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControll : MonoBehaviour {

    public GameObject player;

    private Vector3 velocity;
    public Vector3 boundPos;

    private float smoothTime;

	void Start () {

        smoothTime = 0.05f;
	}
	
	void LateUpdate () {

        CameraTrackPlayer();
	}

    void CameraTrackPlayer()
    {
        if (player != null)
        {
            float posX = Mathf.SmoothDamp(transform.position.x, player.transform.position.x, ref velocity.x, smoothTime);
            float posY = Mathf.SmoothDamp(transform.position.y, player.transform.position.y, ref velocity.y, smoothTime);

            transform.position = new Vector3(posX, posY, transform.position.z);
            CameraBounds();
        }
    }

    void CameraBounds()
    {
        transform.position = new Vector3(
            Mathf.Clamp(transform.position.x, boundPos.x * (-1), boundPos.x),
            Mathf.Clamp(transform.position.y, boundPos.y, boundPos.y * 4),
            transform.position.z);
    }
}
