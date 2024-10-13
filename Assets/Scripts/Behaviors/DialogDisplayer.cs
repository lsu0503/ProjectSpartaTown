using TMPro;
using UnityEngine;

public class DialogDisplayer : MonoBehaviour
{
    private TextMeshProUGUI textMesh = new TextMeshProUGUI();
    private float dialogTime;
    private float curTime;

    private void Awake()
    {
        textMesh = GetComponent<TextMeshProUGUI>();
    }

    private void FixedUpdate()
    {
        curTime += Time.deltaTime;

        if(curTime > dialogTime)
            gameObject.SetActive(false);
    }

    public void SetDialog(string dialogText)
    {
        textMesh.text = dialogText;
        curTime = 0.0f;
        dialogTime = 0.5f * dialogText.Length;

        if (!gameObject.activeSelf)
            gameObject.SetActive(true);
    }
}