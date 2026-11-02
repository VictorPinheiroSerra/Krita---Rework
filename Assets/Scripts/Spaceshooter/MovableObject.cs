using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class MovableObject : MonoBehaviour
{
    [SerializeField] SpriteRenderer spriteRenderer;
    protected Vector2 screenBounds;
    protected Vector2 objectBounds;

    // Start is called before the first frame update
    protected virtual void Start()
    {
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height));
        objectBounds = spriteRenderer.bounds.extents;
    }

    private void LateUpdate()
    {
        float clampX = Mathf.Clamp(transform.position.x, -screenBounds.x + objectBounds.x, screenBounds.x - objectBounds.x);
        float clampY = Mathf.Clamp(transform.position.y, -screenBounds.y + objectBounds.y, screenBounds.y - objectBounds.y);

        transform.position = new Vector2(clampX, clampY);
    }
}
