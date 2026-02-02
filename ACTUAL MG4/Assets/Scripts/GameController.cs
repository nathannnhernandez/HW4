
using TMPro;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public static GameController Instance{ get; private set; }
    public int Score { get; private set; }
    public bool GameOver { get; private set; }

    public delegate void ScoreChanged(int newScore);
    public event ScoreChanged OnScoreChanged;

    public delegate void AudioTrigger(AudioSource audioSource);
    public event AudioTrigger OnAudioTrigger;
    [SerializeField] private GameObject _pipePrefab;
    [SerializeField] private float _spawnInterval = 1f;
    [SerializeField] private float _heightRange = 0.45f;
    [SerializeField] private TextMeshProUGUI _scoreText;
    private float _timer;
    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }
    // Start is called before the first frame update
    void Start()
    {
        SpawnPipe();
    }
    
    // Update is called once per frame
    void Update()
    {        
        _timer += Time.deltaTime;
        if (_timer >= _spawnInterval && GameOver != true)
        {
            SpawnPipe();
            _timer = 0f;
        }
    }
    public void IncScore()
    {
        Score += 1;
        Debug.Log("Score: " + Score);
        OnScoreChanged?.Invoke(Score);
    }
    private void UpdateScoreText(int newScore)
    {
        if (_scoreText != null)
        {
            _scoreText.text = "Score: " + newScore.ToString();
        }
    }
    void OnEnable()
    {
        OnScoreChanged += UpdateScoreText;
        OnAudioTrigger += PointSound;
        OnAudioTrigger += DeathExplosionSound;
    }
    void OnDisable()
    {
        OnScoreChanged -= UpdateScoreText;
        OnAudioTrigger -= PointSound;
        OnAudioTrigger -= DeathExplosionSound;
    }

    public void GameOverTrigger(GameObject player)
    {
        GameOver = true;
        if (GameOver)
        {
            Destroy(player);
            return;
        }
    }

    private void SpawnPipe()
    {
        Vector3 spawnPos = new Vector3(0f, Random.Range(-_heightRange, _heightRange));
        GameObject pipe = Instantiate(_pipePrefab, spawnPos, Quaternion.identity);

        Destroy(pipe, 7f);
    }
    public void TriggerPointSound(AudioSource audioSource)
    {
        OnAudioTrigger?.Invoke(audioSource);
    }
    private void PointSound(AudioSource audioSource)
    {
        if (audioSource != null)
        {
            audioSource.Play();
        }
    }
    public void TriggerDeathExplosionSound(AudioSource audioSource)
    {
        OnAudioTrigger?.Invoke(audioSource);
    }
    private void DeathExplosionSound(AudioSource audioSource)
    {
        if (audioSource != null)
        {
            audioSource.Play();
        }
    }
}


