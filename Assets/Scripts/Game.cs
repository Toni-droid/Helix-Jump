using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Game : MonoBehaviour
{
    [SerializeField] ParticleSystem _confetti;

    public Control Control;
    
    public enum State
    {
        Playing,
        Won,
        Lose,
    }
    public State CurrentState { get; private set; }

    public void OnPlayerDied()
    {
        if (CurrentState != State.Playing) return;
        CurrentState = State.Lose;
        Control.enabled = false;
        Debug.Log("Game over!");
        ReloadLevel();
        Player._breakingPlatforms = 0;
    }

    public void OnPlayerReachedFinish()
    {
        if (CurrentState != State.Playing) return;

        CurrentState= State.Won;
        Control.enabled = false;
        LevelIndex++;
        _confetti.Play();
        //MenuManager.MainMenuManager.CallingMenu_VictoryScreen();
        // ReloadLevel();
    }

    public int LevelIndex
    {
        get => PlayerPrefs.GetInt("LevelIndex", 0);
        private set
        {
            PlayerPrefs.SetInt(LevelIndexKey, value);
            PlayerPrefs.Save();
        }
    }

    
    private const string LevelIndexKey = "LevelIndex";
    
    private void ReloadLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    //public void CallingMenu_VictoryScreen() 
    //{
    //    _menu_WinScreen.SetActive(true);
    //}
}
