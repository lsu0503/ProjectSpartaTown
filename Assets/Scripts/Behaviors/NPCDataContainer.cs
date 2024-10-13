using UnityEngine;

public class NPCDataContainer : DataContainer
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Community"))
            GameManager.instance.AddCharacterToCharacterList(character);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Community"))
            GameManager.instance.RemoveCharacterFromCharacterList(character);
    }
}
