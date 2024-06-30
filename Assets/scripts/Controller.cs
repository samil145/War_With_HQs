using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Rendering.VirtualTexturing;
using UnityEngine.UIElements;

public class Controller : MonoBehaviour
{
    public GameObject obj, obj2, obj3;

    Vector3 place;

    [SerializeField]
    GameObject health_thing;

    [SerializeField]
    UnityEngine.UI.Button button;

    [SerializeField]
    GameObject panel;

    [SerializeField]
    CanvasGroup panel_black;

    [SerializeField]
    CanvasGroup panel_white;


    public static Vector3 direction;
    CharacterController characterController;

    public static int health_count,health_enemy1,health_enemy2;

    
    
    

    int count;

    bool bullet, bullet1, bullet2, bullet3, bullet4;

    public static bool bullet_col, bullet1_col, bullet2_col, bullet3_col, bullet4_col;

    public static bool bullet_rot, bullet1_rot, bullet2_rot, bullet3_rot, bullet4_rot;

    public static bool flag_final,flag_start,flag_black,flag_black2, flag_portal_inside_1, flag_portal_inside_1_2,flag_white;

    Vector3 directionForward = Vector3.zero, directionRight = Vector3.zero;
    Vector3 movement = Vector3.zero;
    GameObject[] arr = new GameObject[5];

    [SerializeField]
    float speed;

    bool forward = false, right = false;

    // Start is called before the first frame update
    public void Start()
    {
        //button = GameObject.Find("Button Menu").GetComponent<Button>();
        obj = GameObject.Find("Button Defeat");
        obj2 = GameObject.Find("Button Victory");
        obj3 = GameObject.Find("robot_ball");
        obj2.SetActive(false);
        obj.SetActive(false);
        flag_final = false;
        health_count = 3;
        health_enemy1 = 6;
        health_enemy2 = 8;
        bullet_rot = true;
        bullet1_rot = true;
        bullet2_rot = true;
        bullet3_rot = true;
        bullet4_rot = true;
        count = 0;
        arr[0] = GameObject.Find("Sphere");
        for (int i = 1; i <= 4; i++)
        {
            arr[i] = GameObject.Find("Sphere " + i);
        }
        speed = 10;
        characterController = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    public void Update()
    {
        button.onClick.AddListener(Menu);
        if (flag_start)
        {
            panel.SetActive(false);
        }
        if (!obj3.activeSelf && !flag_black2 && !flag_portal_inside_1_2)
        {
            //obj2.SetActive(true);
            flag_black = true;
            place = new Vector3(15.93f, 1.9522f, 61.96f);

        }
        if (flag_black)
        {
            panel_black.alpha += Time.deltaTime;
            if (panel_black.alpha == 1)
            {
                Invoke("Black", 1.5f);
                flag_black2 = true;
                gameObject.transform.position = place;
            }
            else if (flag_black2)
            {
                gameObject.transform.position = place;
                Black();
            }
        }
        if (flag_white)
        {
            panel_white.alpha += Time.deltaTime;
            if (panel_white.alpha == 1)
            {
                obj2.SetActive(true);
            }
        }
        if (health_count == 0)
        {
            obj.SetActive(true);
            flag_final = true;
        }

        if (!flag_final)
        {
            if (Input.GetKeyDown(KeyCode.W))
            {
                directionForward = transform.forward;
                forward = true;
            }
            else if (Input.GetKeyDown(KeyCode.S))
            {
                directionForward = -transform.forward;
                forward = true;
            }
            else if (Input.GetKeyDown(KeyCode.D))
            {
                directionRight = transform.right;
                right = true;
            }
            else if (Input.GetKeyDown(KeyCode.A))
            {
                directionRight = -transform.right;
                right = true;

            }
            else if (Input.GetKeyUp(KeyCode.W) || Input.GetKeyUp(KeyCode.S))
            {
                directionForward = Vector3.zero;
                forward = false;

            }
            else if (Input.GetKeyUp(KeyCode.D) || Input.GetKeyUp(KeyCode.A))
            {
                directionRight = Vector3.zero;
                right = false;
            }

            if (Input.GetKeyDown(KeyCode.Space))
            {
                if (count == 0 && bullet4 && Mathf.Sqrt(Mathf.Pow((arr[4].transform.position.x - transform.position.x), 2) +
                    Mathf.Pow((arr[4].transform.position.z - transform.position.z), 2)) > 10 || count == 0 && !bullet4)
                {
                    arr[0].SetActive(true);
                    bullet = true;
                    //if (arr[0].transform.position != transform.position)
                    //{
                    //    arr[0].transform.position = transform.position;
                    //    arr[0].SetActive(true);
                    //}


                }
                else if (count == 1 && bullet && Mathf.Sqrt(Mathf.Pow((arr[0].transform.position.x - transform.position.x), 2) +
                    Mathf.Pow((arr[0].transform.position.z - transform.position.z), 2)) > 10 || count == 1 && !bullet)
                {
                    //if (bullet)
                    //{
                    //    if (Mathf.Sqrt(Mathf.Pow((arr[0].transform.position.x - transform.position.x), 2) +
                    //Mathf.Pow((arr[0].transform.position.z - transform.position.z), 2)) > 1)
                    //    {
                    //        arr[1].SetActive(true);
                    //        bullet1 = true;
                    //    } else
                    //    {
                    //        arr[1].SetActive(false);
                    //        bullet1 = false;
                    //    }
                    //} else
                    //{
                    //    arr[1].SetActive(true);
                    //    bullet1 = true;
                    //}
                    arr[1].SetActive(true);
                    bullet1 = true;
                    //if (arr[1].transform.position != transform.position)
                    //{
                    //    arr[1].transform.position = transform.position;
                    //    arr[1].SetActive(true);
                    //}
                }
                else if (count == 2 && bullet1 && Mathf.Sqrt(Mathf.Pow((arr[1].transform.position.x - transform.position.x), 2) +
                    Mathf.Pow((arr[1].transform.position.z - transform.position.z), 2)) > 10 || count == 2 && !bullet1)
                {
                    //while (arr[1].transform.position != transform.position)
                    //{
                    //    if (Mathf.Sqrt(Mathf.Pow((arr[1].transform.position.x - transform.position.x), 2) +
                    //Mathf.Pow((arr[1].transform.position.z - transform.position.z), 2)) > 1)
                    //    {
                    //        break;
                    //    }
                    //}
                    arr[2].SetActive(true);
                    bullet2 = true;

                    //if (arr[2])
                    //{ 
                    //    arr[2].transform.position = transform.position;
                    //    arr[2].SetActive(true);
                    //}
                }
                else if (count == 3 && bullet2 && Mathf.Sqrt(Mathf.Pow((arr[2].transform.position.x - transform.position.x), 2) +
                    Mathf.Pow((arr[2].transform.position.z - transform.position.z), 2)) > 10 || count == 3 && !bullet2)
                {

                    arr[3].SetActive(true);
                    bullet3 = true;
                    //if (arr[3].transform.position != transform.position)
                    //{
                    //    arr[3].transform.position = transform.position;
                    //    arr[3].SetActive(true);
                    //}
                }
                else if (count == 4 && bullet3 && Mathf.Sqrt(Mathf.Pow((arr[3].transform.position.x - transform.position.x), 2) +
                    Mathf.Pow((arr[3].transform.position.z - transform.position.z), 2)) > 10 || count == 4 && !bullet3)
                {

                    arr[4].SetActive(true);
                    bullet4 = true;
                    //if (arr[4].transform.position != transform.position)
                    //{
                    //    arr[4].transform.position = transform.position;
                    //    arr[4].SetActive(true);
                    //}
                }
            }
        }
        
    }

    public void FixedUpdate()
    {
        if (!flag_final)
        {
            var mousePosition = Input.mousePosition;
            var capsuleWorldPosition = Camera.main.WorldToScreenPoint(transform.position);
            direction = mousePosition - capsuleWorldPosition;

            var angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Lerp(transform.rotation,
                Quaternion.AngleAxis(-angle, Vector3.up), 10 * Time.fixedDeltaTime);

            if (forward && right)
            {
                movement = (directionRight + directionForward) * speed * Time.fixedDeltaTime;
            }
            else if (forward)
            {
                movement = directionForward * speed * Time.fixedDeltaTime;
            }
            else if (right)
            {
                movement = directionRight * speed * Time.fixedDeltaTime;
            }
            else
            {
                movement = Vector3.zero;
            }
            transform.position += movement;//characterController.Move(movement);

            if (bullet)
            {
                //GameObject.Find("Sphere").transform.position = transform.position;
                if (bullet_rot)
                {
                    arr[0].transform.position = transform.position;
                    arr[0].transform.rotation = transform.rotation;
                    bullet_rot = false;
                }
                arr[0].transform.position += arr[0].transform.forward * Time.fixedDeltaTime * 13;
                if (!bullet1)
                {
                    count = 1;
                }
                if (bullet_col)
                {
                    bullet = false;
                    bullet_col = false;
                    bullet_rot = true;
                }
            }
            if (bullet1)
            {
                //GameObject.Find("Sphere 1").transform.position = transform.position;
                if (bullet1_rot)
                {
                    arr[1].transform.position = transform.position;
                    arr[1].transform.rotation = transform.rotation;
                    bullet1_rot = false;
                }
                arr[1].transform.position += arr[1].transform.forward * Time.fixedDeltaTime * 13;
                if (!bullet2)
                {
                    count = 2;
                }
                if (bullet1_col)
                {
                    bullet1 = false;
                    bullet1_col = false;
                    bullet1_rot = true;
                }
            }
            if (bullet2)
            {
                //GameObject.Find("Sphere 2").transform.position = transform.position;
                if (bullet2_rot)
                {
                    arr[2].transform.position = transform.position;
                    arr[2].transform.rotation = transform.rotation;
                    bullet2_rot = false;
                }
                arr[2].transform.position += arr[2].transform.forward * Time.fixedDeltaTime * 13;
                if (!bullet3)
                {
                    count = 3;
                }
                if (bullet2_col)
                {
                    bullet2 = false;
                    bullet2_col = false;
                    bullet2_rot = true;
                }
            }
            if (bullet3)
            {
                //GameObject.Find("Sphere 3").transform.position = transform.position;
                if (bullet3_rot)
                {
                    arr[3].transform.position = transform.position;
                    arr[3].transform.rotation = transform.rotation;
                    bullet3_rot = false;
                }
                arr[3].transform.position += arr[3].transform.forward * Time.fixedDeltaTime * 13;
                if (!bullet4)
                {
                    count = 4;
                }
                if (bullet3_col)
                {
                    bullet3 = false;
                    bullet3_col = false;
                    bullet3_rot = true;
                }
            }
            if (bullet4)
            {
                //GameObject.Find("Sphere 4").transform.position = transform.position;
                if (bullet4_rot)
                {
                    arr[4].transform.position = transform.position;
                    arr[4].transform.rotation = transform.rotation;
                    bullet4_rot = false;
                }
                arr[4].transform.position += arr[4].transform.forward * Time.fixedDeltaTime * 13;
                if (!bullet)
                {
                    count = 0;
                }
                if (bullet4_col)
                {
                    bullet4 = false;
                    bullet4_col = false;
                    bullet4_rot = true;
                }
            }
        }
    }

    void Menu()
    {
        flag_start = true;
    }

    void Black()
    {
        if (flag_portal_inside_1)
        {
            GameObject.Find("Portal 1").SetActive(false);
            flag_portal_inside_1 = false;
            
        }
        panel_black.alpha -= Time.deltaTime;
        if (panel_black.alpha > 0 && panel_black.alpha <0.2f)
        {
            flag_black = false;
        }
    }

    

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Spike")
        {
            panel_black.alpha = 1;
            health_count = 0;
        }
        if (other.name == "Portal Inside 1")
        {
            flag_portal_inside_1 = true;
            flag_portal_inside_1_2 = true;
            flag_black = true;
            obj3.SetActive(true);
            flag_black2 = false;
            place = new Vector3(40.2f, 1.9522f, 71.36f);
        }
        if (other.name == "Portal Inside escape")
        {
            flag_portal_inside_1 = false;
            flag_portal_inside_1_2 = false;
            flag_black = true;
            flag_black2 = false;
            obj3.SetActive(false);
        }
        if (other.name == "Portal Inside obey")
        {
            flag_white = true;
            health_thing.SetActive(false);
            GameObject.Find("Portal Inside obey").SetActive(false);
        }
    }
}
