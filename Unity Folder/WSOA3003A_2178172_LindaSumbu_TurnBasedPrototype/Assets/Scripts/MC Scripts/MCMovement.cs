using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MCMovement : MonoBehaviour
{
    public float moveSpeed;

    public CameraFancyStuff cameraD;

    private bool isFacingR = true;

    private float dirX;

    private Vector3 localScale;

    public Animator sceneAnim;

    public LevelLoaderScript levelLoader;

    public Rigidbody2D RB;
    void Start()
    {
        RB = GetComponent<Rigidbody2D>();
        localScale = transform.localScale;
        moveSpeed = 5f;
    }

    // Update is called once per frame
    void Update()
    {
        dirX = Input.GetAxisRaw("Horizontal") * moveSpeed;

        if (Input.GetButtonDown("Jump") && RB.velocity.y == 0)
            RB.AddForce(Vector2.up * 800f);
       
    }


    private void FixedUpdate()
    {
        RB.velocity = new Vector2(dirX, RB.velocity.y);
    }


    private void LateUpdate()
    {
        if (dirX > 0)
            isFacingR = true;

        else if (dirX < 0)
            isFacingR = false;

        if (((isFacingR) && (localScale.x < 0)) || ((!isFacingR) && localScale.x > 0))
            localScale.x *= -1;

        transform.localScale = localScale;

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            cameraD.shouldShake = true;
            levelLoader.LoadNextLevel();
           
        }
    }


}
