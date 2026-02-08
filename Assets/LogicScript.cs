using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LogicScript : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public int playerscore;
    public Text scoreText;
    public GameObject GameOverScreen;

    [ContextMenu("Increase score")]
    public void addScores(int scoreToAdd)
    {
        playerscore += scoreToAdd;
        scoreText.text = playerscore.ToString();
        // This will update the score text UI with the current score
    }
    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        // This will restart the game by reloading the current scene
    }
    public void GameOver()
    {
        GameOverScreen.SetActive(true);
        // This will activate the game over screen UI
    }
}
