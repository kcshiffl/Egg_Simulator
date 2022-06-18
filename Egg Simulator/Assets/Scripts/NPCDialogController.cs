using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TextReader;

public class NPCDialogController : MonoBehaviour
{
    public GameObject dialogUI;
    public List<TextAsset> dialogOptions;
    
    public void playScript() {
        dialogUI.GetComponent<DialogController>().startDialog(TextReader.TextReader.readTextFile(dialogOptions[0]));
        if (dialogOptions.Count > 1) {
            dialogOptions.RemoveAt(0);
        }
    }
}
