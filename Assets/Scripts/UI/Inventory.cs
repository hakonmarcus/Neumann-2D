using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using System.Linq;

public class Inventory : MonoBehaviour 
{
	//public GameObject resourceTypeUI;
	//public List<GameObject> resources;
    //public Transform FeIcon;
    //public Transform SiIcon;
    //public Transform ResourceIcon;

    public GameObject stackIcon;

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
                stackIcon = Instantiate(stackIcon, new Vector3(0,0,0), Quaternion.identity) as GameObject;
                ResourceIcon rI = stackIcon.GetComponent<ResourceIcon>();
                rI.Draw(stack.type,stack.amount);
                rI.transform.SetParent(this.transform);
                rI.transform.localPosition = pos;
                rI.transform.localRotation = Quaternion.identity;
                rI.transform.localScale = new Vector3(1, 1, 1);

               
                /*GameObject rIcon = new GameObject();
                rIcon.transform.position = pos;
                rIcon.AddComponent<ResourceIcon>();

                //GameObject rIcon = Instantiate(ResourceIcon, pos, Quaternion.identity) as GameObject;
                //rIcon.AddComponent(ResourceIcon);
                ResourceIcon rI = rIcon.GetComponent<ResourceIcon>();


                rI.Draw(stack.type);*/
            }

            //noe som setter rIcon sin parent til å være denne transformen, så det havner i lista
            // det funker ikke å gjøre dette ––– rIcon.transform.SetParent(this.transform,true);

           
            // noe som bytter ut spritesa i ResourceIcon så det passer med typen ressurs vi har plukket opp


            //må også sette antall på hver stack.

            x += 1;
           
        }

	}
		
	// Update is called once per frame
	void Update ()
	{
	
	}
}
