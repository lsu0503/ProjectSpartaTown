using UnityEngine;
using UnityEngine.UI;

public class AvartarListSlot : MonoBehaviour
{
    private Image image;
    private GameObject cursor;

    public Character tempCharacter;

    private Avartar avatar;
    [SerializeField] private int slotNum;

    public void SetSlot(Avartar _avatar, int _slotNum)
    {
        avatar = _avatar;
        slotNum = _slotNum;
    }

    private void Awake()
    {
        image = transform.GetChild(0).GetComponent<Image>();
        cursor = transform.GetChild(1).gameObject;
    }

    private void Start()
    {
        avatar = DataDictionary.Instance().GetAvartar(slotNum);
        image.sprite = avatar.GetIdleSprite();
        
        SetCursor(false);
    }

    private void Update()
    {
        if (tempCharacter.avatar.GetID() == avatar.GetID())
            SetCursor(true);
        else
            SetCursor(false);
    }

    public void SetCursor(bool isCurrent)
    {
        cursor.SetActive (isCurrent);
    }

    public void ButtonAction()
    {
        tempCharacter.SetAvartar(avatar.GetID());
    }

    public void SetGameObjectActive(bool isActive)
    {
        gameObject.SetActive(isActive);
    }
}