using UnityEngine;

public class KeyDoorOpen : MonoBehaviour
{
    [Header("Components")]
    [SerializeField] private Door door;
    [SerializeField] private Key key;
    [SerializeField] private GameObject purpleKeyImage;
    [SerializeField] private GameObject yellowKeyImage;

    private bool doorOpened;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && key.purpleKey)
        {
            if (!doorOpened)
            {
                doorOpened = true;
                door.Open();
                purpleKeyImage.SetActive(false);
            }
        }

        if (other.CompareTag("Player") && key.yellowKey)
        {
            if (!doorOpened)
            {
                doorOpened = true;
                door.Open();
                yellowKeyImage.SetActive(false);
            }
        }
    }
}
