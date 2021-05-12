using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    [SerializeField] private float boinceForce;
    [SerializeField] private float bounceRadius;

    public void Break()
    {
        PlatformSegment[] platformSegments = GetComponentsInChildren<PlatformSegment>();
        foreach (var segment in platformSegments)
        {
            segment.Bounce(boinceForce, transform.position, bounceRadius);
        }
    }
}
