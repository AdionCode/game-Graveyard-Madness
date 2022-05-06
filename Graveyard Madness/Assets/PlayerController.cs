using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 2f;
    private Vector2 xPos;
    bool isFacingRight;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(new Vector2(xPos.x * Time.deltaTime * moveSpeed, 0f));
        if (xPos.x > 0)
        {
            transform.eulerAngles = new Vector3(0f, 180f, 0f);
        }
        else if (xPos.x < 0)
        {
            transform.eulerAngles = new Vector3(0f, 0f, 0f);
        }
    }

    public void Move(InputAction.CallbackContext context)
    {
        xPos = context.ReadValue<Vector2>();
    }

}
