﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camara : MonoBehaviour
{
    public Transform target;
    public float smoothspeed= 0.125f;
    public Vector3 offset;
    private Vector3 velocity = Vector3.zero;

    // void FixedUpdate()
    // {
    //     Vector3 desiredPosition = target.position + offset;
    //     Vector3 smoothedPosition = Vector3.Lerp( transform.position, desiredPosition, smoothspeed);
    //     transform.position = smoothedPosition;
    //     transform.LookAt(target);
    // }


    void LateUpdate()
    {
        // Define a target position above and behind the target transform
        Vector3 targetPosition = target.TransformPoint(offset);

        // Smoothly move the camera towards that target position
        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothspeed);
        transform.LookAt(target);
    }
}
