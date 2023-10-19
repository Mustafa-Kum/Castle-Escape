using UnityEngine;

public class EnemyAttackCollider : MonoBehaviour
{
    [Header("Components")]
    [SerializeField] private Enemy enemy;

    private void OnTriggerEnter(Collider other)
    {
        Player playerScript = other.GetComponent<Player>();

        if (playerScript != null)
        {
            if (playerScript.level < enemy.level)
            {
                playerScript.isDead = true;
                GameManager.instance.LevelEnd();
                other.gameObject.SetActive(false);
                Destroy(playerScript.levelText);
            }
        }
    }
}
