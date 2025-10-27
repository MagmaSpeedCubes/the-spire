using UnityEngine;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "Item", menuName = "Scriptable Objects/Item")]
public class Item : ScriptableObject
{
    
    public string name;
    public string description;
    public int level;
    public float weight;
    public float volume;

    [Header("Additional Info")]
    public List<NumberedSprite> sprites = new List<NumberedSprite>();
    public List<AdditionalInfo> additionalStats = new List<AdditionalInfo>();
    //this is for additional stats that only apply to certain items
    public List<Modifier> modifiers = new List<Modifier>();
    //this is for any other info that does not fit into an above field


}
