using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    public Player player;
    public float speed = 5.0f;

    // Start is called before the first frame update
    void Start()
    {
        transform.position += (Vector3)((Vector2)(player.transform.position - transform.position));
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 diff = (Vector2)(player.transform.position - transform.position);
        transform.position += diff * speed * Time.deltaTime;
    }
}
