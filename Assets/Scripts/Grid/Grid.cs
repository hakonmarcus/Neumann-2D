using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public static class Grid {

    public static List<GameObject> controllers;

    public static GameController gameController;
    public static ResourceController resourceController;
	public static InventoryController inventoryController;

    static Grid()
    {
        GameObject g;

        g = safeFind("GameController");
        gameController = (GameController) safeComponent(g, "GameController");
    }

    public static bool ping()
    {
        Debug.Log("Grid has responded to ping and is activated");
        return true;
    }


    private static GameObject safeFind(string s)
    {
        GameObject g = GameObject.Find(s);
        if(g == null) {
            bigProblem("Unfortunately, GameObject " + s + " could not be found");
            return null;
        }

        else
        {
            return g;
        }


    }

    private static Component safeComponent(GameObject g, string s)
    {
        Component c = g.GetComponent(s);
        if(c == null)
        {
            bigProblem("Unfortunately, Component " + s + " could not be found");
            return null;
        }

        else
        {
            Debug.Log("Succesfully loaded component " + s + " in Grid");
            return c;
        }
    }

    private static void bigProblem(string s)
    {
        Debug.Log(s);

    }






}
