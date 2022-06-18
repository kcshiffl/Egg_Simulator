using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteraction : MonoBehaviour {
    private GameObject npc;
    public GameObject dialog;

    void Update() {
        RaycastHit objectHit;
        if (Physics.Raycast(transform.position, transform.forward, out objectHit, 3)) {
            npc = objectHit.collider.gameObject;
        } else {
            npc = null;
        }

        if (npc != null && Input.GetKeyDown(KeyCode.Return)) {
            npc.GetComponent<NPCDialogController>().playScript();
        }
    }   
}
