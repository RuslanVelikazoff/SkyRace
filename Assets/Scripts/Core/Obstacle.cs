using UnityEngine;

public class Obstacle : MonoBehaviour
{
    private const string PLAYER_TAG = "Player";

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag(PLAYER_TAG))
        {
            GameManager.Instance.LoseGame();
            Destroy(this.gameObject);
        }
    }
}
