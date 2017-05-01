using UnityEngine;
using System.Collections;

public class Laser : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnCollisionEnter2D(Collision2D collision) {
		Destroy (gameObject);
	}

	void OnTriggerEnter2D (Collider2D collider) {
		if(collider.tag == "Breakable") {
			Destroy (gameObject);
		}
	}
}
