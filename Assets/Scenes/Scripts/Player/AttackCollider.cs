using UnityEngine;

public class AttackCollider : MonoBehaviour
{
    [Header("Components")]
    [SerializeField] private Player player;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            Enemy enemyScript = other.GetComponent<Enemy>();

            if (enemyScript != null)
            {
                if (enemyScript.level < player.level)
                {
                    other.gameObject.SetActive(false);
                    enemyScript.wood.SetActive(false);
                    Destroy(enemyScript.levelText);

                    GameManager gameManager = GameManager.instance;
                    if (gameManager != null)
                    {
                        gameManager.woodNumber++;
                    }
                }
            }
        }
    }
}
