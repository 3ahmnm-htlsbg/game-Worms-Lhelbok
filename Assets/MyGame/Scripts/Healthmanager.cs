using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Healthmanager : MonoBehaviour
{
    public void Update()
    {
        //rotate pumpkins
        this.transform.Rotate(0.42f, 0.6f, 0.26f, Space.Self);
    }
    void OnCollisionEnter(Collision collision)
    {
        //get wormcontroller when player collides with pumpkin
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<WormController>().AddHealth();

            //destroy pumpkin after colliding with it
            Destroy(gameObject);
        }

        
    }
}
