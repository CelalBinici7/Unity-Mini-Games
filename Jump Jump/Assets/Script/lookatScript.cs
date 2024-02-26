using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class lookatScript : MonoBehaviour
{
    public Transform cam;

    public void LateUpdate()
    {
        transform.LookAt(transform.position + cam.forward); 
    }
}
