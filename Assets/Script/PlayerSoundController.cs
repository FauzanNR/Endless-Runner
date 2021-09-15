using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSoundController: MonoBehaviour {

	private AudioSource audioSound;
	private PlayerMovementController getJumpState;

	void Start() {
		audioSound = GetComponent<AudioSource>();
	}
	public void jumpSound(bool play) {
		if(play) audioSound.Play();
	}
}
