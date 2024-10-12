using UnityEngine;

public class EditProfileButton : MonoBehaviour
{
    [SerializeField] private GameObject profileEditUI;

    public void ProfileEditUIOn()
    {
        profileEditUI.SetActive(true);
    }
}