using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCtrl : MonoBehaviour
{
    public Transform camTr; //main camera transform
    public float moveSpeed = 1.0f;

    private Transform tr; //character transform components
    private CharacterController cc; //character movement
    // Start is called before the first frame update

    public static bool isStopped = false;
    void Start()
    {
        tr = GetComponent<Transform>();
        cc = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        if(isStopped == true) return;

        Vector3 dir = camTr.forward;
        
        cc.SimpleMove(dir * moveSpeed);

    }
}
