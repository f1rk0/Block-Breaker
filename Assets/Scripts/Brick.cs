using UnityEngine;
using System.Collections;

public class Brick : MonoBehaviour {

	public int maxHits;
	public static int brickCount = 0;
	public int hitBrick;
	public Sprite[] hitSprites;
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
	void OnCollisionEnter2D (Collision2D collision){					
		if (isBreakable) {
			HandleHits();
		}
	}
	
	void HandleHits(){
		if (--maxHits <= 0 ) {
			brickCount--; 
			levelManager.BrickDestroyed();
			Destroy(gameObject);
		}
		else {LoadSprites ();}
	}
	
	void LoadSprites (){
		int spriteIndex = hitBrick++;
		this.GetComponent<SpriteRenderer>().sprite = hitSprites[spriteIndex];
	}
	
	// TODO Remove method once bricks will be destructable
	void SimulateWin(){
		levelManager.LoadNextLevel();
	}
	// Update is called once per frame
	void Update () {
	
	}
}
