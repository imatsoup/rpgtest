using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
[CreateAssetMenu(fileName = "Player", menuName = "ScriptableObjects/Player", order = 1)]
//Houses player fields and methods, primarily for scriptable object used in combat.
public class Player : ScriptableObject
{
    public int MaxHP;
    public int HP;
    public bool priority;
    public Attack[] attacks = new Attack[4];
    public Item[] items = new Item[1];

    public void takeDamage(int AtkDamage){
        HP = HP - AtkDamage;
    }
    public void heal(int healVal){
        HP = HP + healVal;
        if(HP > MaxHP){
            HP = MaxHP;
        }
    }
}
