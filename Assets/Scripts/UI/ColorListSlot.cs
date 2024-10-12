using UnityEngine;
using UnityEngine.UI;

public class ColorListSlot : MonoBehaviour
{
    private Image image;
    private GameObject cursor;

    public Character tempCharacter;
    public EditProfile UIClass;

    private Color color;
    [SerializeField] private int slotNum;

    private void Awake()
    {
        image = transform.GetChild(2).GetComponent<Image>();
        cursor = transform.GetChild(0).gameObject;
    }

    private void Start()
    {
        color = DataDictionary.Instance().GetColor(slotNum);
        image.color = color;
    }

    private void Update()
    {
        if (tempCharacter.colorIndex == slotNum)
            SetCursor(true);
        else
            SetCursor(false);
    }

    public void SetCursor(bool isCurrent)
    {
        cursor.SetActive(isCurrent);
    }

    public void ButtonAction()
    {
        tempCharacter.SetColor(slotNum);
    }

    public void SetGameObjectActive(bool isActive)
    {
        gameObject.SetActive(isActive);
    }
}