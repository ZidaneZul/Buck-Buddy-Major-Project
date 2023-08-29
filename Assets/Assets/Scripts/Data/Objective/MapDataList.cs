using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapDataList : MonoBehaviour
{   
    [System.Serializable]
    public class MapAisle
    {
        public string[] name;
    }

    public MapAisle[] mapAisleList;

  //  struct BakeryAisle
  //  {
    //    string[] = {"bread"};
   // }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
