using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Textt2 : MonoBehaviour
{
    TextMeshPro txtt;
    // Start is called before the first frame update
    void Start()
    {
        txtt = GetComponent<TextMeshPro>();
    }

    // Update is called once per frame
    void Update()
    {
        txtt.text = "" + Enemy_2.healthh;
        if (Controller.flag_final)
        {
            txtt.text = "";
        }
    }
}
