using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour {

    public GameObject ammo;
    private GameObject player;
    private GameObject cloneShots;

    public float shotSpeed;
    public float fireRate;
    private float nextShot;
    private bool hasShootStop;

    void Start()
    {
        // For developing purposes, to disable/enable shooting
        player = GameObject.FindGameObjectWithTag("Player");
        hasShootStop = player.GetComponent<PlayerMover>().isShootingStoped;
    }

    void Update () {

        if (Time.time > nextShot && hasShootStop)
        {
            nextShot = Time.time + fireRate;
            cloneShots = Instantiate(ammo, transform.position, transform.rotation) as GameObject;
            cloneShots.GetComponent<Rigidbody>().velocity = transform.TransformDirection(Vector3.forward * shotSpeed);
            Destroy(cloneShots, 3f);
        }
	}
}
