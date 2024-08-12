using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyInfo : MonoBehaviour
{
    public int EnemyHP = 100;
    public Slider EnemyHPSlider;

    public void takeDamage(int AtkDamage){
        EnemyHP = EnemyHP - AtkDamage;
        EnemyHPSlider.value = EnemyHP;
    }
}
