using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPlacementScript : MonoBehaviour
{
    public Vector3 placementThreshold;

    void Start()
    {
        NewPosition();
    }

    public void NewPosition()
    {
        transform.position += new Vector3(Random.Range(-placementThreshold.x, placementThreshold.x), 
                                            Random.Range(-placementThreshold.y, placementThreshold.y),
                                            Random.Range(-placementThreshold.z, placementThreshold.z));
    }
}
