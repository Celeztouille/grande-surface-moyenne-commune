using UnityEngine;
using UnityEngine.SceneManagement;

public class ReturnToMenu : MonoBehaviour
{
    [SerializeField] private string menuSceneName;
    
    public void ToMenu()
    {
        SceneManager.LoadScene(menuSceneName);
    }
}
