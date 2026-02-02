

using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float _velocity = 5f;
    [SerializeField] private AudioSource _pointSound;
    private Rigidbody2D _rb;
    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Flap();
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Game Over");
        GameController.Instance.GameOverTrigger(gameObject);
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if(GameController.Instance != null)
        {
            GameController.Instance.IncScore();
            GameController.Instance.PointSound(_pointSound);
        }
    }
    private void Flap()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            _rb.velocity = Vector2.up * _velocity;
        }
    }

        
    
}
