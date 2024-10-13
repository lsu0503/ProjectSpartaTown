using UnityEngine;

public class Field : MonoBehaviour
{
    [SerializeField] private int fieldID;
    private bool isActivated = true;

    private void Start()
    {
        GameManager.instance.FieldActivateEvent += SetActiveField;
    }

    public void SetActiveField(int curFieldID)
    {
        if (curFieldID == fieldID || curFieldID == -1)
        {
            if (!isActivated)
            {
                gameObject.SetActive(true);
                isActivated = true;
            }
        }

        else
        {
            if (isActivated)
            {
                gameObject.SetActive(false);
                isActivated = false;
            }
        }

    }

    public int GetID() { return fieldID; }
}
