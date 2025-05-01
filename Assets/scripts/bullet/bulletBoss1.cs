using System.Collections;
using UnityEngine;

public class bulletBoss1 : MonoBehaviour
{
    private GameObject player;
    IEnumerator Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        Vector2 vector2 = player.transform.position - transform.position;
        vector2.Normalize();
        transform.rotation = Quaternion.Euler(0,0,-Mathf.Atan2(vector2.x,vector2.y));
        transform.localScale = new Vector2(0.1f, Vector2.Distance(transform.position, player.transform.position));
        yield return new WaitForSeconds(0.3f);
        Destroy(gameObject);
    }


}
