using UnityEngine;

public class DataContainer : MonoBehaviour
{
    [SerializeField] protected Character character;

    public Character GetCharacter() { return character; }
    public void SetCharacter(Character _character)
    {
        character = _character;
    }
}
