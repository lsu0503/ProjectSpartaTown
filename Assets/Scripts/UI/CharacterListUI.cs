using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CharacterListUI : MonoBehaviour
{
    public List<Character> characterList = new List<Character>();
    [SerializeField] private GameObject nameLinePrf;
    private List<CharacterListIndUI> nameLines = new List<CharacterListIndUI>();

    public void AddCharacterToCharacterList(Character character)
    {
        if (!characterList.Exists(id => ReferenceEquals(character, id)))
        {
            characterList.Add(character);

            CharacterListIndUI temp = Instantiate(nameLinePrf, this.transform).GetComponent<CharacterListIndUI>();
            temp.SetCharacter(character);
            nameLines.Add(temp);
        }
    }

    public void RemoveCharacterFromCharacterList(Character character)
    {
        int targetIdx = characterList.FindIndex(id => ReferenceEquals(character, id));

        if (targetIdx > 0)
        {
            nameLines[targetIdx].RemoveLine();
            nameLines.RemoveAt(targetIdx);
            characterList.RemoveAt(targetIdx);
        }
    }
}
