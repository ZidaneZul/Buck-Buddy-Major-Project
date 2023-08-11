using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapLocation : MonoBehaviour
{

    public GameObject[] sections;
    public GameObject player;

    public float closestDistance;
    public GameObject closestPoint;
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

    public void FindPlayer()
    {
        //resets the distance(cant be 0 else the if statement will NEVER run)
        closestDistance = 1000;
        foreach(GameObject section in sections)
        {
            if(Vector3.Distance(section.transform.position, player.transform.position) < closestDistance)
            {
                closestDistance = Vector3.Distance(section.transform.position, player.transform.position);
                closestPoint = section;
            }

        }
        Debug.Log(closestPoint.name);

    }
}
