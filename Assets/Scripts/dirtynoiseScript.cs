using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dirtynoiseScript : MonoBehaviour
{
private float noiseFactor = 5.0;
private float scaleX = 2.0;
private float scaleY = 2.0;

    // Start is called before the first frame update
void Start()
{
    var vertPositions = GetComponent<MeshFilter>().mesh.vertices;  
    for (var i = 0; i < vertices.Length; i++)
    {
        vertices[i].x = vertPositions[i].x + (Mathf.PerlinNoise(noiseFactor+(vertPositions[i].x*scaleX), noiseFactor+(vertPositions[i].y*scaleY))) - (Mathf.PerlinNoise(noiseFactor+(vertPositions[i].x*invertscaleX), noiseFactor+(vertPositions[i].y*invertscaleY)));
    }
}
}