using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boxes : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.gameObject.CompareTag("Projectile"))
        {
            Destroy(this.gameObject);
        }

        if (collision.collider.gameObject.CompareTag("Enemy"))
        {
            if(collision.gameObject.GetComponent<EnemyBasic>().isAttacking) 
            {
                Destroy(this.gameObject);
            }
        }

    }
}
