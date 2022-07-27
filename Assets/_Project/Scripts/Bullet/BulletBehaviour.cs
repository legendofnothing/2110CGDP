using UnityEngine;
using System.Collections;
using System.Collections.Generic;

//Summary: Handles bullet behaviour
//Created by: leg

public class BulletBehaviour : MonoBehaviour
{
    private float damage;

    private void OnTriggerEnter2D(Collider2D collision) {
        if(collision.gameObject.layer == LayerMask.NameToLayer("Enemy")) {

            var enemyScript = collision.GetComponent<EnemyManager>();

            enemyScript.DealDamage(damage);

            Destroy(gameObject);
        }

        Destroy(gameObject);
    }

    public void SetDamage(float amount) { damage = amount; }

    //I am gonna eat burgers separately
}