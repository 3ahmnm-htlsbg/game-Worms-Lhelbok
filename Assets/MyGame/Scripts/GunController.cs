using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunController : MonoBehaviour
{
    private Rigidbody player;
    public GameObject bulletSpawn;
    private Vector3 bazucaSpawnPos;

    private Quaternion bazucaSpawnRot;
    public GameObject bullet;
    private GameObject bulletInst;
    private int i = 0;
    private bool playerNumberOne;
    void Start()
    {
        player = GetComponent<Rigidbody>();
        if (this.transform.position.x < 0)
        {
            playerNumberOne = true;
        }
    }

    void Update()
    {
        if (playerNumberOne == true)
        {
            //rotate the bazuca to the right side
            if (Input.GetKey("e"))
            {
                player.AddTorque(0f, 0f, -5f);
            }

            //rotate the bazuca to the left side
            if (Input.GetKey("q"))
            {
                player.AddTorque(0f, 0f, 5f);
            }

            //shoot with the bazuca
            if (Input.GetKey("2"))
            {
                i--;
                if (i < 0)
                {
                    ShootBullet();
                    i = 23;
                }
            }
        }
        else
        {
            //rotate the bazuca to the right side
            if (Input.GetKey("o"))
            {
                player.AddTorque(0f, 0f, -5f);
            }

            //rotate the bazuca to the left side
            if (Input.GetKey("u"))
            {
                player.AddTorque(0f, 0f, 5f);
            }

            //shoot with the bazuca
            if (Input.GetKey("8"))
            {
                i--;
                if (i < 0)
                {
                    ShootBullet();
                    i = 23;
                }
            }
        }
    }

    void ShootBullet()
    {
        //lets the bazuca shoot the bullet
        Rigidbody rigidbodyBullet;

        //get the bazuca position and rotation
        bazucaSpawnPos = bulletSpawn.transform.position;
        bazucaSpawnRot = bulletSpawn.transform.rotation;

        //Instatiate the bullet
        bulletInst = Instantiate(bullet, bazucaSpawnPos, bazucaSpawnRot) as GameObject;

        //add force
        rigidbodyBullet = bulletInst.GetComponent<Rigidbody>();
        rigidbodyBullet.AddForce(this.transform.up * 2f, ForceMode.Impulse);
    }
}
