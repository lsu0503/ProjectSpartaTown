#nullable enable
using UnityEngine;

public class DialogListener : MonoBehaviour
{
    [SerializeField] private Controller controller;
    [SerializeField] private DialogContainer? dialogContainer;

    private void Start()
    {
        controller.OnInteractionEvent += DoDialog;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("NPC"))
        {
            DialogContainer? container = collision.gameObject.GetComponent<DialogContainer>();
            if (!ReferenceEquals(container, dialogContainer))
            {
                dialogContainer = container;
                GameManager.instance.SetInteractionTarget(collision.gameObject);
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        DialogContainer? container = collision.gameObject.GetComponent<DialogContainer>();
        if (ReferenceEquals(container, dialogContainer))
        {
            dialogContainer = null;
            GameManager.instance.ClearInteractionTarget();
        }
    }

    private void DoDialog()
    {
        if(dialogContainer != null)
        {
            dialogContainer.DoDialog();
        }
    }
}