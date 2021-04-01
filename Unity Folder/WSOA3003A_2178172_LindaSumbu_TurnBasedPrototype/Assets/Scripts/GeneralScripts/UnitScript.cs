using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitScript : MonoBehaviour
{
    public string unitName;

    public int unitLevel;

    public int damage;

    public int maxHP;

    public int currentHP;

    public Transform spawnPoint;

    public GameObject pointsPrefab;


    private void Update()
    {
       
    }

    public bool TakeDamage(int dmg)
    {
        currentHP -= dmg;

         Instantiate(pointsPrefab, spawnPoint);

        if (currentHP <= 0)
        {
            
            return true;

          
        }


        else
        {
            return false;
        }

        
            
    }

    public void Heal(int amount)
    {
        currentHP += amount;
        
        if(currentHP > maxHP)
        {
            currentHP = maxHP;

        }
    }
}
