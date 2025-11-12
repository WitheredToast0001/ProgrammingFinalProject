using UnityEngine;

public class PlayerControls : MonoBehaviour
{
    public float moveSpeed;
    private Rigidbody playerRb;
    public float jumpPower;
    public GameObject player;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        GameObject player = GameObject.FindWithTag("Player");
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
            Instantiate(player, new Vector3(0, 1.1f, 0), player.transform.rotation);
        }
        if(Input.GetKeyDown(KeyCode.A))
        {
            transform.Translate(new Vector3(0, 1.1f, 0));
        }
    }
}
