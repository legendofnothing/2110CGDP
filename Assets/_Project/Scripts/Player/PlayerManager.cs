using UnityEngine;
using System.Collections;
using System.Collections.Generic;

//Summary: Handles HP, Stamina, etc
//Created by: leg

public class PlayerManager : MonoBehaviour
{
    //Singleton 
    public static PlayerManager instance { get; private set; }

    //Scriptable Objects
    [SerializeField] private FloatVar _playerHP;
    [SerializeField] private FloatVar _playerStamina;

    [Header("Player Configs")]
    public float playerHP;
    public float playerStamina;

    //Init Singleton
    private void Awake() {
        if (instance != null && instance != this) Destroy(this);

        else instance = this;       
     }

    private void Start() {
        _playerHP.Value      = playerHP;
        _playerStamina.Value = playerStamina;
    }   
    
    //Take damage function 
    public void TakeDamage(float dmg) {
        _playerHP.Value -= dmg;
    }

    //Reduce stamina function
    public void ReduceStamina(float amount) {
        _playerStamina.Value -= amount;
    }

    public float GetPlayerHP() { return _playerHP.Value; } //Returns player HP
    public float GetPlayerStamina() { return _playerStamina.Value; } //Returns player Stamina
}