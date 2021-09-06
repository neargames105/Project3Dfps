using UnityEngine;
using UnityEngine.SceneManagement;

public class s_MenuManage : MonoBehaviour
{
    // Start is called before the first frame update
    public void PlayGame()
    {
        SceneManager.LoadScene(PlayerPrefs.GetInt("LevelIndex", 1));
    }
}
