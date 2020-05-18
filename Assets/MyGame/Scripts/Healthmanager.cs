using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthManager : MonoBehaviour
{
    public void Update()
    {
        //rotate health package
        this.transform.Rotate(0.42f, 0.6f, 0.26f, Space.Self);
    }
    void OnCollisionEnter(Collision collision)
    {
        //get wormcontroller when player collides with health cube
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<WormController>().AddHealth();
        }

        //destroy cube when player collides with it
        Destroy(gameObject, 0);
    }
}
