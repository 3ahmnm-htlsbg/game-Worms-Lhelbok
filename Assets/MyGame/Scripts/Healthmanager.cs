using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Healthmanager : MonoBehaviour
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
            Debug.Log("Health called");
            collision.gameObject.GetComponent<WormController>().AddHealth();
            Destroy(gameObject);
        }

        //destroy cube when player collides with it
        
    }
}
