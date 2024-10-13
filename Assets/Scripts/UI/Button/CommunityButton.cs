using UnityEngine;

public class CommunityButton : MonoBehaviour
{
    public GameObject characterList;

    public void ButtonPush()
    {
        characterList.SetActive(!characterList.activeSelf);
    }
}