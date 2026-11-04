using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.U2D;

public class Spaceshooter_Player : MovableObject
{
    [SerializeField] Rigidbody2D rb;
    [SerializeField] HealthSystem healthSystem;
    [SerializeField] float moveSpeed;
    [SerializeField] Vector2 movement;

    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
    }

    // Update is called once per frame
    void Update()
    {
        rb.linearVelocity = movement * moveSpeed;
    }

    public void Move(InputAction.CallbackContext context)
    {
        movement = context.ReadValue<Vector2>();
    }
}
