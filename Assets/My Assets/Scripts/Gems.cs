using System.Collections;
using System.Collections.Generic;
using UnityEngine;

///<summary>Collectables system for player to pick up and unlock</summary>
public class Gems : MonoBehaviour {
	private static int coins = 0;

	private static GameObject portal;

	///<summary>Function to open the portal</summary>
	private void openPortal() {
		GameObject portal = GameObject.FindGameObjectWithTag("Portal");
		portal.GetComponent<SpriteRenderer>().enabled = true;
		portal.GetComponentInChildren<CircleCollider2D>().enabled = true;
		Debug.Log("Portal is enabled");
	}

	void Awake() {
		Gems.coins++;
	}

	void OnTriggerEnter2D (Collider2D col) {
		if (col.tag == "Player") {
			GameObject.Destroy(gameObject);
		}
	}

	void OnDestroy() {
		Gems.coins--;
		Debug.Log("Coin collected: " + Gems.coins);
		if (Gems.coins <= 0) {
			Debug.Log("All coins collected");
			// GameObject portal = GameObject.FindGameObjectWithTag("Portal");
			// portal.GetComponent<SpriteRenderer>().enabled = true;
			// portal.GetComponentInChildren<CircleCollider2D>().enabled = true;
			// Debug.Log("Portal is enabled");
			openPortal();
		}
	}
}
