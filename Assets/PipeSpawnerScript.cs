using UnityEngine;

public class PipeSpawnerScript : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public GameObject Pipe;
    public float spawnRate = 50; // Time in seconds between spawns
    private float timer = 0;
    public float heightOffset = 10;
    void Start()
    {
        spawnPipe();
    }

    // Update is called once per frame
    void Update()
    {
        if (timer < spawnRate)
        {
            timer += Time.deltaTime;
        }
        else
        {
            spawnPipe();
            // This will spawn a pipe at the position of the spawner every frame
            timer = 0; // Reset the timer after spawning
        }
    }
    void spawnPipe()
    {
        float heightestpoint = transform.position.y + heightOffset;
        float lowestpoint = transform.position.y - heightOffset;
        Instantiate(Pipe, new Vector3(transform.position.x, Random.Range(lowestpoint, heightestpoint), 0), transform.rotation);
        // This will spawn a pipe at the position of the spawner
    }
}
