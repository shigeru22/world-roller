using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Call only in Gameplay scene.
/// </summary>
public class GameManager : MonoBehaviour
{
    private static GameManager instance;

    /// <summary>
    /// Public GameManager instance.
    /// </summary>
    public static GameManager Instance { get { return instance; } }

    // inspector variables
    [Tooltip("Sets default livestocks.")] [Range(1, 10)] public int defaultLives;
    [Tooltip("Sets default timer time.")] [Range(60, 300)] public int defaultTime;

    // private variables
    private int _score;
    private int _stars;
    private int _coins;
    private float _health;
    private int _lives;
    private float _timer;
    private bool timerStarted; // whether the timer is counting down

    /// <summary>
    /// Returns current playing status.
    /// Usually used for scene checks.
    /// </summary>
    public bool isPlaying { get; private set; }

    // score variables
    /// <summary>
    /// Returns current score.
    /// </summary>
    public int score
    {
        get { return _score; }
        private set { _score = value; }
    }

    public int stars
    {
        get { return _stars; }
        private set { _stars = value; }
    }

    public int coins
    {
        get { return _coins; }
        private set { _coins = value; }
    }

    // health variables
    /// <summary>
    /// Returns current health.
    /// </summary>
    public float health
    {
        get { return _health; }
        private set { _health = value; }
    }
    /// <summary>
    /// Returns current livestock.
    /// </summary>
    public int lives
    {
        get { return _lives; }
        private set { _lives = value; }
    }

    // time variables
    /// <summary>
    /// Returns current timer left.
    /// </summary>
    public float timer
    {
        get { return _timer; }
        private set { _timer = value; }
    }

    void Awake()
    {
        if (instance != null && instance != this) Destroy(gameObject);
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }

        Debug.Log($"Default lives: {defaultLives}, time: {defaultTime}");
    }

    void Start()
    {
        
    }

    void Update()
    {
        if (timerStarted)
        {
            timer -= Time.deltaTime;
        
            if (timer < 0f)
            {
                StopTimer();
                timer = 0f;
            }
        }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="target"></param>
    public void SetPlayingStatus(bool target) { isPlaying = target; }

    /// <summary>
    /// Increases the score with the specified amount.
    /// </summary>
    /// <param name="amount">Amount of scores to be increased.</param>
    public void IncreaseScore(int amount) { score += amount; }

    /// <summary>
    /// Resets the score to 0.
    /// </summary>
    public void ResetScore() { score = 0; }

    /// <summary>
    /// Increases star count by 1.
    /// </summary>
    public void AddStar() { stars++; }

    /// <summary>
    /// Resets the star count to 0.
    /// </summary>
    public void ResetStar() { stars = 0; }

    /// <summary>
    /// Increases coin count by 1.
    /// </summary>
    public void AddCoin() { coins++; }

    /// <summary>
    /// Resets the coin count to 0.
    /// </summary>
    public void ResetCoin() { coins = 0; }

    /// <summary>
    /// Decreases the health with the specified amount.
    /// </summary>
    /// <param name="amount">Amount of health to be decreased.</param>
    public void DecreaseHealth(float amount)
    {
        Debug.Log($"Decreasing health by {amount}.");
        health -= amount;
        if (health < 0f) health = 0f;
    }

    /// <summary>
    /// Resets the health to its fullest.
    /// </summary>
    public void ResetHealth() { health = 100f; }

    /// <summary>
    /// Adds the livestock by one.
    /// </summary>
    public void AddStock() { lives++; }

    /// <summary>
    /// Adds the livestock by the specified amount.
    /// </summary>
    /// <param name="amount">Amount of livestock to be added.</param>
    public void AddStock(int amount) { lives += amount; }

    /// <summary>
    /// Decreases the livestock by one.
    /// </summary>
    public void DecreaseStock()
    {
        lives--;
        if (lives < 0) lives = 0;
    }
    
    /// <summary>
    /// Decreases the livestock by the specified amount.
    /// </summary>
    public void DecreaseStock(int amount)
    {
        lives -= amount;
        if (lives < 0) lives = 0;
    }

    /// <summary>
    /// Resets the livestock.
    /// </summary>
    public void ResetStock() { lives = defaultLives; }

    /// <summary>
    /// Starts the timer.
    /// </summary>
    public void StartTimer() { timerStarted = true; }

    /// <summary>
    /// Stops the timer.
    /// </summary>
    public void StopTimer() { timerStarted = false; }

    /// <summary>
    /// Adds the timer with the specified time.
    /// </summary>
    /// <param name="seconds">Seconds to add.</param>
    public void AddTimer(float seconds) { timer += seconds; }

    /// <summary>
    /// Resets the timer with the time specified in defaultTimer.
    /// Stops the timer if already started.
    /// </summary>
    public void ResetTimer()
    {
        timerStarted = false;
        timer = defaultTime;
    }
}
