using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Rendering.VirtualTexturing;
using UnityEngine.UIElements;

public class Enemy_2 : MonoBehaviour
{
    
    public static Vector3 directionn;

    int countt;
    public static int healthh;

    bool bullet31, bullet32, bullet33, bullet34, bullet35;

    public static bool bullet_col3, bullet1_col3, bullet2_col3, bullet3_col3, bullet4_col3;

    public static bool bullet_rot3, bullet1_rot3, bullet2_rot3, bullet3_rot3, bullet4_rot3;

    GameObject[] arr = new GameObject[5];

    // Start is called before the first frame update
    public void Start()
    {
        
        healthh = 8;
        bullet_rot3 = true;
        bullet1_rot3 = true;
        bullet2_rot3 = true;
        bullet3_rot3 = true;
        bullet4_rot3 = true;
        countt = 0;
        for (int i = 0; i <= 4; i++)
        {
            arr[i] = GameObject.Find("Sphere 3" + (i + 1));
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (!Controller.flag_final)
        {
            if (Controller.health_enemy1 == 0)
            {
                if (countt == 0 && bullet35 && Mathf.Sqrt(Mathf.Pow((arr[4].transform.position.x - transform.position.x), 2) +
                Mathf.Pow((arr[4].transform.position.z - transform.position.z), 2)) > 10 || countt == 0 && !bullet35)
                {
                    arr[0].SetActive(true);
                    bullet31 = true;
                }
                else if (countt == 1 && bullet31 && Mathf.Sqrt(Mathf.Pow((arr[0].transform.position.x - transform.position.x), 2) +
                    Mathf.Pow((arr[0].transform.position.z - transform.position.z), 2)) > 10 || countt == 1 && !bullet31)
                {
                    arr[1].SetActive(true);
                    bullet32 = true;
                }
                else if (countt == 2 && bullet32 && Mathf.Sqrt(Mathf.Pow((arr[1].transform.position.x - transform.position.x), 2) +
                    Mathf.Pow((arr[1].transform.position.z - transform.position.z), 2)) > 10 || countt == 2 && !bullet32)
                {
                    arr[2].SetActive(true);
                    bullet33 = true;
                }
                else if (countt == 3 && bullet33 && Mathf.Sqrt(Mathf.Pow((arr[2].transform.position.x - transform.position.x), 2) +
                    Mathf.Pow((arr[2].transform.position.z - transform.position.z), 2)) > 10 || countt == 3 && !bullet33)
                {

                    arr[3].SetActive(true);
                    bullet34 = true;
                }
                else if (countt == 4 && bullet34 && Mathf.Sqrt(Mathf.Pow((arr[3].transform.position.x - transform.position.x), 2) +
                    Mathf.Pow((arr[3].transform.position.z - transform.position.z), 2)) > 10 || countt == 4 && !bullet34)
                {

                    arr[4].SetActive(true);
                    bullet35 = true;
                }
            }
        }
        

    }

    public void FixedUpdate()
    {
        if (!Controller.flag_final)
        {
            if (Controller.health_enemy1 == 0)
            {
                directionn = transform.position - GameObject.Find("Capsule").transform.position;

                transform.forward = directionn.normalized;

                if (bullet31)
                {
                    if (bullet_rot3)
                    {
                        arr[0].transform.position = new Vector3(transform.position.x, transform.position.y + 1.434f, transform.position.z);
                        arr[0].transform.forward = -transform.forward; //Quaternion.Euler(-direction.normalized);

                        bullet_rot3 = false;
                    }
                    arr[0].transform.position += arr[0].transform.forward * Time.fixedDeltaTime * 15;

                    if (!bullet32)
                    {
                        countt = 1;
                    }
                    if (bullet_col3)
                    {
                        bullet31 = false;
                        bullet_col3 = false;
                        bullet_rot3 = true;
                    }
                }
                if (bullet32)
                {
                    if (bullet1_rot3)
                    {
                        arr[1].transform.position = new Vector3(transform.position.x, transform.position.y + 1.434f, transform.position.z);
                        arr[1].transform.forward = -transform.forward; //Quaternion.Euler(-direction.normalized);
                        bullet1_rot3 = false;
                    }
                    arr[1].transform.position += arr[1].transform.forward * Time.fixedDeltaTime * 15;
                    if (!bullet33)
                    {
                        countt = 2;
                    }
                    if (bullet1_col3)
                    {
                        bullet32 = false;
                        bullet1_col3 = false;
                        bullet1_rot3 = true;
                    }
                }
                if (bullet33)
                {
                    if (bullet2_rot3)
                    {
                        arr[2].transform.position = new Vector3(transform.position.x, transform.position.y + 1.434f, transform.position.z);
                        arr[2].transform.forward = -transform.forward; //Quaternion.Euler(-direction.normalized);
                        bullet2_rot3 = false;
                    }
                    arr[2].transform.position += arr[2].transform.forward * Time.fixedDeltaTime * 15;
                    if (!bullet34)
                    {
                        countt = 3;
                    }
                    if (bullet2_col3)
                    {
                        bullet33 = false;
                        bullet2_col3 = false;
                        bullet2_rot3 = true;
                    }
                }
                if (bullet34)
                {
                    if (bullet3_rot3)
                    {
                        arr[3].transform.position = new Vector3(transform.position.x, transform.position.y + 1.434f, transform.position.z);
                        arr[3].transform.forward = -transform.forward;//Quaternion.Euler(-direction.normalized);
                        bullet3_rot3 = false;
                    }
                    arr[3].transform.position += arr[3].transform.forward * Time.fixedDeltaTime * 15;
                    if (!bullet35)
                    {
                        countt = 4;
                    }
                    if (bullet3_col3)
                    {
                        bullet34 = false;
                        bullet3_col3 = false;
                        bullet3_rot3 = true;
                    }
                }
                if (bullet35)
                {
                    if (bullet4_rot3)
                    {
                        arr[4].transform.position = new Vector3(transform.position.x, transform.position.y + 1.434f, transform.position.z);
                        arr[4].transform.forward = -transform.forward;//Quaternion.Euler(-direction.normalized);
                        bullet4_rot3 = false;
                    }
                    arr[4].transform.position += arr[4].transform.forward * Time.fixedDeltaTime * 15;
                    if (!bullet31)
                    {
                        countt = 0;
                    }
                    if (bullet4_col3)
                    {
                        bullet35 = false;
                        bullet4_col3 = false;
                        bullet4_rot3 = true;
                    }
                }
            }
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        if (healthh == 0)
        {
            gameObject.SetActive(false);
            for (int i = 0; i <= 4; i++)
            {
                arr[i].SetActive(false);
            }
        }
    }
}
