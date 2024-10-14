using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMove : MonoBehaviour
{
    private Controller controller;
    private Rigidbody2D rigid;

    private Vector2 moveDir = Vector2.zero;
    private float velocity = 5;

    private void Awake()
    {
        controller = GetComponent<Controller>();
        rigid = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        controller.OnMoveEvent += Move;
    }

    private void Move(Vector2 direction)
    {
        moveDir = direction;
    }

    private void FixedUpdate()
    {
        ApplyMove(moveDir);
    }

    private void ApplyMove(Vector2 direction)
    {
        if (GameManager.instance.canMove)
        {
            direction = direction * velocity;
            rigid.velocity = direction;
        }

        else
            rigid.velocity = Vector2.zero;
    }
}
