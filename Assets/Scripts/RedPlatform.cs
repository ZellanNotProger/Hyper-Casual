using System.Collections;
using UnityEngine;

public class RedPlatform : MonoBehaviour
{
    [SerializeField] private Material[] _materials;
    [SerializeField] private float _timeToBuying;
    [SerializeField] private int _cost;

    private Bag _bag;
    private bool _isBought;

    private IEnumerator Buying()
    {
        yield return new WaitForSeconds(_timeToBuying);

        while (_cost > 0)
        {

            _bag.BuyingPlatform();
            _cost--;

            if (_cost == 0)
            {
                _isBought = true;
                gameObject.GetComponent<MeshRenderer>().material = _materials[1];
            }
        }
    }

    private void OnCollisionStay(Collision collision)
    {
        _bag = collision.gameObject.GetComponent<Bag>();

        if (!_isBought && _bag.CanUnlock)
        {
            StartCoroutine(Buying());
        }

        else
        {
            StopCoroutine(Buying());
        }
    }
}
