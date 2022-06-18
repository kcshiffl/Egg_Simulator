using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogController : MonoBehaviour
{
    private bool finishedDialog = false;
    private string text = "";

    // Update is called once per frame
    void Update() {
        finishedDialog = false;
        if (finishedDialog && Input.GetKeyDown(KeyCode.Return)) {
            closeDialog();
        }
    }

    public void startDialog(string text) {
        this.text = text;
        resetText();
        gameObject.SetActive(true);
        StartCoroutine(delay(text));
    }

    private void closeDialog() {
        gameObject.SetActive(false);
        resetText();
    }

    private IEnumerator delay(string text) {
        for (int i = 0; i < text.Length; i++) {
            gameObject.GetComponent<UnityEngine.UI.Text>().text += text[i];
            finishedDialog = false;
            yield return new WaitForSeconds(0.02f);
        }
        finishedDialog = true;
    }

    private void resetText() {
        gameObject.GetComponent<UnityEngine.UI.Text>().text = "";
    }
}
