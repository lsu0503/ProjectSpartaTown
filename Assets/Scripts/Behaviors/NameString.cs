using TMPro;
using UnityEngine;

public class NameString : MonoBehaviour
{
    [SerializeField] private DataContainer container;
    private TextMeshProUGUI nameText;

    private void Awake()
    {
        nameText = GetComponent<TextMeshProUGUI>();
    }

    public void Update()
    {
        nameText.text = container.GetCharacter().name;
    }
}
