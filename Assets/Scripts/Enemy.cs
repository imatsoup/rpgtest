using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
[CreateAssetMenu(fileName = "Enemy", menuName = "ScriptableObjects/Enemy", order = 1)]
public class Enemy : ScriptableObject
{
    public int HP;
    public int ATK;
    public Enemy(int hp, int atk){
        HP = hp;
        ATK = atk;
    }
    public void takeDamage(int atkDamage){
        HP = HP - atkDamage;
    }
}
