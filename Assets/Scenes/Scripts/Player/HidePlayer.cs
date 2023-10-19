using UnityEngine;
using System.Collections;

public class HidePlayer : MonoBehaviour
{
    [Header("Components")]
    [SerializeField] private Player player;

    private bool isHide;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !isHide)
        {
            StartCoroutine(Delay());
        }
    }

    private IEnumerator Delay()
    {
        isHide = true;
        yield return new WaitForSeconds(1f);

        if (player != null)
        {
            player.gameObject.SetActive(false);
        }
    }
}
