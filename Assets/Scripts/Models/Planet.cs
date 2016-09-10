using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Planet : MonoBehaviour {

    public float radius;
    public List<GameObject> minerals;

	// Use this for initialization
	void Start () {
        radius = this.GetComponent<CircleCollider2D>().radius * 2;
        if (minerals.Count != 0)
        {
            addRandomMineral();
            addRandomMineral();
            addRandomMineral();
            addRandomMineral();
            addRandomMineral();
            addRandomMineral();
            addRandomMineral();
            addRandomMineral();
        }

    }
	
	// Update is called once per frame
	void Update () {
	
	}


    void addRandomMineral()
    {
        Debug.Log("Planet mineral count: " + minerals.Count);
        int mineralIndex = Random.Range(0, minerals.Count - 1);
        GameObject mineral = minerals[mineralIndex];
        addRandomMineral(mineral);
    }

    void addRandomMineral(GameObject mineral)
    {
        Vector3 center = transform.position;
        Vector3 pos = RandomCircle(center, radius);
        Quaternion rot = Quaternion.FromToRotation(Vector3.forward, center - pos);
        GameObject mineralObject = (GameObject) Instantiate(mineral, pos, rot);
        // mineralObject.transform.SetParent(this.transform);
        Debug.Log("created new minerals!");

    }

    Vector3 RandomCircle (Vector3 center, float radius)
    {
        float ang = Random.value * 360;
        Vector3 pos;
        pos.x = center.x + radius * Mathf.Sin(ang * Mathf.Deg2Rad);
        pos.y = center.y + radius * Mathf.Cos(ang * Mathf.Deg2Rad);
        pos.z = center.z;
        return pos;
    }



}
