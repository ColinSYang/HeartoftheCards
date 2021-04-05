﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
    public float moveSpeed = 10f;
    public float dashSpeed = 50f;
    public float dashCooldown = 3f;

    CharacterController controller;
    Vector3 input, moveDirection;
    bool canDash = true;
    bool dashing = false;
    float dashTime = 0.15f;
    float dashTimer = 0f;

    float y;

    // Start is called before the first frame update
    void Start() {
        controller = GetComponent<CharacterController>();
        y = transform.position.y;
    }

    // Update is called once per frame
    void Update() {
        transform.position.Set(transform.position.x, y, transform.position.z);
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        if (!canDash && !dashing)
        {
            dashTimer += Time.deltaTime;
            DashCooldown.UpdateCooldown(dashTimer, dashCooldown);
            if (dashTimer >= dashCooldown)
            {
                canDash = true;
                dashTimer = 0f;
            }
        }

        input = (transform.right * moveHorizontal + transform.forward * moveVertical).normalized;
        if (Input.GetKeyDown(KeyCode.R) && canDash)
        {
            canDash = false;
            dashing = true;
        }

        if (dashing)
        {
            input *= dashSpeed;
            dashTimer += Time.deltaTime;
            if (dashTimer >= dashTime)
            {
                dashing = false;
                dashTimer = 0f;
            }
        }
        else
        {
            input *= moveSpeed;
        }

        input.y = moveDirection.y;
        moveDirection = Vector3.Lerp(moveDirection, input, Time.deltaTime);

        controller.Move(input * Time.deltaTime);

        /*
        input = (transform.right * moveHorizontal + transform.forward * moveVertical).normalized;
        input *= moveSpeed;
        input.y = moveDirection.y;
        moveDirection = Vector3.Lerp(moveDirection, input, Time.deltaTime);

        controller.Move(input * Time.deltaTime);
        */
    }
}
