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
        if (!gameObject.activeSelf)
            gameObject.SetActive(true);

        textMesh.text = dialogText;
        curTime = 0.0f;
        dialogTime = 0.5f  + (0.05f * dialogText.Length);
    }
}