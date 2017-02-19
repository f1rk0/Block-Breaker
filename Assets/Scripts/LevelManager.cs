using UnityEngine;
using System.Collections;

public class LevelManager : MonoBehaviour {

	public void LoadLevel(string name){
		Brick.brickCount = 0;
		Debug.Log("Level going" + name);
		Application.LoadLevel(name);
	}
	
	public void Quit(){
		Debug.Log("Level quit");
		Application.Quit();
	}
	
	public void BrickDestroyed(){
		if (Brick.brickCount <= 0){
			LoadNextLevel();
		}
	}
	
	public void LoadNextLevel(){
		Brick.brickCount = 0;
		Application.LoadLevel(Application.loadedLevel + 1);
	}
}
