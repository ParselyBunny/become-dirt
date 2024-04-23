using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GizmoLine : MonoBehaviour
{
    public void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(transform.position, transform.parent.position);
    }
}
