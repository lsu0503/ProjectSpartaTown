using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class FieldCollider: MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Field"))
        {
            int targetId = other.gameObject.GetComponent<Field>().GetID();
            GameManager.instance.SelectCurrentField(targetId);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Field"))
        {
            GameManager.instance.SelectCurrentField(-1);
        }
    }
}