using UnityEngine;

[CreateAssetMenu]
public class NPCData : InteractableData
{
    public string InkKnot { get => _inkKnot; set => _inkKnot = value; }
    public string Name { get => _name; set => _name = value; }
    // TODO: have this based on Ink tags or smthn

    [Tooltip("Name of the NPC to be displayed on the screen.")]
    private string _name = "Unknown";

    [Tooltip("The knot to jump to in the Ink Story.")]
    private string _inkKnot = "";
}