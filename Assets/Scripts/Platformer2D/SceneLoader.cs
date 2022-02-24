using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Platformer2D
{
    public class SceneLoader : MonoBehaviour
    {
        public Button playButton;
        public Button exitButton;
        private void Start()
        {
            playButton.onClick.AddListener(() => SceneManager.LoadScene(1));
            exitButton.onClick.AddListener(Application.Quit);
        }
    }
}
