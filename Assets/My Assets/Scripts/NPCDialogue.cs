using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCDialogue : MonoBehaviour {

	public CanvasGroup canvasgroup;

	public float rate = 0.01f;

	// Use this for initialization
	void Awake () {
		canvasgroup.alpha = 0;
	}
	void OnTriggerEnter2D (Collider2D other) {
		print("Entered");
		print(other.gameObject.tag);
        if (!other.gameObject.CompareTag("Player")) return;

		canvasgroup.alpha = 1;
    }

	void OnTriggerExit2D (Collider2D other) {
		print("Exited");
        if (!other.gameObject.CompareTag("Player")) return;

		canvasgroup.alpha = 0;
    }
}
