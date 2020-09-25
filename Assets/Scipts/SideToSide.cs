using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SideToSide : MonoBehaviour
{
    public int speed;
    float dir = 1.0f;
    GameObject plane;
    // Start is called before the first frame update
    float planeWidth;
    float planeMax;
    void Start()
    {
        speed = 10;
        plane = GameObject.Find("Ground");

    }

    // Update is called once per frame
    void Update()
    {
        planeWidth = plane.transform.localScale.x * 10;
        planeMax = (planeWidth / 2) - (this.transform.localScale.x / 2);
        //Debug.Log($"planeMax is {planeMax}");

        //Debug.Log($"xposition:{transform.position.x}");

        if (transform.position.x >= planeMax)
            dir = -1.0f;
        else if (transform.position.x <= -planeMax)
            dir = 1.0f;

        transform.position += new Vector3(speed * dir * Time.deltaTime, 0f, 0f);
    }


    //public Rect GetElementScreenRect(Transform go)
    //{
    //    Rect result = new Rect();
    //    result.width = ScreenHeight * 10 * go.localScale.z;
    //    result.height = ScreenHeight * 10 * go.localScale.x;
    //    result.x = 0.5f * ScreenWidth + go.localPosition.x * ScreenHeight - result.width * 0.5f;
    //    result.y = ScreenHeight - ScreenHeight * (0.5f + go.localPosition.z) - result.height * 0.5f; //a slight difference...

    //    return result;
    //}
}
