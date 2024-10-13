using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public GameObject playerObj;
    public bool canMove;
    [SerializeField] private CharacterListUI characterListUI;

    [SerializeField] private Dictionary<int, Field> fields = new Dictionary<int, Field>();

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }

        else
            Destroy(this.gameObject);
    }

    private void Start()
    {
        canMove = true;

        playerObj.GetComponent<DataContainer>().SetCharacter(DataManager.Instance().playerTemp);
        playerObj.GetComponent<AvatarHandler>().UpdateAvarter();
    }

    public void AddField(Field field)
    {
        fields.Add(field.GetID(), field);
    }

    public void SelectCurrentField(int fieldID)
    {
        if (fieldID >= 0)
        {
            for (int i = 0; i < fields.Count; i++)
            {
                if (fields[i].GetID() == fieldID)
                    fields[i].SetActiveField(true);
                else
                    fields[i].SetActiveField(false);
            }
        }
        else
            for(int i = 0; i < fields.Count; i++)
                fields[i].SetActiveField(true);
    }

    public void AddCharacterToCharacterList(Character character)
    {
        characterListUI.AddCharacterToCharacterList(character);
    }

    public void RemoveCharacterFromCharacterList(Character character)
    {
        characterListUI.RemoveCharacterFromCharacterList(character);
    }
}
