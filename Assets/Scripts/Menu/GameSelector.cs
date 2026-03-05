using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameSelector : MonoBehaviour
{
    public void ChooseGame(string scene)
    {
        SceneManager.LoadScene(scene);
    }
}
