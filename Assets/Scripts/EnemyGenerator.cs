using UnityEngine;

public class EnemyGenerator : MonoBehaviour
{
    
    [SerializeField] private GameObject[] _enemies;
    [SerializeField] private Transform[] _points;

    public void Start()
    {
        Generate();
    }

    public void Generate()
    {
        Instantiate(_enemies[Random.Range(0, _enemies.Length)], _points[Random.Range(0, _points.Length)]);
    }
}

