using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum CardType { None, Damage}
[CreateAssetMenu(fileName = "Card", menuName = "ScriptableObjects/Card", order = 1)]
public class Card : ScriptableObject
{
    public int id;
    // Card title
    public string title;
    // Effect targets
    public Vector2[] targets;
    // Type
    public CardType cardType;


}
