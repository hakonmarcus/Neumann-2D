using UnityEngine;
using System.Collections;

public class GravityBody : MonoBehaviour
{
	public GravityAttractor attractor;
	private Transform thisTransform; 

	// Use this for initialization
	void Start ()
	{
		thisTransform = transform;
	}
	
	// Update is called once per frame
	void FixedUpdate () 
	{
		attractor.Attract (thisTransform);
	}
}
