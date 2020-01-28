using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoopableObject : MonoBehaviour
{
    public Vector3 nextMoveAmount = new Vector3(0, 0, 0);

    //  Virtual methods can be overriden in child classes
    virtual public void NextPosition()
    {
        transform.position += nextMoveAmount;
    }
}
