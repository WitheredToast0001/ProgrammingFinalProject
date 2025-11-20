using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController2 : MonoBehaviour
{
    public float moveSpeed;
    public float jumpPower;
    private int lowBound = -1;
    private Rigidbody playerRb;
    private string SampleScene;
    private bool onGround;
    private bool gameOver = false;
    private bool hasPowerup;
    public GameObject powerupIndicator;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        string scene = SceneManager.GetActiveScene().name;
    }

    // Update is called once per frame
    void Update()
    {
        float horizInput = Input.GetAxisRaw("Horizontal");
        float vertInput = Input.GetAxisRaw("Vertical");
        transform.Translate(Vector3.forward * vertInput * moveSpeed * Time.deltaTime);
        transform.Translate(Vector3.right * horizInput * moveSpeed * Time.deltaTime);
        if (Input.GetKeyDown(KeyCode.Space) && onGround)
        {
            playerRb.AddForce(Vector3.up * jumpPower, ForceMode.Impulse);
            onGround = false;
        }
        if (playerRb.position.y < 0)
        {
            Debug.Log("Player left the playing field, reloading scene!");
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Platform"))
        {
            onGround = true;
        }
        else if (collision.gameObject.CompareTag("Obstacle") && hasPowerup != true)
        {
            Debug.Log("Obstacle touched, Game Over!");
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
        else if (collision.gameObject.CompareTag("Obstacle") && hasPowerup == true)
        {
            Debug.Log("You have been saved by the mighty golden sphere!");
            Destroy(collision.gameObject);
            powerupIndicator.gameObject.SetActive(false);
            hasPowerup = false;
        } 
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Powerup"))
        {
            Destroy(other.gameObject);
            hasPowerup = true;
            powerupIndicator.gameObject.SetActive(true);
        }
    }
}
 