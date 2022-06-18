using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class DialogController : MonoBehaviour
{
    public GameObject player;
    private bool finishedDialog = true;
    private string text = "";

    public bool isInDialog = false;
    public List<AudioClip> audioOptions;
    private AudioSource audio;

    // Update is called once per frame
    void Update() {
        if (finishedDialog && Input.GetKeyDown(KeyCode.Return)) {
            closeDialog();
        }
    }

    public void startDialog(string text) {
        isInDialog = true;
        player.GetComponent<PlayerMovement>().disableMovement();
        this.text = text;
        resetText();
        gameObject.SetActive(true);
        StartCoroutine(delay(text));
    }

    private void closeDialog() {
        gameObject.SetActive(false);
        resetText();
        player.GetComponent<PlayerMovement>().enableMovement();
        isInDialog = false;
    }

    private IEnumerator delay(string text) {
        for (int i = 0; i < text.Length; i++) {
            gameObject.GetComponent<UnityEngine.UI.Text>().text += text[i];
            finishedDialog = false;
            yield return new WaitForSeconds(0.02f);
            playSoundEffect();
        }
        finishedDialog = true;
    }

    private void resetText() {
        gameObject.GetComponent<UnityEngine.UI.Text>().text = "";
    }

    private void playSoundEffect() {
        audio = GetComponent<AudioSource>();
        audio.clip = audioOptions[1];
        audio.Play();
    }
}
