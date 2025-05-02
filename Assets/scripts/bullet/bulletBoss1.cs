using System.Collections;
using UnityEngine;

public class bulletBoss1 : MonoBehaviour
{
    public Quaternion _rotate;
    IEnumerator Start()
    {
        yield return new WaitForSeconds(0.01f);
        Instantiate(transform.parent.gameObject, transform.GetChild(0).position, _rotate, transform.parent);
        yield return new WaitForSeconds(0.3f);
        Destroy(transform.parent.gameObject);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {

            Destroy(transform.root.gameObject);
        
    }

}
