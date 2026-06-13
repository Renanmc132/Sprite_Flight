using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UIElements;

public class UIFunction : MonoBehaviour
{

    [Header("UI")]
    public UIDocument uiDocument;
    private Button restartButton;
    private Button mainMenuButton;
    private Button exitButton;
    private Label scoreText;

    [Header("Score")]
    private float elapsedTime = 0f;
    private float score = 0f;
    private float scoreMultiplier = 10f;

    private void Awake()
    {
        scoreText = uiDocument.rootVisualElement.Q<Label>("ScoreLabel");
        restartButton = uiDocument.rootVisualElement.Q<Button>("RestartButton");
        mainMenuButton = uiDocument.rootVisualElement.Q<Button>("MenuButton");
        exitButton = uiDocument.rootVisualElement.Q<Button>("ExitButton");

        mainMenuButton.clicked += MenuScene;
        restartButton.clicked += ReloadScene;
        exitButton.clicked += ExitGame;
    }

    private void Update()
    {
        Score();
        if (PlayerController.playerDeath)
        {
            mainMenuButton.style.display = DisplayStyle.Flex;
            restartButton.style.display = DisplayStyle.Flex;
            exitButton.style.display = DisplayStyle.Flex;
        }
        else
        {
            restartButton.style.display = DisplayStyle.None;
            mainMenuButton.style.display = DisplayStyle.None;
            exitButton.style.display = DisplayStyle.None;
        }
    }

    private void Score()
    {
        elapsedTime += Time.deltaTime;
        score = Mathf.FloorToInt(elapsedTime * scoreMultiplier);
        scoreText.text = "Score: " + score;
    }

    private void ReloadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    
    }

    private void MenuScene()
    {
        SceneManager.LoadScene("Menu");
    }

    private void ExitGame()
    {
        Application.Quit();
    }




}
