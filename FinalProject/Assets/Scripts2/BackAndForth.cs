using UnityEngine;
using UnityEngine.InputSystem.Android;

public class BackAndForth : MonoBehaviour
{
    public int woahTooLeft = -5;
    public float woahTooRight = 2.5f;
    public float moveSpeed;
    public bool moveNow;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        moveNow = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (moveNow)
        {
            transform.Translate(Vector3.right * moveSpeed * Time.deltaTime);
        }
        if (gameObject.transform.position.x > woahTooRight)
        {
            moveNow = false;
        }
        if (moveNow == false)
        {
            transform.Translate(Vector3.left * moveSpeed * Time.deltaTime);
        }
        if (gameObject.transform.position.x < woahTooLeft)
        {
            moveNow = true;
        }
    }
}
