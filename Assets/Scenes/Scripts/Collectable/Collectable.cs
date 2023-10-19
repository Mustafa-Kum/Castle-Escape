using UnityEngine;

public class Collectable : MonoBehaviour
{
    [Header("Components - Collectable")]
    [SerializeField] protected Player player;

    [Header("Object Info")]
    [SerializeField] private float rotationSpeed = 50.0f;

    protected virtual void Update()
    {
        // Kendi ekseni etrafında dönme işlemi
        transform.Rotate(Vector3.up * rotationSpeed * Time.deltaTime);
    }

    protected virtual void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Collect();
        }
    }

    protected virtual void Collect()
    {
        // Toplanan nesneyi devre dışı bırak
        gameObject.SetActive(false);
    }
}
