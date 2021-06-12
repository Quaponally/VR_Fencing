using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class sword_collision : MonoBehaviour
{
    
    // device type
    //private XRNode controller;

    // Start is called before the first frame update
    void Start()
    {
        //get device
        //controller = GetComponent<XRNode.RightHand>();

        // check if haptics available TryGetHapticCapabilities()
        //HapticCapabilities capabilities;
        //controller.TryGetHapticCapabilities(out capabilities);
        //Debug.Log(capabilities);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        //Debug.Log("Sword Collided");
        //send haptics SendHapticImpulse
        
    }
}
