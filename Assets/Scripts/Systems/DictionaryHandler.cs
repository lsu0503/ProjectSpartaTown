using System.Collections.Generic;
using UnityEngine;

public class DictionaryHandler : MonoBehaviour
{
    [SerializeField] private List<Avartar> avatarList = new List<Avartar>();
    [SerializeField] private List<Color> colorList = new List<Color>();

    private void Awake()
    {
        DataDictionary dataDictionary = DataDictionary.Instance();

        if (!dataDictionary.isDicted)
        {
            for (int i = 0; i < avatarList.Count; i++)
                dataDictionary.AddAvartar(avatarList[i].GetID(), avatarList[i]);

            for (int i = 0; i < colorList.Count; i++)
                dataDictionary.AddColor(i, colorList[i]);

            dataDictionary.isDicted = true;
        }

        Destroy(this.gameObject);
    }
}