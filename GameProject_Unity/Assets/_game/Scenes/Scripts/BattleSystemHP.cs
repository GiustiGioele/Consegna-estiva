using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BattleSystemHP : MonoBehaviour
{
    public Text nameText;
    public Slider hpSlider;

    public void SetHp(BattleSystem BattleSystem)
    {
        nameText.text = BattleSystem.name;
        hpSlider.maxValue = BattleSystem.maxHP;
        hpSlider.value = BattleSystem.currentHP;

    }

    public void SetHP (int hp)
    {
        hpSlider.value = hp;
    }
}
