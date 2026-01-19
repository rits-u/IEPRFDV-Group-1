using UnityEngine;

public class TempBullet : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 4f;
    [SerializeField] private Vector3 rotationOffset;
    void Start()
    {
        transform.Rotate(rotationOffset);
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 direction = transform.rotation * Vector3.up;
        transform.position += direction * moveSpeed * Time.deltaTime;
    }
}
