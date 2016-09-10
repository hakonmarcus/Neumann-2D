using UnityEngine;
using System.Collections;

public class GravityAttractor : MonoBehaviour {

	public float gravity;
	public Vector2 gravityUp;

	public void Attract(Transform body)
	{
		gravityUp = (body.position - transform.position).normalized;
		//Vector2 bodyUp = body.up;

		Rigidbody2D rb2d;
		rb2d = body.GetComponent<Rigidbody2D>();

		rb2d.AddForce (gravityUp * gravity);

		//Quaternion targetRotation = Quaternion.FromToRotation (bodyUp, gravityUp) * body.rotation;
		//body.rotation = Quaternion.Slerp (body.rotation, targetRotation, 50 * Time.deltaTime);
	}
}
