using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Healthmanager : MonoBehaviour
{
    public int health = 10;
    public TextAlignment playerOneHealth;
  
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "BulletShot" && health > 0)
        {
            health = health - 1;
        }
        if (collision.gameObject.tag == "PlusLife" && health > 10)
        {
            health = health + 1;
        }
    }
}
