using System;
using UnityEngine;
using UnityEngine.Events;

[Serializable]
public class IntEvent : UnityEvent<int>
{
}

public class BerryCollect : MonoBehaviour
{
    [SerializeField] private IntEvent OnBerryCollected;

    private Bash _spawnBerry;
    private Bag _bag;
    private readonly string _berry = "Berry";

    private void Start()
    {
        _bag = GetComponent<Bag>();
        _spawnBerry = FindObjectOfType<Bash>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == _berry)
        {
            Destroy(collision.gameObject);

            _bag.Collecting();
            _spawnBerry.PickUp();

            OnBerryCollected.Invoke(_bag._currentBerryInBag);
        }
    }
}
