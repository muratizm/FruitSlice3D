using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowKnife : MonoBehaviour
{
    public Transform knife;
    public float speed = 0.125f;
    public Vector3 offset;


    void LateUpdate()
    {
        Vector3 desiredPosition = knife.position + offset;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, speed);
        transform.position = smoothedPosition;

    }
}
