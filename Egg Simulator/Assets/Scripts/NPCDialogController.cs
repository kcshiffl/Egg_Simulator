using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCDialogController : MonoBehaviour
{
    public GameObject dialog;
    private string text = "absdfbaiusbtfuiowebuiotbaweuitbweioabtioweabtoiwebtioabwioetbawioetbiowe";

    // Start is called before the first frame update
    void Start() {
        
    }

    // Update is called once per frame
    void Update() {
        
    }

    public void playScript() {
        dialog.GetComponent<DialogController>().startDialog(text);
    }
}
