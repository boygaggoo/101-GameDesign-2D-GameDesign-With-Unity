using UnityEngine;
using System.Collections;

public class Controls : MonoBehaviour {
	public float speed = 1F;
	Vector2 differenceVector, touchPositionTarget;

	void Start() {
		touchPositionTarget.x = transform.position.x;
		touchPositionTarget.y = transform.position.y;
	}

	void Update() {
		if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Stationary) {
		
		//first we get the touch position (2D vector)
		    touchPositionTarget = Input.GetTouch(0).position;
	  //This actually gives screen coordinates, we want the world coords
	  		Vector3 realWorldPos = Camera.main.ScreenToWorldPoint(touchPositionTarget);
	  
	  //World coordinates have a Z, we're 2D, so we just borrow the x and the y
	  		touchPositionTarget.x = realWorldPos.x;
	  		touchPositionTarget.y = realWorldPos.y;
	  		
	  //MoveTowards, we want to have the position move towards that point
	  //Comment the following line out if you want to have the player seek the point even after release
	  		transform.position = Vector2.MoveTowards( transform.position, touchPositionTarget, speed * Time.deltaTime);
		}
    // Uncomment the following line if you want the player to seek that point after release.
		//transform.position = Vector2.MoveTowards( transform.position, touchPositionTarget, speed * Time.deltaTime);
	}
}

