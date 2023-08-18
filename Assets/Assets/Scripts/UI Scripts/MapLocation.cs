using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapLocation : MonoBehaviour
{
    public GameObject[] sections;
    public List<GameObject> sectionsClone;

    public GameObject player;

    public float closestDistance;
    public GameObject closestPoint, leftClosestPoint, rightClosestPoint;

    public MapLocation mapLocationScript;

    public GameObject currentAisleSection;

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

    public string FindPlayer()
    {
        //resets the distance(cant be 0 else the if statement will NEVER run)
        closestDistance = 1000;
        foreach (GameObject section in sections)
        {
            sectionsClone.Add(section);
            if (Vector3.Distance(section.transform.position, player.transform.position) < closestDistance)
            {
                closestDistance = Vector3.Distance(section.transform.position, player.transform.position);
                closestPoint = section;
            }

        }
        currentAisleSection = closestPoint;

        if (currentAisleSection != null)
        {

        }
        sectionsClone.Remove(closestPoint);
        //Debug.Log(closestPoint.name);
        return closestPoint.name;

    }

    public string FindLeftAdjecentAisle()
    {
        float closestLeftDistance = 10000;

        foreach(GameObject section in sectionsClone)
        {
            //checks if the aisle is to the left of the player and is the current closest point
            if(Vector3.Distance(section.transform.position, player.transform.position) < 0f && 
                (Vector3.Distance(section.transform.position, player.transform.position) < closestLeftDistance))
            {
                closestLeftDistance = Vector3.Distance(section.transform.position, player.transform.position);
                leftClosestPoint = section;
            }

        }
        //if(leftClosestPoint == null)
        //{
        //    return null;
        //}
        //else
        //{
            return leftClosestPoint.name;
        //}
    }
    public string FindRightAdjecentAisle()
    {
        float closestRightDistance = 10000;

        foreach (GameObject section in sectionsClone)
        {
            //checks if the aisle is to the right of the player and is the current closest point
            if (Vector3.Distance(section.transform.position, player.transform.position) > 0f &&
                (Vector3.Distance(section.transform.position, player.transform.position) < closestRightDistance))
            {
                closestRightDistance = Vector3.Distance(section.transform.position, player.transform.position);
                rightClosestPoint = section;
            }

        }
        //if (rightClosestPoint == null)
        //{
        //    return null;
        //}
        //else
        //{
            return rightClosestPoint.name;
       // }
    }
}
