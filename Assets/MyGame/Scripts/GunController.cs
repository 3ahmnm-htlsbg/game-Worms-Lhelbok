using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunController : MonoBehaviour
{
    private Rigidbody rb;
    public GameObject bulletSpawnPoint;
    private Vector3 bulletSpawnPointPos;

    private Quaternion bulletSpawnPointRot;
    public GameObject bullet;
    private GameObject bulletInst;
    private int i = 0;

   
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        //rotate the gun left
        if (Input.GetKey("q"))
        {
            rb.AddTorque(0f, 0f, 5f);
        }
        //rotate the gun right
        if (Input.GetKey("e"))
        {
            rb.AddTorque(0f, 0f, -5f);
        }
        //shoot
        if (Input.GetKey("2"))
        {
            i--;
            if (i < 0)
            {
                shoot();
                i = 20;
            }
        }

        void shoot()
        {
            Rigidbody rbBullet;
            //get GunCube Pos and Rotation
            bulletSpawnPointPos = bulletSpawnPoint.transform.position;
            bulletSpawnPointRot = bulletSpawnPoint.transform.rotation;
            //Instatiate
            bulletInst = Instantiate(bullet, bulletSpawnPointPos, bulletSpawnPointRot) as GameObject;
            //add force
            rbBullet = bulletInst.GetComponent<Rigidbody>();
            rbBullet.AddForce(this.transform.up * 2f, ForceMode.Impulse);
        }
    }
}
