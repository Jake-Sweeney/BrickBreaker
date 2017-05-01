using UnityEngine;
using System.Collections;

public class Brick : MonoBehaviour {

	public Sprite[] hitSprites;
	public static int breakableCount = 0;
	public GameObject smoke;

	private LevelManager levelManager;
	private AudioClip audioClip;
	private int timesHit;
	private bool isBreakable;

	// Use this for initialization
	void Start () {
		isBreakable = (this.tag == "Breakable");
		if(isBreakable) {
			breakableCount++;
		}
		levelManager = GameObject.FindObjectOfType<LevelManager>();
		AudioSource audioSource = GetComponent<AudioSource>();
		audioClip = audioSource.clip;
		timesHit = 0;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnCollisionEnter2D(Collision2D collision) {
		AudioSource.PlayClipAtPoint(audioClip, transform.position, 1.0f);
		if(isBreakable) {
			handleHits ();
		}
	}

	void handleHits() {
		timesHit++;
		int maxHits = hitSprites.Length+1;
		if(timesHit >= maxHits) {
			breakableCount--;
			levelManager.brickDestroyed ();
			GameObject smokePuff = (GameObject) Instantiate (smoke, gameObject.transform.position, Quaternion.identity);
			smokePuff.GetComponent<ParticleSystem>().startColor = gameObject.GetComponent<SpriteRenderer>().color;
			Destroy (gameObject);
		} else {
			loadSprites();
		}
	}

	void loadSprites() {
		int spriteIndex = timesHit - 1;
		if(hitSprites[spriteIndex]) {
			this.GetComponent<SpriteRenderer>().sprite = hitSprites[spriteIndex];
		} else {
			Debug.LogError ("Brick Sprite Missing");
		}
	}
}
