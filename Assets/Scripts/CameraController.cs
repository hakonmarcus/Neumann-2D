using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {

	public GameObject player;
	public GameObject planet;

	private Vector3 offset;

	// Use this for initialization
	void Start () 
	{
		offset = transform.position - player.transform.position;
	}

	// Update is called once per frame
	void LateUpdate () 
	{
		transform.position = player.transform.position + offset;

		Vector2 gravityUp = (player.transform.position - planet.transform.position).normalized;
		Vector2 cameraUp = transform.up;

		Quaternion targetRotation = Quaternion.FromToRotation (cameraUp, gravityUp) * transform.rotation;
		transform.rotation = Quaternion.Slerp (transform.rotation, targetRotation, 50 * Time.deltaTime);

	}
}
