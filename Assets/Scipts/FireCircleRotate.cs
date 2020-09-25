using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireCircleRotate : MonoBehaviour
{
    public float circleRad;
    public float angle;
    public float speed;
    float startX;
    float startY;
    GameObject center;
    // Start is called before the first frame update
    void Start()
    {
        center = GameObject.Find("FireballCenter");
        startX = this.transform.position.x;
        startY = this.transform.position.y;
    }

    Vector3 correctifyQuadrant(Vector3 vec)
    {
        if (angle >= 270)
        {
            vec.x *= -1.0f;
        }
        else if (angle >= 180)
        {
            vec.x *= -1.0f;
            vec.y *= -1.0f;
        }
        else if (angle >= 90)
        {
            vec.y *= -1.0f;
        }

        return vec;
    }

    Vector3 findLocalAngle()
    {
        float localAngle = angle;
        Vector3 v3 = new Vector3();


        if (angle >= 270)
        {
            localAngle = angle - 270;
            double angleRad = localAngle * Math.PI / 180f;
            v3.x = (float)(circleRad * Math.Cos(angleRad));
            v3.y = (float)(circleRad * Math.Sin(angleRad));
            v3.z = this.transform.position.z;
            v3.y += startY;
        }
        else if (angle >= 180)
        {
            localAngle = angle - 180;
            double angleRad = localAngle * Math.PI / 180f;
            v3.x = (float)(circleRad * Math.Sin(angleRad));
            v3.y = (float)(circleRad * Math.Cos(angleRad));
            v3.z = this.transform.position.z;
            v3.y -= startY;
        }
        else if (angle >= 90)
        {
            localAngle = angle - 90;
            double angleRad = localAngle * Math.PI / 180f;
            v3.x = (float)(circleRad * Math.Cos(angleRad));
            v3.y = (float)(circleRad * Math.Sin(angleRad));
            v3.z = this.transform.position.z;
            v3.y -= startY;
        }
        else
        {
            double angleRad = localAngle * Math.PI / 180f;
            v3.x = (float)(circleRad * Math.Sin(angleRad));
            v3.y = (float)(circleRad * Math.Cos(angleRad));
            v3.z = this.transform.position.z;
            v3.y += startY;
        }

        //Debug.Log($"angle:{angle}, localAngle:{localAngle}");
        
        return v3;
    }

    // Update is called once per frame
    void Update()
    {
        if (angle > 360) angle = 0;

        Vector3 v3 = correctifyQuadrant(findLocalAngle());
        Debug.Log($"pos.x:{this.transform.position.x} pos.y:{this.transform.position.x}, new.x:{v3.x}, new.y:{v3.y}");
        this.transform.position = v3;
        angle += speed;
    }
}
