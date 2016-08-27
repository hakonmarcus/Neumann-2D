using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	public float moveSpeed = 15;
	private Rigidbody2D rb2d;

	private Vector2 moveDir;
	private Vector2 upForce;

	void Start()
	{
		rb2d = transform.GetComponent<Rigidbody2D> ();
	}

	void Update () 
	{
		moveDir = new Vector2 (Input.GetAxisRaw ("Horizontal"), 0).normalized;
		upForce = new Vector2 (0, Input.GetAxisRaw ("Vertical")).normalized;

	}
		
	void FixedUpdate ()
	{
		if (moveDir != new Vector2 (0, 0)) 
		{
			Vector2 globalmovedir = transform.TransformDirection (moveDir);
			rb2d.position += globalmovedir * moveSpeed * Time.fixedDeltaTime;	
		}



		if(upForce.y == 1)
		{
			Vector2 globalupforce = transform.TransformDirection (upForce);
			rb2d.AddForce (globalupforce * 40);
		}

		//rb2d.MovePosition (rb2d.position + globalmovedir * moveSpeed * Time.fixedDeltaTime);
	}
}
