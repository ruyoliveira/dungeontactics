using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum CardType { Damage}
[CreateAssetMenu(fileName = "Card", menuName = "ScriptableObjects/Card", order = 1)]
public class Card : ScriptableObject
{
    // Card title
    public string title;
    // Effect targets
    public Vector2[] targets;
    // Type
    public CardType cardType;


}
