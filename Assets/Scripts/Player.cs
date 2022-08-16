using Assets.Scripts;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public float BounceSpeed;
    public Rigidbody Rigidbody;
    public Game Game;
    public Platform CurrentPlatform;
    public Text Text, Text2;
    public static int _breakingPlatforms;
    public static int bestScore;
    public AudioSource bounceAudio;
    public AudioSource platformBreakingAudio;
    [SerializeField] ParticleSystem _paintSplash;
    [SerializeField] ParticleSystem _platformDestruction;
    //public GameObject splitPrefab;

    public void Awake()
    {
        
        if (PlayerPrefs.HasKey("SaveScore"))
        {
            bestScore = PlayerPrefs.GetInt("SaveScore");
        }
    }
    public void Bounce()
    {
        
        Rigidbody.velocity = new Vector3 (0, BounceSpeed, 0);
        bounceAudio.Play();
        _paintSplash.Play();
        

    }

    public void ReachFinish()
    {
        
        Game.OnPlayerReachedFinish();
        Rigidbody.velocity = Vector3.zero;
        
    }

    public void Die()
    {
        Game.OnPlayerDied();
        Rigidbody.velocity = Vector3.zero;
    }

    private void OnTriggerExit(Collider other)
    {
        CountBreakingPlatforms();
        
        
    }

    private int CountBreakingPlatforms()
    {
        ++_breakingPlatforms;
        BestScore();
        platformBreakingAudio.Play();
        _platformDestruction.Play();
        return _breakingPlatforms;
        
    }

    private void Update()
    {
        Text.text = _breakingPlatforms.ToString();
        Text2.text = "BEST SCORE: " + bestScore.ToString();
    }

    public void BestScore()
    {
        if (_breakingPlatforms > bestScore)
        {
            bestScore = _breakingPlatforms;
            PlayerPrefs.SetInt("SaveScore", bestScore);
        }
    }
    
}
