using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOver: MonoBehaviour {
	public Text highScoreUI;
	public ScoreController score;
	void Update() {
		highScoreUI.text = DataClass.highScore.ToString();
		if(Input.GetMouseButtonDown( 0 )) {
			SceneManager.LoadScene( SceneManager.GetActiveScene().buildIndex );
		}
	}
}
