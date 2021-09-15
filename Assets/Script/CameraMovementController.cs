using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovementController: MonoBehaviour {

	[Header( "Position" )]
	public Transform playerTransform;
	public float horizontalOffset;

	void Update() {
		Vector3 position = transform.position;
		position.x = playerTransform.position.x + horizontalOffset;
		transform.position = position;
	}

}
