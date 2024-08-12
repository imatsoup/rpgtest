using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
[CreateAssetMenu(fileName = "Player", menuName = "ScriptableObjects/Player", order = 1)]
public class Player : ScriptableObject
{
    public int HP;
    public bool priority;
    public Attack[] attacks = new Attack[4];


    public void takeDamage(int AtkDamage){
        HP = HP - AtkDamage;
    }
}
