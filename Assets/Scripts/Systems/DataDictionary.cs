using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class DataDictionary
{
    private static DataDictionary instance;
    public static DataDictionary Instance()
    {
        if (instance == null)
        {
            instance = new DataDictionary();
            instance.AvartarDict.Clear();
            instance.ColorDict.Clear();
            instance.isDicted = false;
        }

        return instance;
    }

    public bool isDicted; // 할당 여부 확인. [Dicted라는 영어는 없다, 그냥 Dictionary화 했는지에 대한 여부]

    // 캐릭터 외형(아바타) 사전
    private Dictionary<int, Avartar> AvartarDict = new Dictionary<int, Avartar>();
    public Avartar GetAvartar(int key) { return AvartarDict[key]; }
    public int GetAvartarListLength() { return AvartarDict.Count; }
    public void AddAvartar(int key, Avartar _avatar) { AvartarDict.Add(key, _avatar); }

    // 캐릭터 색상 사전
    private Dictionary<int, Color> ColorDict = new Dictionary<int, Color>();
    public Color GetColor(int key) { return ColorDict[key]; }
    public int GetColorListLength() { return ColorDict.Count; }
    public void AddColor(int key, Color _color) { ColorDict.Add(key, _color); }
}