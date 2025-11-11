using UnityEngine;

public class Camera : MonoBehaviour
{
    public GameObject player;
    private Vector3 offset = new Vector3(0, 2.75f, -1.5f);
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void LateUpdate()
    {
        transform.position = player.transform.position + offset;
    }
}
