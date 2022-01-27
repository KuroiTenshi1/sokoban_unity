using System;
using System.Collections;
using System.Collections.Generic;
using Newtonsoft.Json.Serialization;
using UnityEngine;

public class MoveCube : MonoBehaviour
{
    public bool canMove = true;

    private bool onMove = false;

    private Vector3 oldPosition;
    private Vector3 newPosition;

    public float Speed = 0.1f;
    public float fractionOfWay = 0.1f;

    private void Update()
    {
        if (onMove)
        {
            fractionOfWay += Speed;
            transform.position = Vector3.Lerp(oldPosition,
                newPosition, fractionOfWay);
        }
    }

    public void Move(float x, float z)
    {
        if (canMove)
        {
            var position = transform.position;
            oldPosition = new Vector3(position.x, 0, position.z);
            newPosition = new Vector3(x, 0, z);
            onMove = true;
        }
    }
}