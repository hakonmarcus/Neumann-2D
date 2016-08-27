using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {

	public GameObject wheel;

	private Vector3 offset;

	// Use this for initialization
	void Start () 
	{
		offset = transform.position - wheel.transform.position;
	}

	// Update is called once per frame
	void LateUpdate () 
	{
		transform.position = wheel.transform.position + offset;
		transform.rotation = wheel.transform.rotation;
	}
}
