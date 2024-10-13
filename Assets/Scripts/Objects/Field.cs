using UnityEngine;

public class Field : MonoBehaviour
{
    [SerializeField] private int fieldID;

    private void Start()
    {
        GameManager.instance.AddField(this);
    }

    public void SetActiveField(bool isActivate)
    {
        if(gameObject.activeSelf != isActivate)
            gameObject.SetActive(isActivate);
    }

    public int GetID() { return fieldID; }
}
