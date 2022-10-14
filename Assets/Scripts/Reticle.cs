using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reticle : MonoBehaviour
{
    public bool focus = false;
    public float restingSize;
    public float maxSize;
    public float speed;
    private RectTransform reticle;
    private float currentSize;
    
    // Start is called before the first frame update
    void Start()
    {
        reticle = GetComponent<RectTransform>();
    }

    // Update is called once per frame
    void Update()
    {
        if (focus) {
            currentSize = Mathf.Lerp(currentSize, maxSize, Time.deltaTime * speed);
        } else {
            currentSize = Mathf.Lerp(currentSize, restingSize, Time.deltaTime * speed);
        }

        reticle.sizeDelta = new Vector2(currentSize, currentSize);
    }
}
