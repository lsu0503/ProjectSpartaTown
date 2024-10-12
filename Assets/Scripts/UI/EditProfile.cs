using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EditProfile: MonoBehaviour
{
    [SerializeField] DataContainer? playerData;
    [SerializeField] AvatarHandler avatarHandler;
    [SerializeField] List<AvartarListSlot> avatarListSlots = new List<AvartarListSlot>();
    [SerializeField] List<ColorListSlot> colorListSlots = new List<ColorListSlot>();

    [SerializeField] private Character tempCharacter;
    [SerializeField] private bool isInGame;

    private Image imageCharacter;

    private TMP_InputField nameInputSpace;

    private void Awake()
    {
        imageCharacter = transform.GetChild(0).GetComponent<Image>();
        nameInputSpace = transform.GetChild(1).gameObject.transform.GetChild(1).GetComponent<TMP_InputField>();
    }

    private void Start()
    {
        tempCharacter = new Character();

        InitUI();

        for (int i = 0; i < avatarListSlots.Count; i++)
            avatarListSlots[i].tempCharacter = tempCharacter;

        for (int i = 0; i < colorListSlots.Count; i++)
        {
            colorListSlots[i].UIClass = this;
            colorListSlots[i].tempCharacter = tempCharacter;
        }
    }

    private void OnEnable()
    {
        GameManager gameManager = GameManager.instance;
        if (gameManager != null)
            gameManager.canMove = false;
        InitUI();
    }

    private void OnDisable()
    {
        GameManager gameManager = GameManager.instance;
        if (gameManager != null)
            gameManager.canMove = true;
    }

    private void Update()
    {
        imageCharacter.color = tempCharacter.avatarColor;
        imageCharacter.sprite = tempCharacter.avatar.GetIdleSprite();
    }

    public void InitUI()
    {
        if (playerData != null)
        {
            tempCharacter.SetName(playerData.GetCharacter().name);
            tempCharacter.SetAvartar(playerData.GetCharacter().avatar.GetID());
            tempCharacter.SetColor(playerData.GetCharacter().colorIndex);
        }

        else
        {
            tempCharacter.SetName("----------");
            tempCharacter.SetAvartar(0);
            tempCharacter.SetColor(0);
        }

        nameInputSpace.text = tempCharacter.name;
    }

    public void InputName() { tempCharacter.SetName(nameInputSpace.text); }

    public void ButtonOK()
    {
        InputName();

        if (isInGame)
        {
            playerData.GetCharacter().SetName(tempCharacter.name);
            playerData.GetCharacter().SetAvartar(tempCharacter.avatar.GetID());
            playerData.GetCharacter().SetColor(tempCharacter.colorIndex);

            avatarHandler.UpdateAvarter();
        }

        else
        {
            DataManager.Instance().playerTemp = tempCharacter;
            SceneManager.LoadScene("MainScene");
        }

        this.gameObject.SetActive(false);
    }

    public void ButtonOff()
    {
        this.gameObject.SetActive(false);
    }
}
