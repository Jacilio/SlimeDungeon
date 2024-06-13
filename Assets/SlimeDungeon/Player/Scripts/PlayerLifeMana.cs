using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLifeMana : MonoBehaviour
{
    public int hitPoints = 100;
    public int mana = 100;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void ManaCast(int manaCasted)
    {
        mana -= manaCasted;
    }
    public void DamageTaken(int damageTaken)
    {
        Debug.Log("Damage Taken");
    }
}
