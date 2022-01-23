using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawProjection : MonoBehaviour
{
    CannonControl CannonController;
    LineRenderer LineRenderer;

    public int numPoints = 50;
    public float timeBetweenPoints = 0.1f;
    public LayerMask CollidableLayers;
    void Start()
    {
        CannonController=GetComponent<CannonControl>();
        LineRenderer=GetComponent<LineRenderer>();
        
    } 
    void Update()
    {
        LineRenderer.positionCount = numPoints;
        List<Vector3> points= new List<Vector3> ();
        Vector3 startingPosition = CannonController.shotPoint.position;
        Vector3 startingVelocity = CannonController.shotPoint.up*CannonController.BlastPower;

        for (float t=0;t<numPoints;t+=timeBetweenPoints)
        {
            Vector3 newPoint = startingPosition + t * startingVelocity;
            newPoint.y=startingPosition.y+startingVelocity.y*t+Physics.gravity.y/2f*t*t;
            points.Add(newPoint);

            if(Physics.OverlapSphere(newPoint,2,CollidableLayers).Length>0)
            {
                LineRenderer.positionCount = points.Count;
                break;
            }

        }
        LineRenderer.SetPositions(points.ToArray());
    }
}
