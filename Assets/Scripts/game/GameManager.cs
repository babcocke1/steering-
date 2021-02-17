
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
    public GameObject completeLevelUI;
    bool gameEnded = false;
    public float restartDelay = 1.0f;
    public void EndGame ()
    {
        if (gameEnded == false)
        {
            Debug.Log("game over");
            gameEnded = true;
            Invoke("Restart", restartDelay);
        }
        
    }

    void Restart ()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void completeLevel()
    {
        Debug.Log("level1");
    }
}
