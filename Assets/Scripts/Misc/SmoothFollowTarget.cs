using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmoothFollowTarget : MonoBehaviour
{
    public Transform target;
    public Vector3 offset;
    public float cameraSmoothSpeed;

    void Update()
    {
        Vector3 toPosition = target.position + offset;
        Vector3 smoothPosition = Vector3.Lerp(transform.position, toPosition, cameraSmoothSpeed * Time.deltaTime);
        transform.position = smoothPosition;
    }
}
