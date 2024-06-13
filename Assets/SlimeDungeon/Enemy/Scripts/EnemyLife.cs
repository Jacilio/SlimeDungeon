using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLife : MonoBehaviour
{

    public int hitPoints;
    // Start is called before the first frame update
    void Start()
    {
        hitPoints = Random.Range(10, 30);
    }

    // Update is called once per frame
    void Update()
    {
        if (hitPoints <= 0)
        {
            Destroy(gameObject);
        }
    }

    public void DamageTaken(int damage)
    {
        hitPoints -= damage;
    }
}
