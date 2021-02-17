using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class EndTrigger : MonoBehaviour
{

    public GameManager gameManager;
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("hi");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

}
