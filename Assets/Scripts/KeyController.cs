using UnityEngine;

public class KeyController : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.GetComponent<PlayerController>() != null)
        {
            AudioManager.Instance.PlaySfx(AudioTypes.KEY);
            other.GetComponent<PlayerController>().UpdateScore();
            Destroy(gameObject);
        }
    }
}
