using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CastManager : MonoBehaviour
{
    private Ray ray;
    private RaycastHit hit; //return structure of the object that got hit: location, object, etc.
    private Transform camTr;
    [Range(5.0f, 20.0f)]
    public float distance = 10.0f;
    private GameObject lookObject = null; //save object that has been looked at recently
    // Start is called before the first frame update
    void Start()
    {
        camTr = Camera.main.GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        ray  = new Ray(camTr.position, camTr.forward);
        Debug.DrawRay(ray.origin, ray.direction * distance, Color.green);

        if(Physics.Raycast(ray, out hit, distance, 1<<8 | 1<<9)){ // check if layer8{
            // Debug.Log(hit.transform.name);
            MoveCtrl.isStopped = true;
            
            
        }
        else{
            MoveCtrl.isStopped = false;
        }

        if(Physics.Raycast(ray, out hit, distance, 1<<9)){
            if(lookObject != hit.transform.gameObject)
            {
                // if(lookObject != null)
                // {
                //     lookObject.SendMessage("OnGazeExit")
                // }
                lookObject?.SendMessage("OnGazeExit",SendMessageOptions.DontRequireReceiver);

                lookObject = hit.transform.gameObject;

                lookObject.SendMessage("OnGazeEnter",SendMessageOptions.DontRequireReceiver);
            }
        }
        else
        {
            lookObject?.SendMessage("OnGazeExit",SendMessageOptions.DontRequireReceiver);
            /*
            if (lookObject != null){
                lookObject.SendMessage("OnGazeExit");
            }
            */
            lookObject = null;
        }

#if UNITY_ANDROID
        if(Google.XR.Cardboard.Api.IsCloseButtonPressed == true)
        {
            Application.Quit();
        }
        else if(Google.XR.Cardboard.Api.IsTriggerPressed == true)
        {
            lookObject?.SendMessage("OnClick", SendMessageOptions.DontRequireReceiver);
        }
#endif
    }
}
