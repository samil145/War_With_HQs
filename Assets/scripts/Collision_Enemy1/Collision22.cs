using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collision22 : MonoBehaviour
{
    public Rigidbody rgd22;
    // Start is called before the first frame update
    public void Start()
    {
        rgd22 = GetComponent<Rigidbody>();
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
        if (other.name != "Cylinder" && other.name != "Capsule (1)" && other.name != "Enemy 1" && other.name != "Sphere 21" && other.name != "Sphere 23" &&
            other.name != "Sphere 24" && other.name != "Sphere 25")
        {
            Enemy_1.bullet1_col2 = true;
            gameObject.SetActive(false);
            //transform.position = GameObject.Find("Capsule").transform.position;
        }

        if (other.name == "Capsule")
        {
            Controller.health_count--;
            Shake.flag = true;
        }
    }
}

