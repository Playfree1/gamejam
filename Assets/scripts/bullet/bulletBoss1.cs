using System.Collections;
using UnityEngine;

public class bulletBoss1 : MonoBehaviour
{
    private GameObject player;
    IEnumerator Start()
    {

        yield return new WaitForSeconds(0.1f);
        Destroy(transform.parent.gameObject);
    }


}
