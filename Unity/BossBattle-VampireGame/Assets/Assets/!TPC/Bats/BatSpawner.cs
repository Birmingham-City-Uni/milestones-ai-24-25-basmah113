using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatSpawner : MonoBehaviour
{
    public GameObject[] _Bats;
    public Transform[] _spawnPoints;
    public float _Spawntime;
    public bool isSpawnStart;
    public EnemyController _ec;

    public void FncSpawn()
    {
        for (int i = 0; i < _spawnPoints.Length; i++)
        {
            Instantiate(_Bats[i], _spawnPoints[i].position, _spawnPoints[i].rotation);
        }
    }

    private void Update()
    {
        if (isSpawnStart)
        {
            _Spawntime += Time.deltaTime;
            if (_Spawntime > 50)
            {
                _Spawntime = 0;
                FncSpawn();
            }
        }
    }
}
