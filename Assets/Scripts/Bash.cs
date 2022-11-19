using UnityEngine;

public class Bash : MonoBehaviour
{
    [SerializeField] private Transform _berryLocation;
    [SerializeField] private GameObject _berryPrefab;
    [SerializeField] private float _timeToNextSpawn = 5f;

    private bool _isSpawned;

    private void Update()
    {
        StartGrowing();
    }

    private void StartGrowing()
    {
        if (!_isSpawned)
        {
            Growing();
        }
    }

    private void Growing()
    {
        Debug.Log("Growing");

        var position = _berryLocation.position;
        var berry = Instantiate(_berryPrefab, position, Quaternion.identity);

        berry.transform.position = position;

        _isSpawned = true;
    }

    public void PickUp()
    {
        _isSpawned = false;
    }
}