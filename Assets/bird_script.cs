using UnityEngine;
using UnityEngine.InputSystem;

public class bird_script : MonoBehaviour
{
    public LogicScript logic;
    public Rigidbody2D myRigidbody;
    public float flapstrength;
    public bool birdIsAlive = true;
    void Start()
    {
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
        // This will find the LogicScript component in the GameObject tagged "Logic"
    }

    void Update()
    {
        // Use the new Input System API
        if (Keyboard.current.spaceKey.wasPressedThisFrame && birdIsAlive)
        {
            // Check if the space key was pressed and the bird is alive
            myRigidbody.linearVelocity = Vector2.zero; // Reset velocity to avoid accumulating forces
            myRigidbody.angularVelocity = 0; // Reset angular velocity to prevent spinning
            // Apply the flap strength to the bird's rigidbody
            Flap();
        }

        // Check if bird is out of screen bounds
        CheckBirdBounds();
    }

    void CheckBirdBounds()
    {
        // Get the bird's position in world space
        Vector3 birdPosition = transform.position;

        // Get the camera's view frustum bounds
        float cameraHeight = Camera.main.orthographicSize * 2;
        float cameraWidth = cameraHeight * Camera.main.aspect;

        float cameraLeft = Camera.main.transform.position.x - cameraWidth / 2;
        float cameraRight = Camera.main.transform.position.x + cameraWidth / 2;
        float cameraBottom = Camera.main.transform.position.y - cameraHeight / 2;
        float cameraTop = Camera.main.transform.position.y + cameraHeight / 2;

        // Check if bird is outside the screen bounds
        if (birdPosition.x < cameraLeft || birdPosition.x > cameraRight ||
            birdPosition.y < cameraBottom || birdPosition.y > cameraTop)
        {
            if (birdIsAlive)
            {
                logic.GameOver();
                birdIsAlive = false;
            }
        }
    }
    void Flap()
    {
        myRigidbody.linearVelocity = Vector2.up * flapstrength;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        logic.GameOver();
        // This will call the GameOver method in LogicScript when the bird collides with something
        birdIsAlive = false;
    }
}
