using UnityEngine;

public class ObstaclesGenerator : MonoBehaviour
{
    [SerializeField] private GameObject[] _obstacles;
    [SerializeField] private Transform[] _points;
    private void Start()
    {
        float chance = Random.value;
        if (chance > 0.5)
        {
            Generate();
        }
        
    }

    private void Generate()
    {
        Instantiate(_obstacles[Random.Range(0, _obstacles.Length)], _points[Random.Range(0, _points.Length)]);
    }
}
