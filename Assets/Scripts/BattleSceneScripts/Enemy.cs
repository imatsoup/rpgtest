using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
[CreateAssetMenu(fileName = "Enemy", menuName = "ScriptableObjects/Enemy", order = 1)]
//Script for the enemy in combat. I believe the way this will interact with the rest of the game is:
//On encounter start, instantiate an enemy, overwriting the scriptable object
// based on the ID of the encounter. Stats and abilities pulled from
//a file that houses all the enemy information.
public class Enemy : ScriptableObject
{
    public int MaxHP;
    public int HP;
    public int ATK;
    public Enemy(int hp, int atk){
        HP = hp;
        ATK = atk;
    }
    public void takeDamage(int atkDamage){
        HP = HP - atkDamage;
    }
    public void heal(int healVal){
        HP = HP + healVal;
        if(HP > MaxHP){
            HP = MaxHP;
        }
    }
}
