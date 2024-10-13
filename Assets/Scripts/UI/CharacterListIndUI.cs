using TMPro;
using UnityEngine;

public class CharacterListIndUI : MonoBehaviour
{
    private Character character = new Character();
    private TextMeshProUGUI textMesh;

    private void Awake()
    {
        textMesh = GetComponent<TextMeshProUGUI>();
    }

    private void Update()
    {
        textMesh.text = character.name;
    }

    public void SetCharacter(Character _character)
    {
        character = _character;
    }

    public void RemoveLine()
    {
        Destroy(gameObject);
    }
}