using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Objective : MonoBehaviour
{
    public ObjectiveData objectiveData;
    // Start is called before the first frame update
    void Start()
    {
        ShoppingListDisplay();
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ShoppingListDisplay()
    {
        if(objectiveData.Soup > 0)
        {
            Debug.Log("Soup Needed: " + objectiveData.Soup);
        }

        if (objectiveData.Lettuce > 0)
        {
            Debug.Log("Lettuce Needed: " + objectiveData.Lettuce);
        }
        if (objectiveData.Cheese > 0)
        {
            Debug.Log("Cheese Needed: " + objectiveData.Cheese);
        }
        if (objectiveData.Tomatoes > 0)
        {
            Debug.Log("Tomatoes Needed: " + objectiveData.Tomatoes);
        }
        if (objectiveData.Noodles > 0)
        {
            Debug.Log("Noodles Needed: " + objectiveData.Noodles);
        }
        if (objectiveData.Eggs > 0)
        {
            Debug.Log("Eggs Needed: " + objectiveData.Eggs);
        }
        if (objectiveData.Bread > 0)
        {
            Debug.Log("Bread Needed: "+objectiveData.Bread);
        }
        if (objectiveData.Mushrooms > 0)
        {
            Debug.Log("Mushrooms Needed: " + objectiveData.Mushrooms);
        }
        if (objectiveData.Meat > 0)
        {
            Debug.Log("Meat Needed: " + objectiveData.Meat);
        }
        if (objectiveData.SoySauce > 0)
        {
            Debug.Log("SoySauce Needed: " + objectiveData.SoySauce);
        }
        if (objectiveData.Ham > 0)
        {
            Debug.Log("Ham Needed: " + objectiveData.Ham);
        }
    }
}
