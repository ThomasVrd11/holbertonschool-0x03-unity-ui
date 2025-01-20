using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
[SerializeField] private float speed = 5f;
private Rigidbody rb;
private int score = 0;
[SerializeField] private int health = 5;
    void Start()
    {
        // Get the Rigidbody component
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (health == 0)
        {
            Debug.Log("Game Over!");
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
    void FixedUpdate()
    {
        // Get the input from the player
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        // Create a new Vector3 to store the movement
        Vector3 movement = new Vector3(moveHorizontal, 0, moveVertical);

        // Add a force to the Rigidbody
        rb.AddForce(movement * speed);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Pickup"))
        {
            score++;
            Debug.Log("Score: " + score + "\nCollided with: " + other.name);
            Destroy(other.gameObject);
        }

        if (other.gameObject.CompareTag("Trap"))
        {
            health--;
            Debug.Log("Health: " + health + "\nCollided with: " + other.name);
            other.gameObject.SetActive(false);
        }

        if (other.gameObject.CompareTag("Goal"))
        {
            Debug.Log("You win!");
        }


    }
}
