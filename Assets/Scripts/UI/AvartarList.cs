using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class AvartarList:MonoBehaviour
{
    [SerializeField] private List<AvartarListSlot> avatarPool = new List<AvartarListSlot>();
    private GameObject content;
    private RectTransform contentTransform;

    [SerializeField] private Character player;
    private int firstSlot;
    private int lastSlot;

    private void Awake()
    {
        content = transform.GetChild(0).gameObject.transform.GetChild(0).gameObject;
        contentTransform = content.transform.GetComponent<RectTransform>();
    }

    private void Start()
    {
        int currentSlot = player.avatar.GetID();

        firstSlot = currentSlot - 4;
        if (firstSlot < 0)
            firstSlot += DataDictionary.Instance().GetAvartarListLength();

        lastSlot = currentSlot + 4;
        if (lastSlot >= DataDictionary.Instance().GetAvartarListLength())
            lastSlot -= DataDictionary.Instance().GetAvartarListLength();

        avatarPool.Clear();
        for(int i = 0; i < avatarPool.Count; i++)
        {
            int tempSlot = firstSlot + i;
            if (tempSlot >= DataDictionary.Instance().GetAvartarListLength())
                tempSlot -= DataDictionary.Instance().GetAvartarListLength();

            avatarPool[i].SetSlot(DataDictionary.Instance().GetAvartar(tempSlot), tempSlot);
        }

        contentTransform.anchoredPosition = Vector2.zero;
    }

    private void Update()
    {
        if(contentTransform.anchoredPosition.x <= -100.0f)
        {
            firstSlot++;
            AvartarListSlot temp = avatarPool[0];
            avatarPool.RemoveAt(0);

            lastSlot++;
            if (lastSlot >= DataDictionary.Instance().GetAvartarListLength())
                lastSlot -= DataDictionary.Instance().GetAvartarListLength();

            temp.SetSlot(DataDictionary.Instance().GetAvartar(lastSlot), lastSlot);
            avatarPool.Add(temp);

            contentTransform.anchoredPosition = new Vector2(contentTransform.anchoredPosition.x + 90.0f, contentTransform.anchoredPosition.y);
        }

        else if(contentTransform.anchoredPosition.x >= 100.0f)
        {
            lastSlot--;
            
            AvartarListSlot temp = avatarPool[avatarPool.Count - 1];
            avatarPool.RemoveAt(avatarPool.Count - 1);

            firstSlot--;
            if (firstSlot < 0)
                firstSlot += DataDictionary.Instance().GetAvartarListLength();

            temp.SetSlot(DataDictionary.Instance().GetAvartar(firstSlot), firstSlot);
            avatarPool.Add(temp);

            contentTransform.anchoredPosition = new Vector2(contentTransform.anchoredPosition.x - 90.0f, contentTransform.anchoredPosition.y);
        }
    }
}