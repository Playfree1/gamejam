using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shotBoss1 : MonoBehaviour
{
    private GameObject player;
    public GameObject bullet;
    private float count;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    void Update()
    {
        if (Vector2.Distance(transform.position, player.transform.position) < 5f)
        {
            if (count > 1)
            {
                Debug.Log("Shot");
                Vector3 direction = player.transform.position - transform.position;
                Quaternion rotate = Quaternion.Euler(0, 0, -Mathf.Atan2(direction.x, direction.y) * Mathf.Rad2Deg);
                GameObject shot = Instantiate(bullet, transform.position, rotate);
                count = 0;
            }
            else count += Time.deltaTime;
        }
    }
}
