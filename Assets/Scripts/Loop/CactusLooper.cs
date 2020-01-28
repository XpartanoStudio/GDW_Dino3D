using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CactusLooper : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
            other.GetComponent<LoopableObject>().NextPosition();
    }
}
