using UnityEngine;
using System.Collections;

public class ResourceIcon : MonoBehaviour 
{
    /*private GameObject Top;
    private GameObject Middle;
    private GameObject Bottom;*/

    public Sprite FeTop;
    public Sprite FeMiddle;
    public Sprite FeBottom;
    public Sprite SiTop;
    public Sprite SiMiddle;
    public Sprite SiBottom;

    public Sprite num1;
    public Sprite num2;
    public Sprite num3;
    public Sprite num4;
    public Sprite num5;
    public Sprite num6;
    public Sprite num7;
    public Sprite num8;
    public Sprite num9;
    public Sprite num0;



	// Use this for initialization
    void Start () 
    {
        
        /*Top = new GameObject();
        Top.AddComponent<SpriteRenderer>();
        SpriteRenderer TopRenderer = Top.GetComponent<SpriteRenderer>();
        TopRenderer.sprite = FeTop;

        Middle = new GameObject();
        Middle.AddComponent<SpriteRenderer>();
        SpriteRenderer MiddleRenderer = Middle.GetComponent<SpriteRenderer>();
        MiddleRenderer.sprite = FeMiddle;*/

        /*Bottom = GetComponent<SpriteRenderer>();
        Middle = GetComponent<SpriteRenderer>();
        Top = GetComponent<SpriteRenderer>();

        Bottom.sprite =     FeBottom;
        Middle.sprite =     FeMiddle;
        Top.sprite =        FeTop;*/
        
	}

    public void Draw(string type, int num)
    {
        Sprite Top = FeTop;
        Sprite Middle = FeMiddle;
        Sprite Bottom = FeBottom;

        Sprite Ones = num0;
        Sprite Tens = num0;


        int onenum = num % 10;
        int tennum = (num-onenum) / 10;



        Debug.Log(tennum+":"+onenum);

        if(type == "Fe")
        {
            
        }
        else if(type == "Si")
        {
            Bottom =     SiBottom;
            Middle =     SiMiddle;
            Top =        SiTop;
        }
      

        foreach ( Transform child in transform)
        {
            if(child.name == "Top")
            {
                SpriteRenderer top = child.GetComponent<SpriteRenderer>();
                top.sprite = Top;
            }
            else if (child.name == "Mid")
            {
                SpriteRenderer mid = child.GetComponent<SpriteRenderer>();
                mid.sprite = Middle;
            }
            else if (child.name == "Bot")
            {
                SpriteRenderer bot = child.GetComponent<SpriteRenderer>();
                bot.sprite = Bottom;
            }
            else if (child.name == "Ones")
            {
                if(onenum == 1)
                {
                    Ones = num1;
                }
                else if (onenum == 2)
                {
                    Ones = num2;
                }
                else if (onenum == 3)
                {
                    Ones = num3;
                }
                else if (onenum == 4)
                {
                    Ones = num4;
                }
                else if (onenum == 5)
                {
                    Ones = num5;
                }
                else if (onenum == 6)
                {
                    Ones = num6;
                }
                else if (onenum == 7)
                {
                    Ones = num7;
                }
                else if (onenum == 8)
                {
                    Ones = num8;
                }
                else if (onenum == 9)
                {
                    Ones = num9;
                }

                SpriteRenderer ones = child.GetComponent<SpriteRenderer>();
                ones.sprite = Ones;
                child.transform.localPosition = new Vector3(0.11f, -0.1f, 0);
            }
            else if (child.name == "Tens")
            {
                if(tennum == 1)
                {
                    Tens = num1;
                }
                else if (tennum == 2)
                {
                    Tens = num2;
                }
                else if (tennum == 3)
                {
                    Tens = num3;
                }
                else if (tennum == 4)
                {
                    Tens = num4;
                }
                else if (tennum == 5)
                {
                    Tens = num5;
                }
                else if (tennum == 6)
                {
                    Tens = num6;
                }
                else if (tennum == 7)
                {
                    Tens = num7;
                }
                else if (tennum == 8)
                {
                    Tens = num8;
                }
                else if (tennum == 9)
                {
                    Tens = num9;
                }


                SpriteRenderer tens = child.GetComponent<SpriteRenderer>();
                tens.sprite = Tens;
                child.transform.localPosition = new Vector3(0.05f, -0.1f, 0);

                if (tennum == 0)
                {
                    tens.enabled = false;
                }
                else
                {
                    tens.enabled = true;
                }
            }

        }
       
    }
	
	// Update is called once per frame
	void Update () 
    {
	
	}
}
