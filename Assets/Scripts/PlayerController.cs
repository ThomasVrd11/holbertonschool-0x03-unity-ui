using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float speed = 5.0f;
    [SerializeField] Rigidbody rb;
    

    public Text scoreText;
    public int health = 5;
    private int score = 0;

    void FixedUpdate()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector3 move = new Vector3(horizontalInput, 0, verticalInput);
        rb.linearVelocity = new Vector3(horizontalInput * speed, rb.linearVelocity.y, verticalInput * speed);
    }

    void Update()
    {
        if (health == 0)
            {
                Debug.Log("Game Over!");
                SceneManager.LoadScene(this.gameObject.scene.name);
            }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Pickup"))
        {
            score++;
            SetScoreText();
            //Debug.Log($"Score: {score}");
            other.gameObject.SetActive(false);
        }
        else if (other.gameObject.CompareTag("Trap"))
        {
            health--;
            Debug.Log($"Health: {health}");
        }
        else if (other.gameObject.CompareTag("Goal"))
        {
            Debug.Log("You win!");
        }
    }

    private void SetScoreText()
    {
        scoreText.text = $"Score: {score}";
    }
}