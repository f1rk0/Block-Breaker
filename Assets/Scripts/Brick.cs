using UnityEngine;
using System.Collections;

public class Brick : MonoBehaviour {

	
	public AudioClip crack;
	public int maxHits;
	public static int brickCount = 0;
	public int hitBrick;
	public Sprite[] hitSprites;
	public GameObject smoke;
	private bool isBreakable;
	
	private LevelManager levelManager;
	// Use this for initialization
	void Start () {
		isBreakable = (this.tag == "Breakable");
		//Keep track of breakable bricks
		if (isBreakable) {
			brickCount++;
		}
		levelManager = GameObject.FindObjectOfType<LevelManager>();	
	}
	public void OnCollisionEnter2D (Collision2D collision){
		AudioSource.PlayClipAtPoint (crack, transform.position, 0.5f);					
		if (isBreakable) {
			HandleHits();
		}
	}
	
	void HandleHits(){
		if (--maxHits <= 0 ) {
			brickCount--; 
			levelManager.BrickDestroyed();
			PuffSmoke();
			Destroy(gameObject);
		}
		else {LoadSprites ();}
	}
	
	void PuffSmoke(){
		GameObject smokePuff = Instantiate (smoke, transform.position, Quaternion.identity) as GameObject;
		smokePuff.particleSystem.startColor = gameObject.GetComponent<SpriteRenderer>().color;
	}
	
	void LoadSprites (){
		int spriteIndex = hitBrick++;
		this.GetComponent<SpriteRenderer>().sprite = hitSprites[spriteIndex];
	}
	
	// Update is called once per frame
	void Update () {

	}
}
