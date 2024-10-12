using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public GameObject playerObj;
    public bool canMove;

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
}
