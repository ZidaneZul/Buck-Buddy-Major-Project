using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapLocation : MonoBehaviour
{

    public GameObject[] sections;
    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        sections = GameObject.FindGameObjectsWithTag("Sections");
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        FindPlayer();
    }

    void FindPlayer()
    {
        foreach(GameObject section in sections)
        {
            Collider[] hit = Physics.OverlapBox(section.transform.position, transform.localScale / 2);
            if (hit.Equals(player))
            {
                Debug.Log("Player is in " + section.name);
            }
        }
    }
}
