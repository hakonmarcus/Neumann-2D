using UnityEngine;
using System.Collections;

public class Panel : MonoBehaviour 
{

	public float charge;
	private float chargeMax = 250;

	public SpriteRenderer fullPanel;
	public SpriteRenderer twothirdsPanel;
	public SpriteRenderer onethirdPanel;
	public SpriteRenderer emptyPanel;

	// Use this for initialization
	void Start () 
	{
		charge = 0;
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (charge >= chargeMax)
		{
			charge = chargeMax;

			enablePanel (fullPanel);

		}
		else
		{
			charge += 10 * Time.deltaTime;

			if(charge >= 0.55*chargeMax)
			{
				enablePanel (twothirdsPanel);
			}
			else if (charge >= 0.10*chargeMax)
			{
				enablePanel (onethirdPanel);
			}
			else
			{
				enablePanel (emptyPanel);
			}

		}
		
	}

	public float GetCharge()
	{
		return charge;
	}

	public void SetCharge (float amount)
	{
		charge = amount;
	}

	void enablePanel(SpriteRenderer panel)
	{
		fullPanel.enabled = false;
		twothirdsPanel.enabled = false;
		onethirdPanel.enabled = false;
		emptyPanel.enabled = false;
		panel.enabled = true;
	}
}
