using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartButton : MonoBehaviour
{
    public static void Restart()
    {
        SceneManager.LoadScene("GameScene");
    }
}
