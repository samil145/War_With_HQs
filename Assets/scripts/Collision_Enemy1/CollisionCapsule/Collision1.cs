using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collision1 : MonoBehaviour
{
    public Rigidbody rgd1;
    // Start is called before the first frame update
    public void Start()
    {
        rgd1 = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    public void Update()
    {

    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.name != "Capsule" && other.name != "Sphere" && other.name != "Sphere 2" &&
            other.name != "Sphere 3" && other.name != "Sphere 4")
        {
            Controller.bullet1_col = true;
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

        if (Controller.health_count == 0)
        {
            gameObject.SetActive(false);
        }
    }
}
