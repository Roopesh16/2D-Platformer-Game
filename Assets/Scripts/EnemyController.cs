using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField] private Transform position1;
    [SerializeField] private Transform position2;
    [SerializeField] private float enemySpeed;

    private bool isPos1 = true;
    private Vector2 enemyScale;

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.GetComponent<PlayerController>() != null)
        {
            AudioManager.Instance.PlaySfx(AudioTypes.HIT);
            other.gameObject.GetComponent<PlayerController>().ReduceHealth();
        }
    }

    private void Start()
    {
        position1.position = new Vector2(position1.position.x, transform.position.y);
        position2.position = new Vector2(position2.position.x, transform.position.y);
        transform.position = position1.position;
        GetComponent<Animator>().SetBool("IsWalk", true);
        enemyScale = transform.localScale;
    }

    private void Update()
    {
        ToFroMotion();
    }

    private void ToFroMotion()
    {
        if (transform.position == position2.position)
        {
            isPos1 = false;
        }

        if (transform.position == position1.position)
        {
            isPos1 = true;
        }

        if (isPos1 == true)
        {
            transform.position = Vector2.MoveTowards(transform.position, position2.position, enemySpeed * Time.deltaTime);
            enemyScale.x = Mathf.Abs(enemyScale.x);
            transform.localScale = enemyScale;
        }
        else
        {
            transform.position = Vector2.MoveTowards(transform.position, position1.position, enemySpeed * Time.deltaTime);
            enemyScale.x = -1f * Mathf.Abs(enemyScale.x);
            transform.localScale = enemyScale;
        }
    }
}
