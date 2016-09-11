using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {

    public GameObject resourceControllerObject;
    public ResourceController resourceController;

	public GameObject inventoryControllerObject;
	public InventoryController inventoryController;

    void Awake()
    {
        Grid.ping();
        Debug.Log("Ding from GameController");
    }

	// Use this for initialization
	void Start () {
        Debug.Log("Init!");
        DontDestroyOnLoad(this);

        resourceControllerObject = Instantiate(resourceControllerObject);
        resourceControllerObject.transform.SetParent(this.transform);
        resourceController = resourceControllerObject.GetComponent<ResourceController>();

        if(resourceController == null)
        {
            Debug.LogError("ResourceController could not be found!");
        }

		inventoryControllerObject = Instantiate (inventoryControllerObject);
		inventoryControllerObject.transform.SetParent (this.transform);
		inventoryController = inventoryControllerObject.GetComponent<InventoryController> ();

		if(inventoryController == null)
		{
			Debug.LogError("InventoryController could not be found!");
		}

        SceneManager.LoadScene("MainGame");


    }

    // Update is called once per frame
    void Update () {

	
	}
}
