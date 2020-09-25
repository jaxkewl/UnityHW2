using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follow : MonoBehaviour
{
    public GameObject currentObjToFollow;
    public Vector3 offset;
    public float rotationSpeed;
    private float multiplier;
    public void setCurrentObjToFollow(GameObject obj)
    {
        Debug.Log("setting current obj to follow to " + obj.name);
        this.currentObjToFollow = obj;
        if (obj.name.Equals("Sphere"))
            multiplier = 3.0f;
        else multiplier = 2.0f;
    }

    // Start is called before the first frame update
    void Start()
    {
        multiplier = 3.0f;
    }

    // Update is called once per frame
    void Update()
    {
        if (currentObjToFollow.name.Equals("Sphere"))
            this.transform.position = multiplier * currentObjToFollow.transform.position;
        else
            this.transform.position = offset + currentObjToFollow.transform.position;


        transform.LookAt(currentObjToFollow.transform);
        //this.transform.RotateAround(new Vector3(0, 0, 0), new Vector3(0, 1, 0), 25 * Time.deltaTime);
    }
}
