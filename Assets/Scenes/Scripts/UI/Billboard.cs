using UnityEngine;

public class Billboard : MonoBehaviour
{
    public Transform levelTransform;

    private void LateUpdate()
    {
        if (levelTransform != null)
        {
            transform.position = levelTransform.position;
        }
    }
}
