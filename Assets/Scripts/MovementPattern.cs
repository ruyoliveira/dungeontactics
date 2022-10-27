using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ActionType { None, Damage, Move }
[CreateAssetMenu(fileName = "MovementPattern", menuName = "ScriptableObjects/MovementPattern", order = 2)]
public class MovementPattern : ScriptableObject
{
    // Card title
    public string title;
    // Effect targets
    public Vector2[] targets;
    // Type
    public ActionType[] actionType;
    // Card
    public Card card;


}
