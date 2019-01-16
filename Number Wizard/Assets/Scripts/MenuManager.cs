﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour {

	public void Play(){
		SceneManager.LoadScene ("Game");
	}

	public void Exit(){
		Application.Quit();
	}
	public void Restart(){
		SceneManager.LoadScene ("Menu");
	}
	}