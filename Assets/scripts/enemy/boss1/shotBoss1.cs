using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class shotBoss1 : MonoBehaviour
{
    private GameObject player;
    public GameObject bullet;
    private float count;
    public bool canShout;
    private Animator animator;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        animator = GetComponent<Animator>();
        animator.SetBool("isCatscene", true);
    }

    void Update()
    {
        if (canShout)
        {
            if (count > 1)
            {
                animator.SetBool("isCatscene", false);
                StartCoroutine(Shot());
                
                count = 0;
            }
            else { count += Time.deltaTime; }
        }
    }
    IEnumerator Shot()
    {
        Vector3 direction = player.transform.position - transform.position;
        Quaternion rotate = Quaternion.Euler(0, 0, -Mathf.Atan2(direction.x, direction.y) * Mathf.Rad2Deg + 90);
        yield return new WaitForSeconds(0.15f);
        GameObject obj = Instantiate(bullet, transform.position, rotate);
        obj.GetComponent<bulletBoss1>()._rotate = rotate;

    } 
}
