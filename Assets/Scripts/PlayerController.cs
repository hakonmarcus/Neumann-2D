using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerController : MonoBehaviour {

	public float moveSpeed = 15;
	private int FeCount = 0;
	private float battery;
	private int batteryMax = 250;
	public Text feText;

	public SpriteRenderer flame;
	public SpriteRenderer probe;
	private Rigidbody2D rb2d;

	private Vector2 moveDir;
	private Vector2 upForce;
	private bool grounded;

	private bool transferring = false;
	private Collider2D triggerpanel;

	void Start()
	{
		rb2d = transform.GetComponent<Rigidbody2D> ();
		SetCountText ();
		battery = batteryMax;
	}

	void Update () 
	{
		moveDir = new Vector2 (Input.GetAxisRaw ("Horizontal"), 0).normalized;
		upForce = new Vector2 (0, Input.GetAxisRaw ("Vertical")).normalized;

		if(Input.GetKey ("down"))
		{
			createSolarPanel ();
		}

	}

	void createSolarPanel()
	{
		
	}

	void OnCollisionEnter2D (Collision2D col)
	{
		if (col.gameObject.name == "Planet") 
		{
			grounded = true;
		} 
		else if (col.gameObject.tag == "Ore") 
		{
            Debug.Log("It's a hit!");
            //Grid.gameController.resourceController.addOre(col.gameObject);
			Grid.gameController.inventoryController.addOre (col.gameObject);
            Destroy(col.gameObject);
        }
	}

	void OnCollisionExit2D (Collision2D col)
	{
		if(col.gameObject.name == "Planet")
		{
			grounded = false;
		}
	}

	void OnTriggerEnter2D (Collider2D col)
	{
		if (col.gameObject.name == "SolarPanel") 
		{
			transferring = true;
			triggerpanel = col;
			Debug.Log("It's a trig!");
		}
			
	}

	void OnTriggerExit2D (Collider2D col)
	{
		if (col.gameObject.name == "SolarPanel") 
		{
			transferring = false;
			triggerpanel = null;
			Debug.Log("Left the trig!");
		}

	}


	void SetCountText ()
	{
		feText.text = FeCount.ToString ();
	}
		
	void FixedUpdate ()
	{
		if (transferring)
		{
			if(triggerpanel.gameObject.GetComponent<Panel> ().charge > 0 && battery < batteryMax)
			{
				triggerpanel.gameObject.GetComponent<Panel> ().charge -= 50 * Time.deltaTime;
				battery += 50 * Time.deltaTime;
				//Debug.Log ("transferring");
			}
			else
			{
				transferring = false;
				triggerpanel = null;
			}

		}

		if (moveDir != new Vector2 (0, 0)) 
		{
			rb2d.angularDrag = 0;
			//Vector2 globalmovedir = transform.TransformDirection (moveDir);
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


		if(upForce.y == 1 && battery > 0)
		{
			Vector2 globalupforce = transform.TransformDirection (upForce);
			rb2d.AddForce (globalupforce * 6);
			flame.enabled = true;
			battery -= 50 * Time.fixedDeltaTime;

			if(battery < 0)
			{
				battery = 0;
			}

			//Debug.Log(battery);

		}
		else
		{
			flame.enabled = false;
		}
			


		//rb2d.MovePosition (rb2d.position + globalmovedir * moveSpeed * Time.fixedDeltaTime);
	}
}
