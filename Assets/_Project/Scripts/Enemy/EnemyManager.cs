using UnityEngine;
using System.Collections;
using System.Collections.Generic;

//Summary: Handles Enemy States, HP etc
//Created by: leg

public class EnemyManager : MonoBehaviour
{
    [Header("Enemy Config")]
    public float enemyHP;

    [Header("Other Config")]
    public TextMesh enemyHPDisplay; //For Debug

    private float _currentHP;

    private void Start() {
        _currentHP = enemyHP;
    }
 
    private void Update() {
        enemyHPDisplay.text = "HP:" + _currentHP.ToString("0"); //For Debug
    }

    public void DealDamage(float dmg) {
        _currentHP -= dmg;
    }

}