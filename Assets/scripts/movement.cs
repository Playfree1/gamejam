using UnityEngine;
using System.Collections;

public class movement : MonoBehaviour
{
    private Rigidbody2D rb;
    public float speed;
    private bool canDash;
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
                rb.constraints = RigidbodyConstraints2D.None;
               rb.velocity = new Vector3(Input.GetAxis("Horizontal") * Time.fixedDeltaTime * speed, Input.GetAxis("Vertical") * Time.fixedDeltaTime * speed, 0);
            }
            else
            {
                rb.constraints = RigidbodyConstraints2D.FreezePosition;
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
            rb.constraints = RigidbodyConstraints2D.None;
            Vector3 direction = new Vector3(Input.GetAxis("Horizontal") * Time.fixedDeltaTime * speed * 7, Input.GetAxis("Vertical") * Time.fixedDeltaTime * speed * 7, 0);
            rb.AddForce(direction, ForceMode2D.Impulse);
        }
        else
        {
            yield return new WaitForSeconds(1.5f);
            canDash = true;
        }


    }
}
