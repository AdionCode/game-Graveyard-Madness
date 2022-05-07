using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 2f;
    private Vector2 xPos;
    bool isFacingRight;

    void Start()
    {

    }

    void Update()
    {
        transform.Translate(new Vector2(xPos.x * Time.deltaTime * moveSpeed, 0f));
        if (isFacingRight && xPos.x > 0)
        {
            flip();
        } else if (!isFacingRight && xPos.x < 0)
        {
            flip();
        }
    }

    public void Move(InputAction.CallbackContext context)
    {
        xPos = context.ReadValue<Vector2>();
    }

    void flip()
    {
        isFacingRight = !isFacingRight;
        Vector3 scaler = transform.localScale;
        scaler.x *= -1;
        transform.localScale = scaler;
    }

}
