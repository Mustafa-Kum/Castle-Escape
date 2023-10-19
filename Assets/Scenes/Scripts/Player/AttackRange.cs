using UnityEngine;

public class AttackRange : MonoBehaviour
{
    [Header("Components")]
    [SerializeField] private Player player;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Enemy")
        {
            player.animator.SetTrigger("Attack");
        }
    }
}
