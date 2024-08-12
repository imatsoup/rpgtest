using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerInfo : MonoBehaviour
{
    public int HP = 100;
    public Slider HPSlider;

    // Start is called before the first frame update

    public void takeDamage(int AtkDamage){
        HP = HP - AtkDamage;
        HPSlider.value = HP;
    }
}
