using UnityEngine;

public class Bag : MonoBehaviour
{
    [HideInInspector]
    public int _currentBerryInBag = 0;
    
    private IntEvent OnBerryCollected;
    private readonly int _maxBerryInBag = 30;
    
    public void Collecting()
    {
        if (_currentBerryInBag < _maxBerryInBag)
        {
            _currentBerryInBag++;
        }
    }

    public bool CanUnlock => _currentBerryInBag > 0;

    public void BuyingPlatform()
    {
        _currentBerryInBag--;
        OnBerryCollected.Invoke(_currentBerryInBag);
    }
}
