using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] float jumpSpeed;
    private AudioSource audioSource;
    private Vector3 startingPosition;
    Rigidbody2D playerRigidBody;
    public GameManagement gameManager;
    // Start is called before the first frame update
    void Start()
    {
        startingPosition = transform.position;
        playerRigidBody = GetComponent<Rigidbody2D>();
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !GameManagement.IsGameOver)
        {
            playerRigidBody.velocity = Vector2.up * jumpSpeed;
            audioSource.PlayOneShot(audioSource.clip);
        }
        Fly();
    }

    void Fly()
    {
        var dir = playerRigidBody.velocity;
        if (dir.y > 0)
        {
            transform.rotation = Quaternion.Euler(new Vector3(0, 0, 15));
        }
        else if (dir.y < 0)
        {
            float angle = dir.y*5f;
            transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
        }
        else
        {
            transform.rotation = Quaternion.Euler(new Vector3(0, 0, 0));
        }
    }

    private void OnCollisionEnter2D(Collision2D collision2D)
    {
        gameManager.GameOver();
    }

    public void ResetPosition()
    {
        transform.position = startingPosition;
        playerRigidBody.velocity = Vector2.zero;
    }

    public void OnBecameInvisible()
    {
        gameManager.GameOver();
    }
}
