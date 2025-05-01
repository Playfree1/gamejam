using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camera : MonoBehaviour
{
    private GameObject player;
    private Rigidbody2D rb;
    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        rb = GetComponent<Rigidbody2D>();
    }
    void FixedUpdate()
    {
        var direction = (player.transform.position - transform.position) * 1.35f;
        
        rb.velocity = direction * 130f * Time.deltaTime;
    }
}
