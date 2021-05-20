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
    private int _stage;
    private int _score;
    private int _stars;
    private int _coins;
    private int _gates;
    private float _health;
    private int _lives;
    private float _timer;
    private int _rotation;
    private bool _hyperspeedMode;
    private bool _timerStarted; // whether the timer is counting down
    private bool _invulnUnlock; // powerup unlock
    private bool _zenMode; // zen mode
    private float _mass; // player ball mass
    private bool _magnetUnlock; // powerup unlock
    private bool _magnetOn; // coin magnet powerup
    private int _coinMagnetLevel; // coin magnet level

    /// <summary>
    /// Returns current playing status.
    /// Usually used for scene checks.
    /// </summary>
    public bool isPlaying { get; private set; }

    /// <summary>
    /// Returns whether the level is completed.
    /// </summary>
    public bool isCompleted { get; private set; }

    /// <summary>
    /// Returns current paused status.
    /// </summary>
    public bool isPaused { get; private set; }

    /// <summary>
    /// Returns whether user selects hyperspeed mode.
    /// </summary>
    public bool hyperspeedMode { get { return _hyperspeedMode; } }

    /// <summary>
    /// Returns stage number;
    /// </summary>
    public int stageNumber { get { return _stage; } }

    // score variables
    /// <summary>
    /// Returns current score.
    /// </summary>
    public int score { get { return _score; } }

    /// <summary>
    /// Returns current stars count.
    /// </summary>
    public int stars { get { return _stars; } }

    /// <summary>
    /// Returns current coins count.
    /// </summary>
    public int coins { get { return _coins; } }

    /// <summary>
    /// Returns current gates count.
    /// </summary>
    public int gates { get { return _gates; } }

    // health variables
    /// <summary>
    /// Returns current health.
    /// </summary>
    public float health { get { return _health; } }
    /// <summary>
    /// Returns current livestock.
    /// </summary>
    public int lives { get { return _lives; } }

    // time variables
    /// <summary>
    /// Returns current timer left.
    /// </summary>
    public float timer { get { return _timer; } }

    // world specific
    public float worldRotation { get { return _rotation * 90f; } }


    //todo : change isInvuln to isZen
    /// <summary>
    /// Checks whether or not invulnerability mode is unlocked.
    /// </summary>
    public bool isInvulnUnlocked { get { return _invulnUnlock; } }

    /// <summary>
    /// Returns current invunerability status.
    /// Checks whether or not player is in invulnerability mode.
    /// </summary>
    public bool isZen { get { return _zenMode; } }

    /// <summary>
    /// Returns current mass of the ball.
    /// </summary>
    public float mass { get { return _mass; } }

    /// <summary>
    /// Returns current invunerability status.
    /// Checks whether or not coin magnet mode is unlocked.
    /// </summary>
    public bool isMagnetUnlock { get { return _magnetUnlock; } }

    /// <summary>
    /// Returns current coin magnet status.
    /// Checks whether or not player is in coin magnet mode.
    /// </summary>
    public bool isMagnet { get { return _magnetOn; } }

    /// <summary>
    /// Returns current coin magnet level.
    /// </summary>
    public float magnet { get { return _coinMagnetLevel; } }

    void Awake()
    {
        if (instance != null && instance != this) Destroy(gameObject);
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }

        // Debug.Log($"Default lives: {defaultLives}, time: {defaultTime}");
    }

    void Start()
    {
        
    }

    void Update()
    {
        if (_timerStarted)
        {
            _timer -= Time.deltaTime;
        
            if (timer < 0f)
            {
                StopTimer();
                _timer = 0f;
            }
        }
    }

    /// <summary>
    /// Resets all status.
    /// </summary>
    public void ResetAllStatus()
    {
        isPlaying = false;
        isCompleted = false;
        ResetCoin();
        ResetStar();
        ResetGate();
        ResetStock();
        ResetScore();
        ResetTimer();
        ResetWorldRotation();
    }

    /// <summary>
    /// Sets stage number.
    /// </summary>
    /// <param name="stage"></param>
    public void SetStageNumber(int stage) { _stage = stage; }

    /// <summary>
    /// Sets current playing status.
    /// </summary>
    /// <param name="target">Whether currently is playing.</param>
    public void SetPlayingStatus(bool target) { isPlaying = target; }

    /// <summary>
    /// Sets the level as complete.
    /// </summary>
    public void SetCompleted()
    {
        isCompleted = true;
        // TODO: Implement save here.
    }

    /// <summary>
    /// Sets paused status.
    /// </summary>
    /// <param name="target">Whether currently is paused.</param>
    public void SetPausedStatus(bool target) { isPaused = target; }

    /// <summary>
    /// Sets hyperspeed mode status.
    /// </summary>
    /// <param name="target"></param>
    public void SetHyperspeedMode(bool target) { _hyperspeedMode = target; }

    /// <summary>
    /// Rotates world (or camera perspective).
    /// </summary>
    /// <param name="target"></param>
    public void RotateWorld(RotationTargets target)
    {
        if (target.Equals(RotationTargets.Left)) _rotation--;
        else if (target.Equals(RotationTargets.Right)) _rotation++;
    }

    /// <summary>
    /// Resets current world rotation to 0.
    /// </summary>
    public void ResetWorldRotation() { _rotation = 0; }

    /// <summary>
    /// Increases the score with the specified amount.
    /// </summary>
    /// <param name="amount">Amount of scores to be increased.</param>
    public void IncreaseScore(int amount) { _score += amount; }

    /// <summary>
    /// Resets the score to 0.
    /// </summary>
    public void ResetScore() { _score = 0; }

    /// <summary>
    /// Increases star count by 1.
    /// </summary>
    public void AddStar() { _stars++; }

    /// <summary>
    /// Resets the star count to 0.
    /// </summary>
    public void ResetStar() { _stars = 0; }

    /// <summary>
    /// Increases coin count by 1.
    /// </summary>
    public void AddCoin() { _coins++; }

    /// <summary>
    /// Resets the coin count to 0.
    /// </summary>
    public void ResetCoin() { _coins = 0; }

    /// <summary>
    /// Increases gate count.
    /// </summary>
    public void AddGate() { _gates++; }

    /// <summary>
    /// Resets gate count to 0.
    /// </summary>
    public void ResetGate() { _gates = 0; }

    /// <summary>
    /// Decreases the health with the specified amount.
    /// </summary>
    /// <param name="amount">Amount of health to be decreased.</param>
    public void DecreaseHealth(float amount)
    {
        Debug.Log($"Decreasing health by {amount}.");
        _health -= amount;
        if (health < 0f) _health = 0f;
    }

    /// <summary>
    /// Resets the health to its fullest.
    /// </summary>
    public void ResetHealth() { _health = 100f; }

    /// <summary>
    /// Adds the livestock by one.
    /// </summary>
    public void AddStock() { _lives++; }

    /// <summary>
    /// Adds the livestock by the specified amount.
    /// </summary>
    /// <param name="amount">Amount of livestock to be added.</param>
    public void AddStock(int amount) { _lives += amount; }

    /// <summary>
    /// Decreases the livestock by one.
    /// </summary>
    public void DecreaseStock()
    {
        _lives--;
        if (lives < 0) _lives = 0;
    }
    
    /// <summary>
    /// Decreases the livestock by the specified amount.
    /// </summary>
    public void DecreaseStock(int amount)
    {
        _lives -= amount;
        if (lives < 0) _lives = 0;
    }

    /// <summary>
    /// Resets the livestock.
    /// </summary>
    public void ResetStock() { _lives = defaultLives; }

    /// <summary>
    /// Starts the timer.
    /// </summary>
    public void StartTimer() { _timerStarted = true; }

    /// <summary>
    /// Stops the timer.
    /// </summary>
    public void StopTimer() { _timerStarted = false; }

    /// <summary>
    /// Adds the timer with the specified time.
    /// </summary>
    /// <param name="seconds">Seconds to add.</param>
    public void AddTimer(float seconds) { _timer += seconds; }

    /// <summary>
    /// Resets the timer with the time specified in defaultTimer.
    /// Stops the timer if already started.
    /// </summary>
    public void ResetTimer()
    {
        _timerStarted = false;
        _timer = defaultTime;
    }

    public void StartGameplay()
    {
        StartTimer();
        isPlaying = true;
    }

    public void ResumeGameplay()
    {
        StartTimer();
        Time.timeScale = 1f;
    }

    public void PauseGameplay()
    {
        StopTimer();
        Time.timeScale = 0f;
    }

    public IEnumerator FinishLevel()
    {
        StopTimer();
        isPlaying = false;
        // TODO: add score based on time
        // _score += "???"

        // TODO: test this later
        yield return new WaitForSeconds(2f);
        isCompleted = true;
    }

    /// <summary>
    /// Unlocks invulnerability mode for player.
    /// </summary>
    public void invulnUnlock() { _invulnUnlock = true; }

    /// <summary>
    /// Manages the gameplay activation of invulnerability mode.
    /// </summary>
    public void invulnManager(bool on) { 
        if(on == true) _zenMode = true; 
        else if(on == false) _zenMode = false;
    }

    /// <summary>
    /// Sets ball mass.
    /// </summary>
    public void setMass(float mass) { _mass = mass; }

    /// <summary>
    /// Unlocks coin magnet mode for player.
    /// </summary>
    public void magnetUnlock() { _magnetUnlock = true; }

    /// <summary>
    /// Manages the gameplay activation of coin magnet mode.
    /// </summary>
    public void magnetManaget(bool on)
    {
        if (on == true) _magnetOn = true;
        else if (on == false) _magnetOn = false;
    }

    /// <summary>
    /// Sets the coin magnet level.
    /// </summary>
    public void setMagnetLevel(int level) { _coinMagnetLevel = level; }

    /// <summary>
    /// Gets the coin magnet level.
    /// </summary>
    public int getMagnetLevel() { return _coinMagnetLevel; }
}