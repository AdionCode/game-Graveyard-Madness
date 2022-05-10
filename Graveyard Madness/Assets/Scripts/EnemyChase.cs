using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyChase : MonoBehaviour
{
    public float moveSpeed;
    public float stoppingDistance;

    private Transform target;

    bool isFacingRight;
    Vector2 xPos;
    Vector2 lastPos;

    public bool isAttackRange;

    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    void Update()
    {
        isAttackRange = Vector2.Distance(transform.position, target.position) > stoppingDistance;
        // Mengejar player dari jarak saat ini ke jarak player
        if (isAttackRange)
        {
            transform.position = Vector2.MoveTowards(transform.position, target.position, moveSpeed * Time.deltaTime);
        }

        if (isFacingRight && target.position.x < transform.position.x)
        {
            flip();
        }
        else if (!isFacingRight && target.position.x > transform.position.x)
        {
            flip();
        }
    }

    void flip()
    {
        isFacingRight = !isFacingRight;
        Vector3 scaler = transform.localScale;
        scaler.x *= -1;
        transform.localScale = scaler;
    }
}
