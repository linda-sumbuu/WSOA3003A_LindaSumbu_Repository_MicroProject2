using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MCCamera : MonoBehaviour
{
    public GameObject Player;

    public Vector3 offset;

    

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

   

    private void LateUpdate()
    {
        transform.position = Player.transform.position + offset;
    }
}
