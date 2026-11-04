using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spaceshooter_Enemy : MovableObject
{
    [SerializeField] Rigidbody2D rb;
    [Header("----- Enemy Health -----")]
    [SerializeField] int minHealth;
    [SerializeField] int maxHealth;
    [SerializeField] HealthSystem healthSystem;
    [Header("----- Enemy Speed -----")]
    [SerializeField] float minSpeed;
    [SerializeField] float maxSpeed;
    [SerializeField] float moveSpeed;
    [Header("----- Shooting Cooldown -----")]
    [SerializeField] float minCooldown;
    [SerializeField] float maxCooldown;
    [SerializeField] float shootCooldown;
    [SerializeField] float cooldownCount;

    bool goingUp = false;
    protected override void Start()
    {
        base.Start();
        SetRandomStats();
    }

    void SetRandomStats()
    {
        healthSystem.SetHealth((int)Random.Range(minSpeed, maxSpeed));
        moveSpeed = Random.Range(minSpeed, maxSpeed);
        shootCooldown = Random.Range(minCooldown, maxCooldown);
    }

    // Update is called once per frame
    void Update()
    {
        if (goingUp)
        {
            rb.linearVelocity = moveSpeed * Vector2.up;
            if (transform.position.y >= screenBounds.y - objectBounds.y)
                goingUp = false;
        }
        else
            rb.linearVelocity = moveSpeed * Vector2.down;
        if (transform.position.y <= -screenBounds.y + objectBounds.y)
            goingUp = true;


        cooldownCount += Time.deltaTime;
    }
}
