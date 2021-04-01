using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MCCamera2 : MonoBehaviour
{
    public GameObject Player;

    public Vector3 offset;

    public Animator camAnim;

    static public bool isShaking;

    private void Start()
    {
        offset = transform.position - Player.transform.position;
        
    }

    private void Update()
    {
        if (Player == null)
        {
            return;
        }
    }

 

    public void CamShake()
    {
        camAnim.SetTrigger("Shake");
        isShaking = true;

    }

    public void isIdle()
    {
        camAnim.SetTrigger("Idle");
        isShaking = false;
    }
    private void LateUpdate()
    {
        transform.position = Player.transform.position + offset;
    }
}
