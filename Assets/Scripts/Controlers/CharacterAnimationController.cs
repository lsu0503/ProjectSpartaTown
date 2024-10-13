using System;
using UnityEngine;

public class CharacterAnimationController : AnimationController
{
    private static readonly int isRun = Animator.StringToHash("isRun");
    private static readonly int runDirection = Animator.StringToHash("runDirection");
    private readonly float magnituteThreshold = 0.5f;

    private SpriteRenderer spriteRenderer;
    private bool isFlipX;

    protected override void Awake()
    {
        base.Awake();
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
    }

    private void Start()
    {
        controller.OnMoveEvent += Move;
        controller.OnLookEvent += Look;
    }

    private void Move(Vector2 vector)
    {
        animator.SetBool(isRun, vector.magnitude > magnituteThreshold);

        if ((vector.x < 0 && !isFlipX) || (vector.x > 0 && isFlipX))
            animator.SetFloat(runDirection, -1.0f);

        else
            animator.SetFloat(runDirection, 1.0f);
    }

    private void Look(Vector2 vector)
    {
        if (vector.x < 0)
            isFlipX = true;

        else
            isFlipX = false;

        spriteRenderer.flipX = isFlipX;
    }
}
