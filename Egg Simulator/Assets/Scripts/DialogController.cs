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
    private AudioSource audio;

    // Update is called once per frame
    void Update() {
        if (finishedDialog && Input.GetKeyDown(KeyCode.Return)) {
            closeDialog();
        }
    }

    public void startDialog(string text, AudioClip voice) {
        isInDialog = true;
        player.GetComponent<PlayerMovement>().disableMovement();
        this.text = text;
        resetText();
        gameObject.SetActive(true);
        StartCoroutine(readThroughText(text, voice));
    }

    private void closeDialog() {
        gameObject.SetActive(false);
        resetText();
        player.GetComponent<PlayerMovement>().enableMovement();
        isInDialog = false;
    }

    private IEnumerator readThroughText(string text, AudioClip voice) {
        for (int i = 0; i < text.Length; i++) {
            finishedDialog = false;
            playSoundEffect(voice);
            gameObject.GetComponent<UnityEngine.UI.Text>().text += text[i];
            yield return new WaitForSeconds(0.02f);
        }
        finishedDialog = true;
    }

    private void resetText() {
        gameObject.GetComponent<UnityEngine.UI.Text>().text = "";
    }

    private void playSoundEffect(AudioClip voice) {
        if (audio == null) {
            audio = GetComponent<AudioSource>();
        }
        audio.clip = voice;
        if (!audio.isPlaying) {
            audio.Play();
        }
    }
}
