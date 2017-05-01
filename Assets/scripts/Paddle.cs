using UnityEngine;
using System.Collections;

public class Paddle : MonoBehaviour {

	public bool isAutoPlayChecked = false;
	public bool isLaserPowerUpEnabled = false;
	public float minX;
	public float maxX;

	private Ball ball;
	//private Laser laser;

	public Transform laserOrigin;
	public GameObject laser;

	// Use this for initialization
	void Start () {
		ball = GameObject.FindObjectOfType<Ball>();
	}
	
	// Update is called once per frame
	void Update () {
		if(!isAutoPlayChecked) {
			moveWithMouse();
		} else {
			autoPlay();
		}

		if(Input.GetKeyDown (KeyCode.Mouse1)) {
			GameObject lsrgurl = (GameObject) Instantiate (laser, laserOrigin.transform.position, Quaternion.identity);
		}
	}

	void moveWithMouse() {
		//move paddle in response to mouse
		Vector3 paddlePos = new Vector3(0.5f, this.transform.position.y, 0f);
		float mousePosInBlocks = Input.mousePosition.x / Screen.width * 16;
		paddlePos.x = Mathf.Clamp(mousePosInBlocks, minX, maxX);
		this.transform.position = paddlePos;
	}

	void autoPlay() {
		//this vector represents the position of the paddle
		Vector3 paddlePos = new Vector3(0.5f, this.transform.position.y, 0f);
		//ball pos
		Vector3 ballPos = ball.transform.position;
		//set the x pos of the paddle to the balls X within the bounds
		paddlePos.x = Mathf.Clamp(ballPos.x, minX, maxX);
		//translate the new upated position of paddle 
		this.transform.position = paddlePos;
	}
}