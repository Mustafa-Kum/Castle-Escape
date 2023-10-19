using UnityEngine;

public enum KeyState
{
    PurpleKeyState,
    YellowKeyState
}

public class Key : Collectable
{
    [Header("Components - Key")]
    [SerializeField] private Door door;
    [SerializeField] private GameObject purpleKeyImage;
    [SerializeField] private GameObject yellowKeyImage;
    public bool purpleKey;
    public bool yellowKey;
    public KeyState keyState;

    protected override void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (keyState == KeyState.PurpleKeyState)
            {
                base.Collect();
                purpleKeyImage.SetActive(true);
                purpleKey = true;
            }
            else if (keyState == KeyState.YellowKeyState)
            {
                base.Collect();
                yellowKeyImage.SetActive(true);
                yellowKey = true;
            }
        }
    }
}
