using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerShooting : MonoBehaviour {

    public GameObject textHolder;
    public GameObject ammo;
    private GameObject player;
    private GameObject cloneShots;
    
    public Text txtNextShot;

    public float shotSpeed;
    public float fireRate;
    private float nextShot;
    private float countSecToNextShot;
    private bool hasShootStop;

    void Start()
    {
        // For developing purposes, to disable/enable shooting
        player = GameObject.FindGameObjectWithTag("Player");
        hasShootStop = player.GetComponent<PlayerMover>().isShootingStoped;
    }

    void Update ()
    {
        DisplayNextShot();

        if (Time.time > nextShot && hasShootStop == false)
        {
            nextShot = Time.time + fireRate;
            countSecToNextShot = fireRate;
            cloneShots = Instantiate(ammo, transform.position, transform.rotation) as GameObject;
            cloneShots.GetComponent<Rigidbody>().velocity = transform.TransformDirection(Vector3.forward * shotSpeed);
            Destroy(cloneShots, 3f);
        }
    }

    private void DisplayNextShot()
    {
        Vector3 nextShotPos = Camera.main.WorldToScreenPoint(textHolder.transform.position);
        txtNextShot.transform.position = nextShotPos;
        countSecToNextShot -= Time.deltaTime;
        
        if(countSecToNextShot <= 3f)
        {
            txtNextShot.color = Color.yellow;
        }else if (countSecToNextShot <=1)
        {
            txtNextShot.color = Color.green;
        }
        else
        {
            txtNextShot.color = Color.red;
        }

        txtNextShot.text = countSecToNextShot.ToString("F1");
    }
}
