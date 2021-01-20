using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HMDEmulator : MonoBehaviour
{

    private Transform camTr;

    public float yawSpeed = 3.0f; // Y
    public float pitchSpeed = 3.0f; // X

    void Start(){
        camTr = GetComponent<Transform>();
    }

    void Update(){ // 1/fps 
        if (Input.GetKey(KeyCode.LeftAlt)){
            // Debug.Log("LeftALt Pressed");
            Vector3 mouseVector = new Vector3(-Input.GetAxis("Mouse Y") * pitchSpeed, 
            Input.GetAxis("Mouse X") * yawSpeed,
            0);

            Vector3 rot = camTr.localEulerAngles + mouseVector;
            
            //Quaternion.Euler(<Euler Angle>) : Euler Vector(x,y,z) => Quaternition(x,y,z,w)
            //Gimbal Lock
            camTr.localRotation = Quaternion.Euler(rot);
        }
    }

}
