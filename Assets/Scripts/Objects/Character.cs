using System;
using Unity.VisualScripting;
using UnityEngine;

[Serializable]
public class Character
{
    public string name;
    public Avartar avatar;
    public int colorIndex;
    public Color avatarColor;

    public void SetName(string _name)
    {
        this.name = _name;
    }

    public void SetAvartar(int _avatarID)
    {
        avatar = DataDictionary.Instance().GetAvartar(_avatarID);
    }

    public void SetColor(int index)
    {
        colorIndex = index;
        avatarColor = DataDictionary.Instance().GetColor(index);
    }
}
