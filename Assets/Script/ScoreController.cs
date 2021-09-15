using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreController: MonoBehaviour {

	[Header( "UI" )]
	public Text scoreUI;

	private int _score;
	public int score {
		get => _score;
		set => _score = value;
	}

	void Start() {
		score = 0;
	}


	void Update() {
		DataClass.highScore = DataClass.highScore < score ? score : DataClass.highScore;
		scoreUI.text = score.ToString();
	}
}
