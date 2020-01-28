using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundLooper : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ground"))
            other.GetComponent<LoopableObject>().NextPosition();
    }
}
