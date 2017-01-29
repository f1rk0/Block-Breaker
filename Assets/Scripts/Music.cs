﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Music : MonoBehaviour {
	
	static Music instance = null;
	
	void Awake (){

		if (instance != null) {
			Destroy (gameObject);
		} else {
			instance = this;
			GameObject.DontDestroyOnLoad(gameObject);
		}
	}
	
	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
