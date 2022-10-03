using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PenguinPlatformsController : MonoBehaviour
{
    [SerializeField] private GameObject _initialPlatformPrefab;
    [SerializeField] private Transform _initialPlatformSpawn;

    [SerializeField] private GameObject _platformPrefab;
    [SerializeField] private List<GameObject> _platformsCreated;
    [SerializeField] private GameObject _coinPrefab;
    [SerializeField] private float _coinOffsetY;
    [SerializeField] private float _coinSpeed;

    [SerializeField] private float _platformsMovementSpeed;

    [SerializeField] private float _platformSpawnTimer;
    private float _timerSpawner = 0f;

    [SerializeField] private Transform _limitPosition;
    [SerializeField] private Transform _spawnPosition;

    [SerializeField] private float _platformPosYMin;
    [SerializeField] private float _platformPosYMax;

    [SerializeField] private float _platformMinScaleX;
    [SerializeField] private float _platformMaxScaleX;

    [SerializeField] private float _platScaleY;

    private void Start()
    {
        SpawnPlatform();
    }

    void Update()
    {
        _timerSpawner += Time.deltaTime;

        if (_timerSpawner >= _platformSpawnTimer)
        {
            _timerSpawner = 0f;
            SpawnPlatform();
        }


        for (int i = 0; i < _platformsCreated.Count; i++)
        {
            if (_platformsCreated[i] != null)
            {
                Vector3 movement = Vector3.left * _platformsMovementSpeed * Time.deltaTime;
                _platformsCreated[i].transform.position += movement;

                if (_platformsCreated[i].transform.localPosition.x + (_platformsCreated[i].transform.localScale.x / 2f) <= _limitPosition.position.x)
                {
                    Destroy(_platformsCreated[i]);
                    _platformsCreated.RemoveAt(i);
                    i--;
                }
            }
        }
    }

    private void RandomizePlatform(Transform platform)
    {
        platform.localPosition = new Vector3(platform.position.x, Random.Range(_platformPosYMin, _platformPosYMax), 0);
        platform.localScale = new Vector3(Random.Range(_platformMinScaleX, _platformMaxScaleX), _platScaleY, 1);
    }

    private void SpawnPlatform()
    {
        GameObject platform = Instantiate(_platformPrefab, _spawnPosition.position, Quaternion.identity, this.transform);
        _platformsCreated.Add(platform);
        RandomizePlatform(platform.transform);
        GameObject coin = Instantiate(_coinPrefab, platform.transform.position + Vector3.up * _coinOffsetY, Quaternion.identity, this.transform);
        CartGamePickUp aux = coin.GetComponent<CartGamePickUp>();
        aux.speed = _coinSpeed;
        coin.SetActive(true);
    }

    public void ResetPlatforms()
    {
        for (int i = 0; i < _platformsCreated.Count; i++)
        {
            if (_platformsCreated[i] != null)
            {
                Destroy(_platformsCreated[i]);
            }
        }
        _platformsCreated.Clear();

        GameObject initialPlatform = Instantiate(_initialPlatformPrefab, _initialPlatformSpawn.position, Quaternion.identity, this.transform);
        _platformsCreated.Add(initialPlatform);

        _timerSpawner = 0f;
    }
}
