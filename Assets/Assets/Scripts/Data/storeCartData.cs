using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class storeCartData : MonoBehaviour
{

    public Dictionary<string, int> cartData = new Dictionary<string, int>();
    public List<ItemData> data = new List<ItemData>();

    public bool getItemData;
    // Start is called before the first frame update
    public void CleanList()
    {
        data.Clear();
        cartData.Clear();
    }

    private void Update()
    {
       // Debug.LogWarning("cartData " + cartData.Count);
    }

    public void boolChange()
    {
        Debug.LogWarning("TRIGETKARNANREKNREKN");
        getItemData = true;
    }
}
