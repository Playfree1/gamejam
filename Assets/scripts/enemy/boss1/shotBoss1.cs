using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

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
        if (Vector2.Distance(transform.position, player.transform.position) < 4f)
        {
            if (count > 1)
            {

                StartCoroutine(Shot());
                
                count = 0;
            }
            else { count += Time.deltaTime; }
        }
    }
    IEnumerator Shot()
    {
        Vector3 direction = player.transform.position - transform.position;
        Quaternion rotate = Quaternion.Euler(0, 0, -Mathf.Atan2(direction.x, direction.y) * Mathf.Rad2Deg);
        player = GameObject.FindGameObjectWithTag("Player");
        Vector2 vector2 = player.transform.position - transform.position;
        float distance = vector2.magnitude;
        vector2.Normalize();
        Quaternion _rotate = Quaternion.Euler(0, 0, -Mathf.Atan2(vector2.x, vector2.y) * Mathf.Rad2Deg - 90);
        Vector2 _scale = new Vector2(distance * 1.4f, 0.1f);
        yield return new WaitForSeconds(0.15f);
        GameObject obj = Instantiate(bullet, transform.position, rotate);
        obj.transform.rotation = _rotate;
        obj.transform.localScale = _scale;
    } 
}
