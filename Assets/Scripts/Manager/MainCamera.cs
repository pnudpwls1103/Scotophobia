using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCamera : MonoBehaviour
{
    public GameObject player;
    public bool flag;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 PlayerPos = player.transform.position;
        transform.position = new Vector3(player.transform.position.x, player.transform.position.y + 10, transform.position.z);
    }
}
