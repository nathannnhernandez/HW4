
using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField] private float _gameSpeed = 1f;
    [SerializeField] private GameObject _pipePrefab;
    [SerializeField] private float _spawnInterval = 1f;
    [SerializeField] private float _heightRange = 0.45f;
    private float _timer;
    // Start is called before the first frame update
    void Start()
    {
        SpawnPipe();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += Vector3.left * _gameSpeed * Time.deltaTime;
        
        _timer += Time.deltaTime;
        if (_timer >= _spawnInterval)
        {
            SpawnPipe();
            _timer = 0f;
        }
    }
    private void SpawnPipe()
    {
        Vector3 spawnPos = new Vector3(5f, Random.Range(-_heightRange, _heightRange));
        Instantiate(_pipePrefab, spawnPos, Quaternion.identity);

        Destroy(_pipePrefab, 10f);
    }
}
