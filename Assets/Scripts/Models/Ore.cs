using UnityEngine;
using System.Collections;

public class Ore : MonoBehaviour {

    public string name;
    public string twoLetterID;
    public int value;
    public int quantity;

    public SpriteRenderer Frame;
    public SpriteRenderer Fill;
    public SpriteRenderer Back;



    public string getName()
    {
        return this.name;
    }

    public string getTwoLetterID()
    {
        return this.twoLetterID;
    }

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
