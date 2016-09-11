using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using System.Linq;

public class Inventory : MonoBehaviour 
{
	//public GameObject resourceTypeUI;
	public List<GameObject> resources;
    //public Transform FeIcon;
    //public Transform SiIcon;
    public Transform ResourceIcon;



    public SpriteRenderer FeFrame;
    public SpriteRenderer FeFill;
    public SpriteRenderer FeBack;


	// Use this for initialization
	void Start () 
	{
		InventoryController.Change += redraw;
	}

	void OnDestroy()
	{
		InventoryController.Change -= redraw;
	}

	void redraw()
	{
        foreach(Transform child in transform)
        {
            GameObject.Destroy(child.gameObject);
        }
        
        int x = 0;

        foreach (InventoryStack stack in Grid.gameController.inventoryController.inventoryPool)
        {
            float newx = (x * 0.25f)-0.5f;
            Vector3 pos = new Vector3(newx, 0, 0);

            if(stack.amount != 0)
            {
                GameObject rIcon = Instantiate(ResourceIcon, pos, Quaternion.identity) as GameObject;
            }

            //noe som setter rIcon sin parent til å være denne transformen, så det havner i lista
            // det funker ikke å gjøre dette ––– rIcon.transform.SetParent(this.transform,true);

            // noe som bytter ut spritesa i ResourceIcon så det passer med typen ressurs vi har plukket opp
            if(stack.type == "Fe")
            {
                
            }
            else if(stack.type == "Si")
            {
                
            }

            //må også sette antall på hver stack.

            x += 1;
           
        }

	}
		
	// Update is called once per frame
	void Update ()
	{
	
	}
}
