using UnityEngine;

public class BlueDoorOpen : MonoBehaviour
{
    [Header("Components")]
    [SerializeField] private Door door;

    [Header("Material Color")]
    [SerializeField] private Material yellowMaterial;

    private MeshRenderer objectRenderer;
    private bool doorOpened;

    private void Start()
    {
        objectRenderer = GetComponent<MeshRenderer>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player" && !doorOpened)
        {
            objectRenderer.material = yellowMaterial;
            door.Open();
            doorOpened = true;
        }
    }
}
