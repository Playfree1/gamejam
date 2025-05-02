using UnityEngine;

public class generator : MonoBehaviour
{
    [SerializeField] private Sprite Work, NonWork;
    public bool _powered;
    private SpriteRenderer _renderer;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Player")
        {
            _powered = true;
            
        }
    }

    void Start()
    {
        _renderer = GetComponent<SpriteRenderer>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        _powered = false;
    }
    private void Update()
    {
        if (_powered) _renderer.sprite = Work;
        else _renderer.sprite = NonWork;
    }
}
