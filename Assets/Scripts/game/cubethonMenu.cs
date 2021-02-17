using UnityEngine;
using UnityEngine.SceneManagement;

public class cubethonMenu : MonoBehaviour
{
    public void startCubethon()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
  
}
