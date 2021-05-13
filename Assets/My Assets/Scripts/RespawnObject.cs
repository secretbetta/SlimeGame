using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnObject : MonoBehaviour {

	public GameObject respawnee;
	// private Transform spawnPos;

	private Vector3 spawnPos;
	public bool customSpawn = false;
	public float spawnX;
	public float spawnY;

	void Awake() {
		spawnPos = respawnee.transform.position;
	}
	void OnTriggerEnter2D (Collider2D other) {
		if (!other.gameObject.CompareTag("Player")) return;
		
		if (customSpawn) {
			respawnee.transform.position = new Vector3(spawnX, spawnY);
		} else {
			respawnee.transform.position = new Vector3(spawnPos.x, spawnPos.y);
		}
    }
}
