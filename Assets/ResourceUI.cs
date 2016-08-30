using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using System.Linq;

public class ResourceUI : MonoBehaviour {

    public GameObject resourceTypeUI;

    public List<GameObject> resources;

	// Use this for initialization
	void Start () {
        ResourceController.Change += redraw;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnDestroy()
    {
        ResourceController.Change -= redraw;
    }

    void redraw()
    {

        foreach(Transform child in transform)
        {
            GameObject.Destroy(child.gameObject);
        }

        foreach (string key in Grid.gameController.resourceController.resourcePool.Keys.ToArray())
        {
            GameObject resourceType = Instantiate(resourceTypeUI);
            Text resourceTypeText = resourceType.transform.FindChild("ResourceType").GetComponent<Text>();
            Text resourceAmountText = resourceType.transform.FindChild("ResourceAmount").GetComponent<Text>();

            resourceTypeText.text = key;
            resourceAmountText.text = Grid.gameController.resourceController.resourcePool[key].ToString();

            resourceType.transform.SetParent(this.transform, false);
        }


    }





}
