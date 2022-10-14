using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Reticle : MonoBehaviour
{
    public float restingSize;
    public float maxSize;
    public float speed;
    public Sprite focusedReticle;
    public Sprite unfocusedReticle;
    private RectTransform reticle;
    private Image image;
    private float currentSize;
    private bool focus = false;

    // Start is called before the first frame update
    void Start()
    {
        reticle = GetComponent<RectTransform>();
        image = GetComponent<Image>();
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

    public void SetFocus(bool value) {
        focus = value;

        if (value) {
            image.sprite = focusedReticle;
        } else {
            image.sprite = unfocusedReticle;
        }
    }
}
