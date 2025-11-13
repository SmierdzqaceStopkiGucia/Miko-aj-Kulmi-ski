using UnityEngine;

public class MovementController : MonoBehaviour
{
    public new Rigidbody2D rigidbody { get; private set; }
    private Vector2 direction = Vector2.down;
    public float speed = 5f;

    [Header("Input")]
    public KeyCode inputUp = KeyCode.W;
    public KeyCode inputDown = KeyCode.S;
    public KeyCode inputLeft = KeyCode.A;
    public KeyCode inputRight = KeyCode.D;

    public AnimatedSpriteRenderer SpriteRendererUp;
    public AnimatedSpriteRenderer SpriteRendererDown;
    public AnimatedSpriteRenderer SpriteRendererLeft;
    public AnimatedSpriteRenderer SpriteRendererRight;
    public AnimatedSpriteRenderer SpriteRendererDeath;
    private AnimatedSpriteRenderer ActiveSpriteRenderer;

    private void Awake()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        ActiveSpriteRenderer = SpriteRendererDown;
    }

    private void Update()
    {
        if (Input.GetKey(inputUp)) {
            SetDirection(Vector2.up, SpriteRendererUp);
        } else if (Input.GetKey(inputDown)) {
            SetDirection(Vector2.down, SpriteRendererDown);
        } else if (Input.GetKey(inputLeft)) {
            SetDirection(Vector2.left, SpriteRendererLeft);
        } else if (Input.GetKey(inputRight)) {
            SetDirection(Vector2.right, SpriteRendererRight);
        } else {
            SetDirection(Vector2.zero, ActiveSpriteRenderer);
        }
    } 
    
    private void FixedUpdate()
    {
        Vector2 position = rigidbody.position;
        Vector2 translation = direction * speed * Time.fixedDeltaTime;

        rigidbody.MovePosition(position + translation);
    }

    private void SetDirection(Vector2 newDirection, AnimatedSpriteRenderer SpriteRenderer)
    {
        direction = newDirection;

        SpriteRendererUp.enabled = SpriteRenderer == SpriteRendererUp;
        SpriteRendererDown.enabled = SpriteRenderer == SpriteRendererDown;
        SpriteRendererLeft.enabled = SpriteRenderer == SpriteRendererLeft;
        SpriteRendererRight.enabled = SpriteRenderer == SpriteRendererRight;

        ActiveSpriteRenderer = SpriteRenderer;
        ActiveSpriteRenderer.idle = direction == Vector2.zero;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Explosion")) {
            DeathSequence();
        }
    }

    private void DeathSequence()
    {
        enabled = false;
        GetComponent<BombController>().enabled = false;

        SpriteRendererUp.enabled = false;
        SpriteRendererDown.enabled = false;
        SpriteRendererLeft.enabled = false;
        SpriteRendererRight.enabled = false;
        SpriteRendererDeath.enabled = true;

        Invoke(nameof(OnDeathSequenceEnded), 1.25f);
    }    

    private void OnDeathSequenceEnded()
    {
        gameObject.SetActive(false);
        Object.FindAnyObjectByType<GameManager>().CheckWinState();
    }

}
