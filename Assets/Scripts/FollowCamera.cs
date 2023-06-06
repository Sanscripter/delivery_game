using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    [SerializeField] GameObject focusObject;

    // Camera follows player car
    void LateUpdate()
    {
        this.transform.position = focusObject.transform.position + new Vector3(0, 0, -10) ;
        
    }
}
