using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 2f;
    private Vector2 xPos;
    bool isFacingRight;
    public Animator animator;
    public Transform playerPos;

    void Start()
    {

    }

    void Update()
    {
        if (playerPos.position.x > 30f)
        {
            playerPos.position = new Vector3(30f, playerPos.position.y, playerPos.position.z);
        }
        else if (playerPos.position.x < -34f)
        {
            playerPos.position = new Vector3(-34f, playerPos.position.y, playerPos.position.z);
        }
        animator.SetFloat("Speed", Mathf.Abs(xPos.x));
        transform.Translate(new Vector2(xPos.x * Time.deltaTime * moveSpeed, 0f));
        if (isFacingRight && xPos.x > 0)
        {
            flip();
        }
        else if (!isFacingRight && xPos.x < 0)
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
