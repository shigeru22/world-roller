using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Call only in Gameplay scene.
/// </summary>
public class GameManager : MonoBehaviour
{
    private static GameManager instance;
    public static GameManager Instance { get { return instance; } }

    // inspector veriables
    [Tooltip("Sets default livestocks.")] [Range(1, 10)] public int defaultLives;
    [Tooltip("Sets default timer time.")] [Range(60, 300)] public int defaultTime;

    // internal variables (this class only)
    internal int _score;
    internal float _health;
    internal int _lives;
    internal float _timer;
    internal bool timerStarted; // whether the timer is counting down

    // score variables
    /// <summary>
    /// Returns current score.
    /// </summary>
    public int score
    {
        get { return _score; }
        internal set { _score = value; }
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
        internal set { _lives = value; }
    }

    // time variables
    /// <summary>
    /// Returns current timer left.
    /// </summary>
    public float timer
    {
        get { return _timer; }
        internal set { _timer = value; }
    }

    void Awake()
    {
        // add scene check later

        if (instance != null && instance != this) Destroy(gameObject);
        else DontDestroyOnLoad(gameObject);
    }

    void Start()
    {
        ResetHealth();
        ResetTimer();
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
    /// Increases the score with the specified amount.
    /// </summary>
    /// <param name="amount">Amount of scores to be increased.</param>
    public void IncreaseScore(int amount) { score += amount; }

    /// <summary>
    /// Resets the score to 0.
    /// </summary>
    public void ResetScore() { score = 0; }

    /// <summary>
    /// Decreases the health with the specified amount.
    /// </summary>
    /// <param name="amount">Amount of health to be decreased.</param>
    public void DecreaseHealth(float amount)
    {
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
