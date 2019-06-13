using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonCollision : MonoBehaviour
{

    private WorldGenerator world;

    void Start() {
        world = GameObject.Find("Main Camera").GetComponent<WorldGenerator>();
    }
    private void OnCollisionStay(Collision col)
    {
        if (name == "button92" && col.gameObject.name == "push62")
        {
            Destroy(GameObject.Find("door164"));
            Destroy(GameObject.Find("door174"));
        }
    }
    void OnCollisionEnter(Collision col)
    {
        world = GameObject.Find("Main Camera").GetComponent<WorldGenerator>();

        if (name == "button615" && col.gameObject.name == "Chicken")
        {
            Destroy(GameObject.Find("door1610"));
            Destroy(GameObject.Find("door1710"));
        }

        if(name == "Put(Clone)" && col.gameObject.name == "Pig" && col.gameObject.GetComponent<PigController>().hasObject) {
            Destroy(GameObject.Find("door14"));
            Destroy(GameObject.Find("door24"));
            col.gameObject.GetComponent<PigController>().hasObject = false;
        }

        if (name == "guess1" && col.gameObject.name == "Pig" && !world.checkForCombo) {
            world.checkForCombo = true;
            GetComponent<Renderer>().material.color = Color.yellow;
        }

        if (name == "guess3" && col.gameObject.name == "Pig" && world.checkForCombo)
        {
            world.guess1 = true;
            GetComponent<Renderer>().material.color = Color.yellow;
        }

        if (name == "guess2" && col.gameObject.name == "Pig" && world.guess1)
        {
            world.guess2 = true;
            GetComponent<Renderer>().material.color = Color.yellow;
        }

        // next

        if (name == "guess923" && col.gameObject.name == "Pig" && !world.checkForCombo)
        {
            world.checkForCombo = true;
            GetComponent<Renderer>().material.color = Color.yellow;
        }

        if (name == "guess91" && col.gameObject.name == "Chicken" && world.checkForCombo)
        {
            world.guess1 = true;
            GetComponent<Renderer>().material.color = Color.yellow;
        }

        if (name == "guess921" && col.gameObject.name == "Pig" && world.guess1)
        {
            world.guess2 = true;
            GetComponent<Renderer>().material.color = Color.yellow;
        }

        if (name == "guess92" && col.gameObject.name == "Chicken" && world.guess2)
        {
            world.guess3 = true;
            GetComponent<Renderer>().material.color = Color.yellow;
        }

        if (name == "guess922" && col.gameObject.name == "Pig" && world.guess3)
        {
            world.guess4 = true;
            GetComponent<Renderer>().material.color = Color.yellow;
        }

        if (name == "guess93" && col.gameObject.name == "Chicken" && world.guess4)
        {
            world.guess5 = true;
            GetComponent<Renderer>().material.color = Color.yellow;
        }
    }

}
