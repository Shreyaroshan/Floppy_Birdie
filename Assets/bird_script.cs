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
