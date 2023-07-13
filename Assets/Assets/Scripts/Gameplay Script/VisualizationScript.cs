using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VisualizationScript : MonoBehaviour
{
    public float size;
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(this.transform.position, size);
        Gizmos.DrawRay(this.transform.position, transform.forward);

    }
}
