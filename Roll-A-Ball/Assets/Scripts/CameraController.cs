using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{

    //The obj the camera will follow 
    public GameObject target; //ASSIGN IN EDITOR

    //distance between obj and camera 
    public Vector3 posOffset; //ASSIGN IN EDITOR

    // Start is called before the first frame update

    void Start()
    {
        //calc diffrence between camera and obj
        posOffset= transform.position - target.transform.position;
        
    }

    // Update is called once per frame
    void LateUpdate()
    {
        //Camera following obj using offset
        transform.position = target.transform.position + posOffset;
    }
}
