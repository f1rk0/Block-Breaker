using UnityEngine;
using System.Collections;

public class Brick : MonoBehaviour {

	public int maxHits;
	private LevelManager levelManager;
	// Use this for initialization
	void Start () {
		levelManager = GameObject.FindObjectOfType<LevelManager>();	
	}
	void OnCollisionEnter2D (Collision2D collision){				
		if (--maxHits <= 0 ) {Destroy(gameObject);}
	}
	
	// TODO Remove method once bricks will be destructable
	void SimulateWin(){
		levelManager.LoadNextLevel();
	}
	// Update is called once per frame
	void Update () {
	
	}
}
