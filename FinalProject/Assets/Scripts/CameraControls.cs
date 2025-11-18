using UnityEngine;

public class CameraControls : MonoBehaviour
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
        GameObject player = GameObject.FindWithTag("Player");
        if(player != null )
        {
            transform.position = player.transform.position + offset;
        }
    }
}
