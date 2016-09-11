using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class InventoryProperty : MonoBehaviour 
{

	public List<InventoryStack> inventoryPool;
	public int inventorySize = 5;
	public int stackMax = 3;

	public delegate void ChangeAction();
	public static event ChangeAction Change;

	// Use this for initialization
	void Start () 
	{
		Debug.Log("Starting new cool thing!");
		inventoryPool = new List<InventoryStack>();
		buildInventory();
	}

	// Update is called once per frame
	void Update () 
	{

	}

	void save()
	{

	}

	private void buildInventory()
	{
		for(int i = 0; i < inventorySize ; i++)
		{
			GameObject newStack = new GameObject ();
			newStack.AddComponent<InventoryStack>();
			InventoryStack newStackScript = newStack.GetComponent<InventoryStack>();
			inventoryPool.Add(newStackScript);
		}
	}

	private void addStack(string type, int quantity)
	{
		Debug.Log("Added some "+type);



		while (quantity > 0)
		{
			int currentSlot = -1;

			foreach(InventoryStack stack in inventoryPool)
			{
				if(currentSlot == -1 && stack.type == type && stack.amount < stackMax)
				{
					currentSlot = inventoryPool.IndexOf (stack);
					stack.amount += 1;
				}
			}

			if(currentSlot == -1)
			{
				foreach (InventoryStack stack in inventoryPool) 
				{
					if (currentSlot == -1 && stack.type == "none") 
					{
						currentSlot = inventoryPool.IndexOf (stack);

						stack.type = type;
						stack.amount += 1;
					}
				}
			}

			quantity -= 1;
		}



		Debug.Log(	inventoryPool[0].type+": "+inventoryPool[0].amount+", "+
					inventoryPool[1].type+": "+inventoryPool[1].amount+", "+
					inventoryPool[2].type+": "+inventoryPool[2].amount+", "+
					inventoryPool[3].type+": "+inventoryPool[3].amount+", "+
					inventoryPool[4].type+": "+inventoryPool[4].amount);





		onChange();
	}

	public void onChange()
	{
		Debug.Log("Inventory changed!");
        if(Change != null)
        {
            Change();
        }
    }



	public void addOre(GameObject ore)
	{
		Ore oreType = ore.GetComponent<Ore>();
		string resource = oreType.twoLetterID;
		int quantity = oreType.quantity;
		addStack(resource, quantity);
	}



}
