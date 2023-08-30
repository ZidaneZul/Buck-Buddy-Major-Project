using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapLoopTeleport : MonoBehaviour
{

    GameObject leftBarrier, rightBarrier, leftTpPoint, rightTpPoint;
    // Start is called before the first frame update
    void Start()
    {
        leftBarrier = GameObject.Find("LeftBarrier");
        rightBarrier = GameObject.Find("RightBarrier");

        leftTpPoint = leftBarrier.transform.GetChild(0).gameObject;
        rightTpPoint = rightBarrier.transform.GetChild(0).gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter(Collider other)
    {

     //   Debug.Log("Hit something" + other.name);

      //  Debug.Log("other is " + other + "\n while left is " + leftBarrier);

        if(other.name == leftBarrier.name)
        {
            transform.position = rightTpPoint.transform.position;
        }
        else if (other.name == rightBarrier.name)
        {
            transform.position = leftTpPoint.transform.position;
        }


    }
}
