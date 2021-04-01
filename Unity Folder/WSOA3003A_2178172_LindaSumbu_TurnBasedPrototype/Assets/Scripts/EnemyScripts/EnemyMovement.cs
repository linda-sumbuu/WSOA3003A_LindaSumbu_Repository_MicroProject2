using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float enemySpeed;

    public bool enemyMovesRight;

    public Rigidbody2D EnemyRB;

    public float runSpeed;


    void Start()
    {
        EnemyRB = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (enemyMovesRight)
        {
            transform.Translate(2 * Time.deltaTime * enemySpeed, 0, 0);
            
        }

        else
        {
            transform.Translate(-2 * Time.deltaTime * enemySpeed, 0, 0);
            
        }


    }

    private void OnTriggerEnter2D(Collider2D walltrigger)
    {
        if (walltrigger.gameObject.CompareTag("EnemyWallTurn"))
        {
            if (enemyMovesRight)
            {
                enemyMovesRight = false;
            }

            else
            {
                enemyMovesRight = true;
            }
        }


    }
}
