using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    public void ChangeScenes(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}
