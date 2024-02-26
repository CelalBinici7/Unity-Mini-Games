using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enabledScript : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Platform"))
        {
           
            other.gameObject.SetActive(false);
        }
    }
}
