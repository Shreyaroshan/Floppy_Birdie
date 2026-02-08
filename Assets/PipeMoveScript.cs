using UnityEngine;

public class PipeMoveScript : MonoBehaviour
{
    // Start is called
    //  once before the first execution of Update after the MonoBehaviour is created
    public float movespeed = 9;
    public float deathzone = -45;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.position += Vector3.left * movespeed * Time.deltaTime;
        if (transform.position.x < deathzone)
        {
            Destroy(gameObject);
            // This will destroy the pipe when it goes past the death zone
        }
    }
}
