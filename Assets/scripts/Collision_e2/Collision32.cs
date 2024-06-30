using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collision32 : MonoBehaviour
{
    public Rigidbody rgd32;
    // Start is called before the first frame update
    public void Start()
    {
        rgd32 = GetComponent<Rigidbody>();
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
        if (other.name != "Cylinder 2" && other.name != "Capsule 2" && other.name != "Enemy 2" && other.name != "Sphere 31" && other.name != "Sphere 33" &&
            other.name != "Sphere 34" && other.name != "Sphere 35")
        {
            Enemy_2.bullet1_col3 = true;
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
