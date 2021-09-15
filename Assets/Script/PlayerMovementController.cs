using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Drawing;

public class PlayerMovementController: MonoBehaviour {

	public float yFall;
	public GameObject overPanel;
	[Header( "Movement" )]
	public float moveAccel;
	public float maxSpeed;
	private Rigidbody2D rigidBody;

	[Header( "Jump" )]
	public float jumpAccel;
	private bool isJumping;
	private bool isOnGround;

	[Header( "Ground RayCast" )]
	public float groundRayCastDistance;
	public LayerMask groundLayerMask;

	private Animator animator;
	private PlayerSoundController soundController;


	[Header( "Scoring" )]
	public ScoreController score;
	public float scoringRatio;
	private float lastPositionX;


	void Start() {
		rigidBody = GetComponent<Rigidbody2D>();
		animator = GetComponent<Animator>();
		soundController = GetComponent<PlayerSoundController>();
		lastPositionX = transform.position.x;
	}

	void Update() {
		if(Input.GetMouseButtonDown( 0 )) {
			if(isOnGround) isJumping = true;
		}
		animator.SetBool( "isOnGround", isOnGround );
		soundController.jumpSound( isJumping );

		int distancePassed = Mathf.FloorToInt( transform.position.x );
		int scoreIncrement = Mathf.FloorToInt( distancePassed / scoringRatio );
		if(scoreIncrement > 0) {
			score.score = scoreIncrement;
			lastPositionX += distancePassed;
		}
		gameOver();
	}

	void FixedUpdate() {

		RaycastHit2D rayhit = Physics2D.Raycast( transform.position, Vector2.down, groundRayCastDistance, groundLayerMask );
		if(rayhit) {
			if(!isOnGround && rigidBody.velocity.y <= 0) isOnGround = true;
		} else {
			isOnGround = false;
		}

		Vector2 bodyVelocity = rigidBody.velocity;
		if(isJumping) {
			bodyVelocity.y += jumpAccel;
			isJumping = false;
		}
		bodyVelocity.x = Mathf.Clamp( rigidBody.velocity.x + moveAccel * Time.deltaTime, 0.0f, maxSpeed );
		rigidBody.velocity = bodyVelocity;
	}

	void gameOver() {
		if(transform.position.y < yFall) {
			overPanel.SetActive( true );
			this.enabled = false;
		}
	}
	void OnDrawGizmos() {
		Debug.DrawLine( transform.position, transform.position + (Vector3.down * groundRayCastDistance), UnityEngine.Color.white );
	}
}
