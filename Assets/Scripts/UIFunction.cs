using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UIElements;

public class UIFunction : MonoBehaviour
{

    [Header("UI")]
    public UIDocument uiDocument;
    private Button restartButton;
    private Label scoreText;

    [Header("Score")]
    private float elapsedTime = 0f;
    private float score = 0f;
    private float scoreMultiplier = 10f;

    private void Awake()
    {
        scoreText = uiDocument.rootVisualElement.Q<Label>("ScoreLabel");
        restartButton = uiDocument.rootVisualElement.Q<Button>("RestartButton");
        

        restartButton.style.display = DisplayStyle.None;
        restartButton.clicked += ReloadScene;
    }

    private void Update()
    {
        Score();
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

    

    




}
