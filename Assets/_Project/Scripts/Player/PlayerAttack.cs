using UnityEngine;
using System.Collections;
using System.Collections.Generic;

//Summary: Handles player attack
//Created by: leg

public class PlayerAttack : MonoBehaviour
{
    public Transform meleePoint;
    public GameObject bulletPrefab;

    private void Start() {
        
    }
 
    private void Update() {
        AttackInputs();
    }

    private void AttackInputs() {
        if (Input.GetKeyDown(KeyCode.J)) MeleeAttack();

        if (Input.GetKeyDown(KeyCode.K)) RangeAttack();
    }

    //Melee Attack
    private void MeleeAttack() {
        //Create Collider2D array at meleePoint with a 0.8 radius 
        var meleeCircle = Physics2D.OverlapCircleAll(meleePoint.position, 0.8f);

        //Loop through the array
        foreach(Collider2D enemyHit in meleeCircle) {
            if (enemyHit.gameObject.layer == LayerMask.NameToLayer("Enemy")) {
                var enemyScript = enemyHit.GetComponent<EnemyManager>();

                enemyScript.DealDamage(10f);
            }
        }
    }

    //Shoot
    private void RangeAttack() {
        GameObject bulletInstance = Instantiate(bulletPrefab, meleePoint.position, meleePoint.rotation);

        bulletInstance.GetComponent<Rigidbody2D>().velocity = transform.right * 8f;
    }

}