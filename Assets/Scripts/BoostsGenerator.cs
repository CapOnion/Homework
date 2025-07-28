using UnityEngine;
using UnityEngine.Rendering;

public class BoostsGenerator : MonoBehaviour
{
    [SerializeField] private GameObject[] _boosts;
    [SerializeField] private Transform[] _points;
    private void Start()
    {
        float chance = Random.value;
        Debug.Log(chance);
        if (chance > 0.5)
        {
            Generate();
        }
        
    }

    private void Generate()
    {
        Instantiate(_boosts[Random.Range(0, _boosts.Length)], _points[Random.Range(0, _points.Length)]);
    }
}
