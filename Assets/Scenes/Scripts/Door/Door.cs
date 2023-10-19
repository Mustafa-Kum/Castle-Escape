using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    [Header("Components")]
    [SerializeField] private BoxCollider doorCollider;
    [SerializeField] private GameObject DoorPrefab;

    [Header("Opening Info")]
    [SerializeField] private float openDuration;
    [SerializeField] private float openTargetY;

    private IEnumerator DoorCoroutine()
    {
        float currentOpenDuration = 0;
        Vector3 startPosition = DoorPrefab.transform.position;
        Vector3 targetPosition = startPosition + Vector3.up * openTargetY;

        while (currentOpenDuration <  openDuration)
        {
            currentOpenDuration += Time.deltaTime;
            DoorPrefab.transform.position = Vector3.Lerp(startPosition, targetPosition, currentOpenDuration / openDuration);

            yield return null;
        }

        doorCollider.enabled = false;
    }

    public void Open()
    {
        StartCoroutine(DoorCoroutine());
    }
}
