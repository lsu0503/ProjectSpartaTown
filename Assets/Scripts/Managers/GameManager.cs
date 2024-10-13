using System;
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

    public event Action<int> FieldActivateEvent;

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

    public void SelectCurrentField(int fieldID)
    {
        FieldActivateEvent?.Invoke(fieldID);
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
