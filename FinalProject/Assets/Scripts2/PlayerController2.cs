using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController2 : MonoBehaviour
{
    public float moveSpeed;
    public float jumpPower;
    private int lowBound = -1;
    private Rigidbody playerRb;
    private string startScene;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        string startScene = SceneManager.GetActiveScene().name;
    }

    // Update is called once per frame
    void Update()
    {
        float horizInput = Input.GetAxisRaw("Horizontal");
        float vertInput = Input.GetAxisRaw("Vertical");
        transform.Translate(Vector3.forward * vertInput * moveSpeed * Time.deltaTime);
        transform.Translate(Vector3.right * horizInput * moveSpeed * Time.deltaTime);
        if (Input.GetKeyDown(KeyCode.Space))
        {
            playerRb.AddForce(Vector3.up * jumpPower, ForceMode.Impulse);
        }
        if (playerRb.position.y < lowBound)
        {
            SceneManager.LoadScene(startScene);
        }
    }
}
