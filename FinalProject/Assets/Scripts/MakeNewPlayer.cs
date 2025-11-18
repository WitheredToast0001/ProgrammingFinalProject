using Unity.VisualScripting;
using UnityEngine;

public class MakeNewPlayer : MonoBehaviour
{
    public GameObject playerPrefab;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        GameObject player = GameObject.FindWithTag("Player");
        if (player == null)
        {
            Instantiate(playerPrefab, new Vector3(0, 1.1f, 0), player.transform.rotation);
        }
    }
}
