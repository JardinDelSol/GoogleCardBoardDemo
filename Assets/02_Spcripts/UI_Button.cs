using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_Button : MonoBehaviour
{
    // Start is called before the first frame update

    void OnGazeEnter()
    {
        Debug.Log("Enter");
    }
    void OnGazeExit()
    {
        Debug.Log("Exit");

    }
    
}
