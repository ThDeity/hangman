using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody rb;
    public GameManager gm;

    [SerializeField] private float runSpeed = 500f, strafeSpeed = 500f, jumpForce = 15f;

    void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Obstacle")
        {
            gm.EndGame();

            Debug.Log("Конец игры!");
        }
    }

    void FixedUpdate()
    {
        rb.MovePosition(transform.position + Vector3.forward * runSpeed * Time.deltaTime);

        if (Input.GetAxis("Horizontal") < 0)
            rb.AddForce(-strafeSpeed * Time.deltaTime, 0, 0, ForceMode.VelocityChange);

        if (Input.GetAxis("Horizontal") > 0)
            rb.AddForce(strafeSpeed * Time.deltaTime, 0, 0, ForceMode.VelocityChange);

        if (Input.GetKey(KeyCode.Space))
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
    }
}