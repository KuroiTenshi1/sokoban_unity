using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SideDetector : Triggerable
{

    public enum Side
    {
        Top,
        Bot,
        Left,
        Right
    }

    public float timeToPush = 2f;
    private float _pushTime = 0f;

    private float _angleMin;
    private float _angleMax;

    private float _x;
    private float _z;
    
    public Side cubeSide;

    private void Start()
    {
        switch (cubeSide)
        {
            case Side.Top:
                _angleMin = 170;
                _angleMax = 190;
                _x = 0;
                _z = 1;
                break;
            case Side.Bot:
                _angleMin = 350;
                _angleMax = 10;
                _x = 0;
                _z = -1;
                break;

            case Side.Left:
                _angleMin = 80;
                _angleMax = 100;
                _x = 1;
                _z = 0;
                break;
            case Side.Right:
                _angleMin = 260;
                _angleMax = 280;
                _x = 1;
                _z = 0;
                break;
        }
    }

    protected override void PlayerStay(Collider other, Player player)
    {
        var playerScript = player.GetComponent<Player>();
        Debug.Log("collide");
        if (playerScript.isOnMovement)
            if (playerScript.angle >= _angleMin && playerScript.angle <= _angleMax)
                _pushTime += Time.deltaTime;
            else
                _pushTime = 0f;
        else
            _pushTime = 0f;
        if (timeToPush <= _pushTime)
        {
            GetComponentInParent<MoveCube>().Move(_x, _z);
            _pushTime = 0;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Wall"))
        {
            if (Enum.TryParse(other.gameObject.name, out cubeSide))
            {
                GetComponentInParent<MoveCube>().canMove = false;
            }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Wall"))
        {
            if (Enum.TryParse(other.gameObject.name, out cubeSide))
            {
                GetComponentInParent<MoveCube>().canMove = false;
            }
        }
    }
}