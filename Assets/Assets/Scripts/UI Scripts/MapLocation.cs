using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq;

public class MapLocation : MonoBehaviour
{
    public GameObject[] sections, borders;
    public List<GameObject> sectionsClone;

    public GameObject player;

    public float closestDistance;
    public GameObject closestPoint, leftClosestPoint, rightClosestPoint;

    public GameObject currentAisleSection;

    public string currentAisle_string, leftAisle_string, rightAisle_string, furthestAisle_string, currentAisleCheck_string;

    // Start is called before the first frame update
    void Start()
    {
        sections = GameObject.FindGameObjectsWithTag("Sections");
        borders = GameObject.FindGameObjectsWithTag("Border");
        player = GameObject.FindGameObjectWithTag("Player");

    }

    // Update is called once per frame
    void Update()
    {
        //FindPlayer();
    }

    /// <summary>
    /// function to reset the variables used to find locations.
    /// </summary>
    public void ResetCloneList()
    {
        sectionsClone.Clear();
        leftClosestPoint = null;
        rightClosestPoint = null;
        leftAisle_string = null;
        rightAisle_string = null;
        furthestAisle_string = null;
        foreach(GameObject section in borders)
        {
             sectionsClone.Add(section.transform.parent.gameObject);
        }
    }

    /// <summary>
    /// Main function to get the current aisle where the player is in. Sets the closestDistance to a high number to help 
    /// find the closes object. goes thru the borders array to find which aisle is closest. it would then save the parent
    /// gameobject and string to be used later. The if (currentAisleSection != closestPoint) statement is chechking if the
    /// player leaves the aisle. If they did, reset all the variables and then finds the current aisle in the clone list to
    /// delete. Clone list to be used for finding left and right aisle. Since there is 2 borders per aisle, need to delete
    /// the aisle from the clone twice.
    /// </summary>
    public string FindPlayer()
    {
        //resets the distance(cant be 0 else the if statement will NEVER run)
        closestDistance = 1000;
        foreach (GameObject section in borders)
        {
            if (Vector3.Distance(section.transform.position, player.transform.position) < closestDistance)
            {
                closestDistance = Vector3.Distance(section.transform.position, player.transform.position);
                
                closestPoint = section.transform.parent.gameObject;
                currentAisle_string = section.transform.parent.name;
            }
        }

        if (currentAisleSection != closestPoint)
        {
            ResetCloneList();
            currentAisleSection = closestPoint;
            foreach (GameObject border in borders)
            {
                Debug.LogWarning(border.transform.parent.name + closestPoint.name);
                if (border.transform.parent.name == closestPoint.name)
                {
                    sectionsClone.Remove(border);
                    Debug.LogWarning("DELTEING");
                }
            }
            
        }

        currentAisle_string = string.Concat(currentAisle_string.Select(x => Char.IsUpper(x) ? " " + x : x.ToString())).TrimStart(' ');

       //Debug.LogWarning(currentAisle_string);
        return currentAisle_string;

    }

    public string FindLeftAdjecentAisle()
    {
        float closestLeftDistance = 10000;

        foreach(GameObject section in sectionsClone)
        {
            //checks if the aisle is to the left of the player and is the current closest point
            if((Vector3.Distance(section.transform.position, player.transform.position) < closestLeftDistance) &&
                section.transform.position.x <= player.transform.position.x
                && !(section.name == closestPoint.name))
            {
                closestLeftDistance = Vector3.Distance(section.transform.position, player.transform.position);
                leftClosestPoint = section;
                leftAisle_string = section.name;
            }

        }
        if (leftClosestPoint == null)
        {
            return FindFurthestAilse();
        }
        else
        {
            leftAisle_string = string.Concat(leftAisle_string.Select(x => Char.IsUpper(x) ? " " + x : x.ToString())).TrimStart(' ');
            return leftAisle_string;
        }
    }
    public string FindRightAdjecentAisle()
    {
        float closestRightDistance = 10000;

        foreach (GameObject section in sectionsClone)
        {
            //checks if the aisle is to the right of the player and is the current closest point
            if (Vector3.Distance(section.transform.position, player.transform.position) < closestRightDistance &&
                section.transform.position.x >= player.transform.position.x
                && !(section.name == closestPoint.name))
            {
                closestRightDistance = Vector3.Distance(section.transform.position, player.transform.position);
                rightClosestPoint = section;
                rightAisle_string = section.name;
            }

        }
        if (rightClosestPoint == null)
        {
            return FindFurthestAilse();
        }
        else
        {
            rightAisle_string = string.Concat(rightAisle_string.Select(x => Char.IsUpper(x) ? " " + x : x.ToString())).TrimStart(' ');
            return rightAisle_string;
        }
    }

    public string FindFurthestAilse()
    {
        float furthestDistance = 0;

        foreach (GameObject section in sectionsClone)
        {
            //checks if the aisle is to the right of the player and is the current closest point
            if (Vector3.Distance(section.transform.position, player.transform.position) > furthestDistance)
            {
                furthestDistance = Vector3.Distance(section.transform.position, player.transform.position);
                furthestAisle_string = section.name;
            }
        }

        furthestAisle_string = string.Concat(furthestAisle_string.Select(x => Char.IsUpper(x) ? " " + x : x.ToString())).TrimStart(' ');
        return furthestAisle_string;

    }

    public bool DidPlayerChangeAisle()
    {
        if(currentAisleCheck_string == null)
        {
            currentAisleCheck_string = FindPlayer();
        }


        if(currentAisleCheck_string != FindPlayer())
        {
            currentAisleCheck_string = FindPlayer();
            return true;
        }
        else return false;
    }
}
