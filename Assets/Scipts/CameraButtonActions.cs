using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CameraButtonActions : MonoBehaviour
{
    public GameObject camera;
    public Button sphereButton;
    public Button rectButton;

    // Start is called before the first frame update
    void Start()
    {
        sphereButton.onClick.AddListener(sphereButtonClick);
        rectButton.onClick.AddListener(cubeButtonClick);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void sphereButtonClick()
    {
        Debug.Log("Clicked Sphere");
        GameObject sphereObj = GameObject.Find("Sphere");
        camera.GetComponent<Follow>().setCurrentObjToFollow(sphereObj);
    }

    void cubeButtonClick()
    {
        Debug.Log("Clicked Cube");
        GameObject cubeObj = GameObject.Find("Cube");
        camera.GetComponent<Follow>().setCurrentObjToFollow(cubeObj);
    }
}
