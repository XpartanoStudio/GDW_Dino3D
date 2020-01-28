using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundScript : LoopableObject
{
    public Transform stones;

    override public void NextPosition()
    {
        transform.position += nextMoveAmount;
		if(stones)
        	ResetStonesPosition();
    }

    void ResetStonesPosition()
    {
        foreach(Transform s in stones)
        {
            s.GetComponent<ObjectPlacementScript>().NewPosition();
        }
    }
}
