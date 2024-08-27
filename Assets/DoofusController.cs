using UnityEngine;

public class DoofusController : MonoBehaviour
{
    public float moveSpeed = 3f; // Speed of Doofus
    private Vector3 moveDirection;

    void Update()
    {
        // Get input from arrow keys or WASD
        float moveX = Input.GetAxis("Horizontal");
        float moveZ = Input.GetAxis("Vertical");

        moveDirection = new Vector3(moveX, 0, moveZ).normalized;

        // Move Doofus
        transform.Translate(moveDirection * moveSpeed * Time.deltaTime);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Pulpit"))
        {
            // Increase score or other actions when stepping on a pulpit
            GameManager.instance.IncreaseScore();
        }
    }
}


