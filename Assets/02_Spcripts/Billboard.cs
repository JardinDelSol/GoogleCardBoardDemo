using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Billboard : MonoBehaviour
{
    // Start is called before the first frame update
    void LateUpdate()
    {
        transform.LookAt(Camera.main.transform.position);
    }
}
