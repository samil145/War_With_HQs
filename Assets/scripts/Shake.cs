using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;
using UnityEngine.UI;

public class Shake : MonoBehaviour
{
    //public float duration = 1f;
    public static bool flag = false;

    [SerializeField]
    UnityEngine.Color color;
    //public AnimationCurve curve;


    private void Start()
    {
        
    }


    void Update()
    {
        if (flag)
        {
            this.color = UnityEngine.Color.red;
            Invoke("Function",0.5f);
            flag = false;
        }

    }

    void Function()
    {
        this.color = color;
    }

    //IEnumerator Shaking()
    //{
    //    Vector3 startPosition = transform.position;
    //    float elapsedTime = 0;

    //    while (elapsedTime < duration)
    //    {
    //        elapsedTime += Time.deltaTime;
    //        float strength = curve.Evaluate(elapsedTime / duration);
    //        transform.position = startPosition + Random.insideUnitSphere;
    //        yield return null;

    //    }
    //    transform.position = startPosition;
    //}
}
