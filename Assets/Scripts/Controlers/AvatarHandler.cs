using System;
using UnityEngine;

public class AvatarHandler : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    private Animator animator;
    private AnimatorOverrideController overrideAnimator;
    private DataContainer dataContainer;

    private void Awake()
    {
        spriteRenderer = transform.GetChild(0).GetComponent<SpriteRenderer>();
        animator = GetComponentInChildren<Animator>();
        overrideAnimator = animator.runtimeAnimatorController as AnimatorOverrideController;
        dataContainer = GetComponent<DataContainer>();
    }

    //private void Start()
    //{
    //    UpdateAvarter();
    //}

    public void UpdateAvarter()
    {
        spriteRenderer.color = dataContainer.GetCharacter().avatarColor;
        spriteRenderer.sprite = dataContainer.GetCharacter().avatar.GetIdleSprite();

        animator.runtimeAnimatorController = dataContainer.GetCharacter().avatar.GetAnimator();
    }
}