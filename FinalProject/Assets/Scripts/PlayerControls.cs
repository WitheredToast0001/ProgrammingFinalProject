using UnityEngine;

public class PlayerControls : MonoBehaviour
{
    public float moveSpeed;
    private Rigidbody playerRb;
    public float jumpPower;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        float horizontalInput = Input.GetAxisRaw("Vertical");
        float verticalInput = Input.GetAxisRaw("Horizontal");
        transform.Translate(Vector3.right * verticalInput * moveSpeed * Time.deltaTime);
        transform.Translate(Vector3.forward * horizontalInput * moveSpeed * Time.deltaTime);
        if (Input.GetKeyDown(KeyCode.Space))
        {
            playerRb.AddForce(Vector3.up * jumpPower, ForceMode.Impulse);
        }
        if(playerRb.position.y < 0)
        {
            Destroy(gameObject);
        }
        if(Input.GetKeyDown(KeyCode.R))
        {
            transform.Translate(new Vector3(0, 1.1f, 0));
        }
    }
}
