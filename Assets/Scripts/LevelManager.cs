using UnityEngine;
using System.Collections;

public class LevelManager : MonoBehaviour {

	public void LoadLevel(string name){
		Debug.Log("Level going" + name);
		Application.LoadLevel(name);
	}
	
	public void Quit(){
		Debug.Log("Level quit");
		Application.Quit();
	}
	
	public void LoadNextLevel(){
		Application.LoadLevel(Application.loadedLevel + 1);
	}
	
	public void BrickDestroyed(){
		if (Brick.brickCount <= 0){
			LoadNextLevel();
		}
	}
}
