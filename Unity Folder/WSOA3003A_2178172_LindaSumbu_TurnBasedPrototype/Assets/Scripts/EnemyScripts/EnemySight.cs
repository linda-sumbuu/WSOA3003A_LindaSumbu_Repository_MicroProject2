using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySight : MonoBehaviour
{
    public EnemyMovement enemy;

    public MCMovement player;

    public Transform sight;

    public bool spotted = false;

    public LayerMask playerLayer;
    public Vector2 direction;

    public float raylength;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (enemy.enemyMovesRight)
        {
            direction = Vector3.right;
        }
        else
        {
            direction = Vector3.left;
        }

        UnityEngine.Vector3 rayCastStartPos = sight.position;

        Color raycolor = Color.red;

        RaycastHit2D playerHit = Physics2D.Raycast(rayCastStartPos, direction, raylength, playerLayer);

        spotted = playerHit;

        if (playerHit.collider != null)
        {
            if (playerHit.collider.tag == "Player")
            {


                enemy.runSpeed = 3;
                

            }

            else
            {
                enemy.runSpeed = 1;

            }


        }
        else
        {
            enemy.runSpeed = 1;


            
        }

        Debug.DrawRay(rayCastStartPos, direction * raylength, raycolor);

    }
}
