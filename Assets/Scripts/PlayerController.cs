using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerController : MonoBehaviour {

	public float moveSpeed = 15;
	private int FeCount = 0;
	public Text feText;

	public SpriteRenderer flame;
	public SpriteRenderer probe;
	private Rigidbody2D rb2d;

	private Vector2 moveDir;
	private Vector2 upForce;
	private bool grounded;

	void Start()
	{
		rb2d = transform.GetComponent<Rigidbody2D> ();
		SetCountText ();
	}

	void Update () 
	{
		moveDir = new Vector2 (Input.GetAxisRaw ("Horizontal"), 0).normalized;
		upForce = new Vector2 (0, Input.GetAxisRaw ("Vertical")).normalized;

	}

	void OnCollisionEnter2D (Collision2D col)
	{
		if (col.gameObject.name == "Planet") 
		{
			grounded = true;
		} 
		else if (col.gameObject.tag == "Iron") 
		{
			Destroy (col.gameObject);
			FeCount += 1;
			SetCountText ();

		}
	}

	void OnCollisionExit2D (Collision2D col)
	{
		if(col.gameObject.name == "Planet")
		{
			grounded = false;
		}
	}

	void SetCountText ()
	{
		feText.text = FeCount.ToString ();
	}
		
	void FixedUpdate ()
	{

		if (moveDir != new Vector2 (0, 0)) 
		{
			rb2d.angularDrag = 0;
			Vector2 globalmovedir = transform.TransformDirection (moveDir);
			rb2d.AddTorque (-moveDir.x);

			//rb2d.rotation -= moveDir.x;
			//rb2d.position += globalmovedir * moveSpeed * Time.fixedDeltaTime;	
		}
		else
		{
			rb2d.angularDrag = 5;
		}

		if (grounded)
		{
			rb2d.drag = 5;
			rb2d.angularDrag = 0;
		}
		else
		{
			rb2d.drag = 0;
			rb2d.angularDrag = 5;
		}


		if(upForce.y == 1)
		{
			Vector2 globalupforce = transform.TransformDirection (upForce);
			rb2d.AddForce (globalupforce * 6);
			flame.enabled = true;
		}
		else
		{
			flame.enabled = false;
		}
			


		//rb2d.MovePosition (rb2d.position + globalmovedir * moveSpeed * Time.fixedDeltaTime);
	}
}
