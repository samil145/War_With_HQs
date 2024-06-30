using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Rendering.VirtualTexturing;
using UnityEngine.UIElements;

public class Enemy_1 : MonoBehaviour
{
    
    public static Vector3 direction;

    int count;
    public static int health;

    bool bullet21, bullet22, bullet23, bullet24, bullet25;

    public static bool bullet_col2, bullet1_col2, bullet2_col2, bullet3_col2, bullet4_col2;

    public static bool bullet_rot2, bullet1_rot2, bullet2_rot2, bullet3_rot2, bullet4_rot2;

    GameObject[] arr = new GameObject[5];

    // Start is called before the first frame update
    public void Start()
    {
        
        health = 6;
        bullet_rot2 = true;
        bullet1_rot2 = true;
        bullet2_rot2 = true;
        bullet3_rot2 = true;
        bullet4_rot2 = true;
        count = 0;
        for (int i = 0; i <= 4; i++)
        {
            arr[i] = GameObject.Find("Sphere 2" + (i+1));
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (!Controller.flag_final)
        {
            if (count == 0 && bullet25 && Mathf.Sqrt(Mathf.Pow((arr[4].transform.position.x - transform.position.x), 2) +
                Mathf.Pow((arr[4].transform.position.z - transform.position.z), 2)) > 15 || count == 0 && !bullet25)
            {
                arr[0].SetActive(true);
                bullet21 = true;
            }
            else if (count == 1 && bullet21 && Mathf.Sqrt(Mathf.Pow((arr[0].transform.position.x - transform.position.x), 2) +
                Mathf.Pow((arr[0].transform.position.z - transform.position.z), 2)) > 15 || count == 1 && !bullet21)
            {
                arr[1].SetActive(true);
                bullet22 = true;
            }
            else if (count == 2 && bullet22 && Mathf.Sqrt(Mathf.Pow((arr[1].transform.position.x - transform.position.x), 2) +
                Mathf.Pow((arr[1].transform.position.z - transform.position.z), 2)) > 15 || count == 2 && !bullet22)
            {
                arr[2].SetActive(true);
                bullet23 = true;
            }
            else if (count == 3 && bullet23 && Mathf.Sqrt(Mathf.Pow((arr[2].transform.position.x - transform.position.x), 2) +
                Mathf.Pow((arr[2].transform.position.z - transform.position.z), 2)) > 15 || count == 3 && !bullet23)
            {

                arr[3].SetActive(true);
                bullet24 = true;
            }
            else if (count == 4 && bullet24 && Mathf.Sqrt(Mathf.Pow((arr[3].transform.position.x - transform.position.x), 2) +
                Mathf.Pow((arr[3].transform.position.z - transform.position.z), 2)) > 15 || count == 4 && !bullet24)
            {

                arr[4].SetActive(true);
                bullet25 = true;
            }
        }
        
    }

    public void FixedUpdate()
    {
        if (!Controller.flag_final)
        {
            direction = transform.position - GameObject.Find("Capsule").transform.position;

            transform.forward = direction.normalized;

            if (bullet21)
            {
                if (bullet_rot2)
                {
                    arr[0].transform.position = new Vector3(transform.position.x, transform.position.y + 1.434f, transform.position.z);
                    arr[0].transform.forward = -transform.forward; //Quaternion.Euler(-direction.normalized);

                    bullet_rot2 = false;
                }
                arr[0].transform.position += arr[0].transform.forward * Time.fixedDeltaTime * 13;

                if (!bullet22)
                {
                    count = 1;
                }
                if (bullet_col2)
                {
                    bullet21 = false;
                    bullet_col2 = false;
                    bullet_rot2 = true;
                }
            }
            if (bullet22)
            {
                if (bullet1_rot2)
                {
                    arr[1].transform.position = new Vector3(transform.position.x, transform.position.y + 1.434f, transform.position.z);
                    arr[1].transform.forward = -transform.forward; //Quaternion.Euler(-direction.normalized);
                    bullet1_rot2 = false;
                }
                arr[1].transform.position += arr[1].transform.forward * Time.fixedDeltaTime * 13;
                if (!bullet23)
                {
                    count = 2;
                }
                if (bullet1_col2)
                {
                    bullet22 = false;
                    bullet1_col2 = false;
                    bullet1_rot2 = true;
                }
            }
            if (bullet23)
            {
                if (bullet2_rot2)
                {
                    arr[2].transform.position = new Vector3(transform.position.x, transform.position.y + 1.434f, transform.position.z);
                    arr[2].transform.forward = -transform.forward; //Quaternion.Euler(-direction.normalized);
                    bullet2_rot2 = false;
                }
                arr[2].transform.position += arr[2].transform.forward * Time.fixedDeltaTime * 13;
                if (!bullet24)
                {
                    count = 3;
                }
                if (bullet2_col2)
                {
                    bullet23 = false;
                    bullet2_col2 = false;
                    bullet2_rot2 = true;
                }
            }
            if (bullet24)
            {
                if (bullet3_rot2)
                {
                    arr[3].transform.position = new Vector3(transform.position.x, transform.position.y + 1.434f, transform.position.z);
                    arr[3].transform.forward = -transform.forward;//Quaternion.Euler(-direction.normalized);
                    bullet3_rot2 = false;
                }
                arr[3].transform.position += arr[3].transform.forward * Time.fixedDeltaTime * 13;
                if (!bullet25)
                {
                    count = 4;
                }
                if (bullet3_col2)
                {
                    bullet24 = false;
                    bullet3_col2 = false;
                    bullet3_rot2 = true;
                }
            }
            if (bullet25)
            {
                if (bullet4_rot2)
                {
                    arr[4].transform.position = new Vector3(transform.position.x, transform.position.y + 1.434f, transform.position.z);
                    arr[4].transform.forward = -transform.forward;//Quaternion.Euler(-direction.normalized);
                    bullet4_rot2 = false;
                }
                arr[4].transform.position += arr[4].transform.forward * Time.fixedDeltaTime * 13;
                if (!bullet21)
                {
                    count = 0;
                }
                if (bullet4_col2)
                {
                    bullet25 = false;
                    bullet4_col2 = false;
                    bullet4_rot2 = true;
                }
            }
        }
        
    }

    public void OnTriggerEnter(Collider other)
    {
        if (health == 0)
        {
            gameObject.SetActive(false);
            for (int i = 0; i <= 4; i++)
            {
                arr[i].SetActive(false);
            }
        }
    }
}
