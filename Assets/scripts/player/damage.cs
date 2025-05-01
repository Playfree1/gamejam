using UnityEngine.UI;
using UnityEngine;

public class damage : MonoBehaviour
{
    [SerializeField] GameObject[] heard;
    [SerializeField] Sprite FullHeard;
    [SerializeField] Sprite EmptyHeard;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "EnemyBullet")
        {
            foreach (GameObject _heard in heard)
            {
                var parametr = _heard.GetComponent<heard>();
                if (parametr._IsFull)
                {
                    parametr._IsFull = false;
                    _heard.GetComponent<Image>().sprite = EmptyHeard;
                    return;
                }
            }
        }
    }
}
