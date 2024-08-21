using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[CreateAssetMenu(fileName = "Item", menuName = "ScriptableObjects/Item", order = 1)]

public class Item : ScriptableObject
{
    public string name;
    public int healVal;
    public int dmgVal;
    public int quantity;
    public string desc;
    public bool consumable;
    public bool noEffect;
    public bool poison;

    public string GetName(){ return this.name; }
}
