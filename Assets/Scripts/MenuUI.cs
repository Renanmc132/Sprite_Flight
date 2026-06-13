using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class MenuUI : MonoBehaviour
{
    [Header("UI")]
    public UIDocument uiDocument;
    private Button playButton;
    private Button optionsButton;
    private Button exitButton;
    private void Awake()
    {
        playButton = uiDocument.rootVisualElement.Q<Button>("PlayButton");
        optionsButton = uiDocument.rootVisualElement.Q<Button>("OptionsButton");
        exitButton = uiDocument.rootVisualElement.Q<Button>("ExitButton");

        playButton.clicked += PlayScene;
        exitButton.clicked += ExitGame;
    }

    private void PlayScene()
    {
        SceneManager.LoadScene("SampleScene");
    }

    private void ExitGame()
    {
        Application.Quit();
    }
}
