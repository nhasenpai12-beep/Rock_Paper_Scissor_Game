using UnityEngine;
using UnityEngine.SceneManagement; // Required for switching scenes

public class MenuController : MonoBehaviour
{
    public void StartGame()
    {
        // IMPORTANT: The name inside "" must match your Game Scene file name EXACTLY
        SceneManager.LoadScene("GameScene");
    }
}