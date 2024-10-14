using UnityEngine;

public class NPCDataContainer : DataContainer
{
    private void Start()
    {
        GameManager.instance.AddCharacterToCharacterList(character);
    }

    private void OnDestroy()
    {
        GameManager.instance.RemoveCharacterFromCharacterList(character);
    }
}
