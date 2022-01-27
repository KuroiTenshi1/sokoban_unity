using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public CharacterController controller;

    public float speed = 6f;

    public float turnSmoothTime = 0.1f;

    public bool isOnMovement = false;

    public float angle;

    private float turnSmoothVelocity;

    // Update is called once per frame
    void Update()
    {
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");

        Vector3 direction = new Vector3(moveX, 0f, moveY).normalized;


        if (direction.magnitude >= 0.1f)
        {
            isOnMovement = true;
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg;
            angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity,
                turnSmoothTime);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);
            Debug.Log("angle : " + angle);
            controller.Move(direction * Time.deltaTime * speed);
        }
        else
        {
            isOnMovement = false;
        }
    }
}