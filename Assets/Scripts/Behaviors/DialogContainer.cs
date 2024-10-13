using System.Collections.Generic;
using UnityEngine;

public class DialogContainer : MonoBehaviour
{
    [SerializeField] private DialogDisplayer displayer;
    [SerializeField] private List<string> scriptList = new List<string>();

    public void DoDialog()
    {
        int curScriptIdx = Random.Range(0, scriptList.Count);

        displayer.SetDialog(scriptList[curScriptIdx]);
    }
}
