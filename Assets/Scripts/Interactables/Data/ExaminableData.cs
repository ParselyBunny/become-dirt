using UnityEngine;
using System;

[CreateAssetMenu]
public class ExaminableData : NPCData
{
    public string[] ExamineMessage { get => _examineMessage; }

    [SerializeField, Tooltip("Message to display when examined if knot unspecified.")]
    private string[] _examineMessage = new string[] { };
}