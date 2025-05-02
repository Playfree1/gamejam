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
               Vector2 _direction = new Vector2(Input.GetAxis("Horizontal") * Time.deltaTime * speed, Input.GetAxis("Vertical") * Time.deltaTime * speed);
                _direction.Normalize();
                rb.velocity = _direction;
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
            Vector3 direction = new Vector3(Input.GetAxis("Horizontal") * Time.fixedDeltaTime * speed * 10, Input.GetAxis("Vertical") * Time.fixedDeltaTime * speed * 10, 0);
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
