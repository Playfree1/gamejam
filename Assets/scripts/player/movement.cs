using UnityEngine;
using System.Collections;

public class movement : MonoBehaviour
{
    private Rigidbody2D rb;
    public float speed;
    private bool canDash = true;
    int count;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

   
    void FixedUpdate()
    {
        if(rb != null)
        {
            if (Mathf.Abs(Input.GetAxis("Horizontal")) > 0 || (Mathf.Abs(Input.GetAxis("Vertical")) > 0))
            {
               rb.velocity = new Vector3(Input.GetAxis("Horizontal") * Time.fixedDeltaTime * speed, Input.GetAxis("Vertical") * Time.fixedDeltaTime * speed, 0);
            }
            if(Mathf.Abs(Input.GetAxis("Fire3")) > 0)
            {
                StartCoroutine(Dash());
            }
        }
    }
    IEnumerator Dash()
    {
        if (canDash)
        {
            canDash = false;
            Vector3 direction = new Vector3(Input.GetAxis("Horizontal") * Time.fixedDeltaTime * speed * 7, Input.GetAxis("Vertical") * Time.fixedDeltaTime * speed * 7, 0);
            rb.AddForce(direction, ForceMode2D.Impulse);
            StopAllCoroutines();
        }
        else
        {
            yield return new WaitForSeconds(.5f);
            canDash = true;
        }


    }
}
