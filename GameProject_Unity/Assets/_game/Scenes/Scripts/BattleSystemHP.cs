using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BattleSystemHP : MonoBehaviour
{
    public Text nameText;
    public Slider hpSlider;
    

    

    public void SetHp(Character system)
    {
        nameText.text = system.name;
        hpSlider.maxValue = system.maxHP;
        hpSlider.value = system.currentHP;


    }

    public void SetHP (float hp)
    {
        hpSlider.value = hp;
    }
}
