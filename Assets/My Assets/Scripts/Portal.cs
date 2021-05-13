using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour {
	public GameObject _portal;

	void Awake() {
		_portal.GetComponentInChildren<SpriteRenderer>().enabled = false;
		_portal.GetComponentInChildren<CircleCollider2D>().enabled = false;
	}
	void Update () {
		if (_portal.GetComponentInChildren<SpriteRenderer>().enabled) {
			_portal.transform.Rotate (new Vector3 (0f, 0f, 3f));
		}
	}

	void OnTriggerEnter2D() {
		print("Teleport!");
	}
}
