using UnityEngine;
using System.Collections;

public class Ball : MonoBehaviour {

	private Rigidbody2D rigidbody2D;
	private Paddle paddle;
	private AudioSource bounce;

	private Vector3 paddleToBallVector;
	private bool gameStarted = false;

	// Use this for initialization
	void Start () {
		rigidbody2D = GetComponent<Rigidbody2D>();
		paddle = GameObject.FindObjectOfType<Paddle>();
		bounce = GetComponent<AudioSource>();
		paddleToBallVector = this.transform.position - paddle.transform.position;
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (!gameStarted) {
			//Lock ball relative to the paddle
			this.transform.position = paddle.transform.position + paddleToBallVector;
			if (Input.GetMouseButtonDown (0)) {
				gameStarted = true;
				rigidbody2D.velocity = new Vector2 (2f, 10f);
			}
		}
	}

	void OnCollisionEnter2D(Collision2D collision) {
		Vector2 tweak = new Vector2 (Random.Range (0.0f, 0.2f), Random.Range (0.0f, 0.2f));
		if(gameStarted) {
			if(collision.gameObject.name == "Paddle"){
				bounce.Play ();
			}
			rigidbody2D.velocity += tweak;
		}
	}
}
