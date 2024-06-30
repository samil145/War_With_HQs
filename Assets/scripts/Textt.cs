using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Textt : MonoBehaviour
{
    TextMeshPro txt;
    // Start is called before the first frame update
    void Start()
    {
        txt = GetComponent<TextMeshPro>();
    }

    // Update is called once per frame
    void Update()
    {
        txt.text = "" + Enemy_1.health;
        if (Controller.flag_final)
        {
            txt.text = "";
        }
    }
}
