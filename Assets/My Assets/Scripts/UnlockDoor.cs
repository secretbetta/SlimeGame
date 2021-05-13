using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnlockDoor : MonoBehaviour {

	public GameObject door;
	public float height = 5f;
	public float speed = 1f;
	// Use this for initialization
	private bool open = false;
	private float currY;

	void Awake() {
		currY = door.transform.position.y;
	}
	
	void OnTriggerEnter2D (Collider2D other) {
		if (!other.gameObject.CompareTag("Player")) return;

		print("Moving door");
		open = true;
		this.gameObject.GetComponent<SpriteRenderer>().enabled = false;
	}

	void Update() {
		if (open) {
			door.transform.position += door.transform.up * speed * Time.deltaTime;
		}
		if (door.transform.position.y > currY + height) {
			open = false;
			GameObject.Destroy(this.gameObject);
		}
	}
}
