using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CircularPath : MonoBehaviour
{
    public float circleRad;
    public float angle;
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        angle = 0.0f;
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
            vec.z *= -1.0f;
        }
        else if (angle >= 90)
        {
            vec.z *= -1.0f;
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
            v3.y = this.transform.position.y;
            v3.z = (float)(circleRad * Math.Sin(angleRad));
        }
        else if (angle >= 180)
        {
            localAngle = angle - 180;
            double angleRad = localAngle * Math.PI / 180f;
            v3.x = (float)(circleRad * Math.Sin(angleRad));
            v3.y = this.transform.position.y;
            v3.z = (float)(circleRad * Math.Cos(angleRad));
        }
        else if (angle >= 90)
        {
            localAngle = angle - 90;
            double angleRad = localAngle * Math.PI / 180f;
            v3.x = (float)(circleRad * Math.Cos(angleRad));
            v3.y = this.transform.position.y;
            v3.z = (float)(circleRad * Math.Sin(angleRad));
        }
        else
        {
            double angleRad = localAngle * Math.PI / 180f;
            v3.x = (float)(circleRad * Math.Sin(angleRad));
            v3.y = this.transform.position.y;
            v3.z = (float)(circleRad * Math.Cos(angleRad));

        }

        //Debug.Log($"angle:{angle}, localAngle:{localAngle}");
        return v3;
    }

    // Update is called once per frame
    void Update()
    {
        if (angle > 360) angle = 0;

        Vector3 v3 = correctifyQuadrant(findLocalAngle());
        this.transform.position = v3;
        angle += speed;

    }
}
