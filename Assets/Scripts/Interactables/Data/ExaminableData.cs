using UnityEngine;

[CreateAssetMenu]
public class ExaminableData : InteractableData
{
    // An array of Ink Knots, in the implementation it should cycle between these
    public string[] InkKnots { get => _inkKnots; set => _inkKnots = value; }

    [SerializeField, Tooltip("The knot to jump to in the Ink Story.")]
    private string[] _inkKnots = {};
}