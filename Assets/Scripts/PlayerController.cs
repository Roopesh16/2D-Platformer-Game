using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private GameUI gameUI;
    [SerializeField] private GameOverController gameOverController;
    [SerializeField] private float playerSpeed;
    [SerializeField] private float jumpSpeed;
    [SerializeField] private string nextScene;

    private Animator playerAnim;
    private Rigidbody2D playerRb;
    private float horizontalSpeed;
    private float verticalSpeed;
    private bool isGrounded;
    private int health = 3;
    private void Start()
    {
        playerAnim = GetComponent<Animator>();
        playerRb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        horizontalSpeed = Input.GetAxisRaw("Horizontal");
        verticalSpeed = Input.GetAxisRaw("Jump");

        PlayerAnimation();
        PlayerMovement();
    }

    private void OnCollisionStay2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Platform"))
        {
            isGrounded = true;
        }
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Platform"))
        {
            isGrounded = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {

        if (other.CompareTag("GameOver"))
        {
            GameOverMenu();
        }
    }

    private void GameOverMenu()
    {
        gameOverController.EnableGameOver();
    }

    private void PlayerAnimation()
    {
        playerAnim.SetFloat("Speed", horizontalSpeed);
        Vector2 scale = transform.localScale;
        if (horizontalSpeed < 0)
        {
            playerAnim.SetFloat("Speed", Mathf.Abs(horizontalSpeed));
            scale.x = -1f * Mathf.Abs(scale.x);
        }
        else
        {
            scale.x = Mathf.Abs(scale.x);
        }
        transform.localScale = scale;

        if (Input.GetKey(KeyCode.LeftControl))
        {
            playerAnim.SetBool("canCrouch", true);
        }
        else if (Input.GetKeyUp(KeyCode.LeftControl))
        {
            playerAnim.SetBool("canCrouch", false);
        }

        if (verticalSpeed > 0 && isGrounded)
        {
            AudioManager.Instance.PlaySfx(AudioTypes.JUMP);
            playerAnim.SetBool("canJump", true);
        }
        else
        {
            playerAnim.SetBool("canJump", false);
        }
    }

    private void PlayerMovement()
    {
        Vector2 playerPosition = transform.position;
        if (Mathf.Abs(horizontalSpeed) > 0)
        {
            playerPosition.x += horizontalSpeed * playerSpeed * Time.deltaTime;
            transform.position = playerPosition;
        }

        if (verticalSpeed > 0 && isGrounded)
        {
            playerRb.AddForce(new Vector2(0, jumpSpeed), ForceMode2D.Force);
        }
    }

    public void UpdateScore()
    {
        gameUI.UpdateScore(10);
    }

    public void ReduceHealth()
    {
        health--;

        gameUI.UpdateHealth(health);

        if (health == 0)
        {
            playerAnim.SetTrigger("isDead");
            Invoke("GameOverMenu",1);
            return;
        }
    }
}
