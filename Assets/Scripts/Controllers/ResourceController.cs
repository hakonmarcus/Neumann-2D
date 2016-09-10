using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ResourceController : MonoBehaviour 
{

    public Dictionary<string, int> resourcePool;

    public delegate void ChangeAction();
    public static event ChangeAction Change;

	// Use this for initialization
	void Start () 
	{
        Debug.Log("Starting new cool thing!");
        resourcePool = new Dictionary<string, int>();
	}
	
	// Update is called once per frame
	void Update () 
	{

    }

    void save()
    {

    }

    private void addOre(string type, int quantity)
    {
        Debug.Log("Added!");

        if(!resourcePool.ContainsKey(type))
        {
            resourcePool.Add(type, quantity);
        }

        else
        {
            int existingQuantity = resourcePool[type];
            resourcePool[type] = existingQuantity + quantity;
        }

        onChange();
    }

    public void onChange()
    {
        Debug.Log("Change was performed!");
        Change();
    }



    public void addOre(GameObject ore)
    {
        Ore oreType = ore.GetComponent<Ore>();
        string resource = oreType.twoLetterID;
        int quantity = oreType.quantity;
        addOre(resource, quantity);
    }



}
