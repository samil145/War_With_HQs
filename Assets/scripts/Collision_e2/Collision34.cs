using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collision34 : MonoBehaviour
{
    public Rigidbody rgd34;
    // Start is called before the first frame update
    public void Start()
    {
        rgd34 = GetComponent<Rigidbody>();
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
        if (other.name != "Cylinder 2" && other.name != "Capsule 2" && other.name != "Enemy 2" && other.name != "Sphere 31" && other.name != "Sphere 32" &&
            other.name != "Sphere 33" && other.name != "Sphere 35")
        {
            Enemy_2.bullet3_col3 = true;
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
