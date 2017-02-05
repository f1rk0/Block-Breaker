using UnityEngine;
using System.Collections;

public class Brick : MonoBehaviour {

	public int maxHits;
	public int hitBrick;
	public Sprite[] hitSprites;
	
	private LevelManager levelManager;
	// Use this for initialization
	void Start () {
		levelManager = GameObject.FindObjectOfType<LevelManager>();	
	}
	void OnCollisionEnter2D (Collision2D collision){				
		bool isBreakable = (this.tag == "Breakable");
		if (isBreakable) {
			HandleHits();
		}
	}
	
	void HandleHits(){
		if (--maxHits <= 0 ) {Destroy(gameObject);}
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
