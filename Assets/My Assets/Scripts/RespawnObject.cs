using System.Collections;
using System.Collections.Generic;
using UnityEngine;

///<summary>Respawns an object at custom location or original location placed</summary>
public class RespawnObject : MonoBehaviour {

	public GameObject respawnee;

	private Vector3 spawnPos;
	public bool customSpawn = false;
	public float spawnX;
	public float spawnY;

	///<summary>Function to determine spawn locaiton</summary>
	private void spawner() {
		if (customSpawn) {
			respawnee.transform.position = new Vector3(spawnX, spawnY);
		} else {
			respawnee.transform.position = new Vector3(spawnPos.x, spawnPos.y);
		}
	}
	void Awake() {
		spawnPos = respawnee.transform.position;
	}
	void OnTriggerEnter2D (Collider2D other) {
		if (!other.gameObject.CompareTag("Player")) return;
		
		spawner();
    }
}
