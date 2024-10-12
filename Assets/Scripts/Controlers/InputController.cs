using UnityEngine;
using UnityEngine.InputSystem;

public class InputController : Controller
{
    private Camera gameCamera;

    private void Awake()
    {
        gameCamera = Camera.main;
    }

    public void OnMove(InputValue value)
    {
        Vector2 moveInput = value.Get<Vector2>().normalized;

        CallMoveEvent(moveInput);
    }

    public void OnLook(InputValue value)
    {
        Vector2 mousePos = value.Get<Vector2>();
        Vector2 worldPos = gameCamera.ScreenToWorldPoint(mousePos);
        Vector2 relativePos = worldPos - (Vector2)transform.position;

        CallLookEvent(relativePos);
    }

    public void OnInteract()
    {
        CallInteractionEvent();
    }
}
