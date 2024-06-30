using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collision21 : MonoBehaviour
{
    public Rigidbody rgd21;
    // Start is called before the first frame update
    public void Start()
    {
        rgd21 = GetComponent<Rigidbody>();
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
        if (other.name != "Cylinder" && other.name != "Capsule (1)" && other.name != "Enemy 1" && other.name != "Sphere 22" && other.name != "Sphere 23" &&
            other.name != "Sphere 24" && other.name != "Sphere 25")
        {
            Enemy_1.bullet_col2 = true;
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
