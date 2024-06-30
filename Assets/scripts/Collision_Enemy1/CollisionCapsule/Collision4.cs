using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collision4 : MonoBehaviour
{
    public Rigidbody rgd4;
    // Start is called before the first frame update
    public void Start()
    {
        rgd4 = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    public void Update()
    {
        if (Controller.health_count == 0)
        {
            gameObject.SetActive(false);
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.name != "Capsule" && other.name != "Sphere" && other.name != "Sphere 1" &&
            other.name != "Sphere 2" && other.name != "Sphere 3")
        {
            Controller.bullet4_col = true;
            gameObject.SetActive(false);
            //transform.position = GameObject.Find("Capsule").transform.position;
        }

        if (other.name == "Enemy 1")
        {
            Enemy_1.health--;
            Controller.health_enemy1--;
        }

        if (other.name == "Enemy 2")
        {
            Enemy_2.healthh--;
            Controller.health_enemy2--;
        }

        
    }
}

