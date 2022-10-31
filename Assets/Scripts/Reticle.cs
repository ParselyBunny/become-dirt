using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Manage behavior of a reticle image.
/// </summary>
[RequireComponent(typeof(Image), typeof(RectTransform))]
public class Reticle : MonoBehaviour
{
    public float RestingSize;
    public float MaxSize;
    public float Speed;
    public Sprite FocusedReticle;
    public Sprite UnfocusedReticle;
    private RectTransform _reticle;
    private Image _image;
    private float _currentSize;
    private bool _focus = false;

    void Awake()
    {
        _reticle = GetComponent<RectTransform>();
        _image = GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        if (_focus)
        {
            _currentSize = Mathf.Lerp(_currentSize, MaxSize, Time.deltaTime * Speed);
        }
        else
        {
            _currentSize = Mathf.Lerp(_currentSize, RestingSize, Time.deltaTime * Speed);
        }

        _reticle.sizeDelta = new Vector2(_currentSize, _currentSize);
    }

    /// <summary>
    /// Set the focus state of the reticle.
    /// </summary>
    public void SetFocus(bool value)
    {
        _focus = value;

        // Swap to appropriate reticle type
        if (value)
        {
            _image.sprite = FocusedReticle;
        }
        else
        {
            _image.sprite = UnfocusedReticle;
        }
    }
}
