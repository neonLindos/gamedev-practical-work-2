using UnityEngine;

public class JumpCube : MonoBehaviour
{
    [SerializeField] private float jumpForce = 5f;
    [SerializeField] private float rayDistance = 1.1f; // длина луча вниз
    public Rigidbody rb;

  

    private void Update()
    {
        // стреляем лучом вниз от центра куба
        if (Physics.Raycast(transform.position, Vector3.down, out RaycastHit hit, rayDistance))
        {
            if (hit.collider.CompareTag("floor"))
            {
                Debug.Log("Ray hit floor — jumping!");
                rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            }
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawLine(transform.position, transform.position + Vector3.down * rayDistance);
    }
}
