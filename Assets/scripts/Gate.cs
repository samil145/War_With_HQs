using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gate : MonoBehaviour
{
    float x, y, z;
    GameObject obj;
    bool flag1,flag2;
    // Start is called before the first frame update
    public void Start()
    {
        flag1 = false;
        flag2 = false;
        obj = GameObject.Find("Capsule");
        x = transform.position.x;
        y = transform.position.y;
        z = transform.position.z;
    }

    // Update is called once per frame
    public void Update()
    {
        if (Controller.health_enemy1 == 0 && !flag1)
        {
            transform.position = Vector3.Lerp(transform.position,
                new Vector3(transform.position.x, -10.035f, transform.position.z), 0.1f * Time.fixedDeltaTime);
            if (obj.transform.position.z > z)
            {
                flag1 = true;
            }
        }

        if (obj.transform.position.z > z + 0.5f && !flag2)
        {
            transform.position = Vector3.Lerp(transform.position,
                new Vector3(transform.position.x, y, transform.position.z), 0.1f * Time.fixedDeltaTime);
            if (transform.position.y > 10.05f)
            {
                flag2 = true;    
            }
        }

    }
}
