using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class robot_ball : MonoBehaviour
{
    Animator anm;
    public static bool flag_victory;
  
    // Start is called before the first frame update
    void Start()
    {
        
        flag_victory = false;
        anm = GetComponent<Animator>();
        anm.speed = 0;
        //anm = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
        if (Controller.health_enemy2 == 0)
        {
            anm.speed = 0.5f;
            
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        if (Controller.health_enemy2 == 0 && other.name == "Capsule")
        {
            
            gameObject.SetActive(false);
            
        }
    }
}
