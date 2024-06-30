using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health_text : MonoBehaviour
{
    Text txt_health;
    GameObject obj;
    // Start is called before the first frame update
    void Start()
    {
        txt_health = GetComponent<Text>();
        obj = GameObject.Find("Button (Legacy)");
    }

    // Update is called once per frame
    void Update()
    {
        txt_health.text = "Health: " + Controller.health_count;
        if (Controller.health_count == 0)
        {
            obj.SetActive(false);
        }
    }
}
