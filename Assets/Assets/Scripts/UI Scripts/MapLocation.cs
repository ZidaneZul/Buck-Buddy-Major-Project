using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq;

public class MapLocation : MonoBehaviour
{
    public GameObject[] sections;
    public List<GameObject> sectionsClone;

    public GameObject player;

    public float closestDistance;
    public GameObject closestPoint, leftClosestPoint, rightClosestPoint;

    public MapLocation mapLocationScript;

    public GameObject currentAisleSection;

    public string currentAisle_string, leftAisle_string, rightAisle_string, furthestAisle_string;

    // Start is called before the first frame update
    void Start()
    {
        sections = GameObject.FindGameObjectsWithTag("Sections");
        player = GameObject.FindGameObjectWithTag("Player");

    }

    // Update is called once per frame
    void Update()
    {
        //FindPlayer();
    }

    
    public void ResetCloneList()
    {
        sectionsClone.Clear();
        leftClosestPoint = null;
        rightClosestPoint = null;
        leftAisle_string = null;
        rightAisle_string = null;
        furthestAisle_string = null;
        foreach(GameObject section in sections)
        {
            sectionsClone.Add(section);
        }
    }

    public string FindPlayerMap()
    {
        return "amp";
    }

    public string FindPlayer()
    {
        //resets the distance(cant be 0 else the if statement will NEVER run)
        closestDistance = 1000;
        foreach (GameObject section in sections)
        {
            if (Vector3.Distance(section.transform.position, player.transform.position) < closestDistance)
            {
                closestDistance = Vector3.Distance(section.transform.position, player.transform.position);
                closestPoint = section;
                currentAisle_string = section.name;
            }
        }

        if (currentAisleSection != closestPoint)
        {
            ResetCloneList();
            currentAisleSection = closestPoint;
            sectionsClone.Remove(closestPoint);
        }

        currentAisle_string = string.Concat(currentAisle_string.Select(x => Char.IsUpper(x) ? " " + x : x.ToString())).TrimStart(' ');

       // Debug.LogError(currentAisle_string);
        return currentAisle_string;

    }

    public string FindLeftAdjecentAisle()
    {
        float closestLeftDistance = 10000;

        foreach(GameObject section in sectionsClone)
        {
            //checks if the aisle is to the left of the player and is the current closest point
            if((Vector3.Distance(section.transform.position, player.transform.position) < closestLeftDistance) &&
                section.transform.position.x <= player.transform.position.x)
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
                section.transform.position.x >= player.transform.position.x)
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
}
