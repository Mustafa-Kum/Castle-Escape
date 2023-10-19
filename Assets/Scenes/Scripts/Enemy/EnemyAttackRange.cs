using UnityEngine;

public class EnemyAttackRange : MonoBehaviour
{
    [SerializeField] private Enemy enemy;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Animator enemyAnimator = enemy.GetComponent<Animator>();
            if (enemyAnimator != null)
            {
                enemyAnimator.SetTrigger("Attack");
            }
        }
    }
}
