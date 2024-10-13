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
            if (container != null)
                dialogContainer = container;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        DialogContainer? container = collision.gameObject.GetComponent<DialogContainer>();
        if (container != null)
            dialogContainer = null;
    }

    private void DoDialog()
    {

    }
}