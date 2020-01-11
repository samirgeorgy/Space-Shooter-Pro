﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    #region Private Variables

    [SerializeField] private float _spawnWait = 5f;
    [SerializeField] private GameObject _enemyPrefab;
    [SerializeField] private GameObject _enemyContainer;

    private bool _stopSpawning = false;

    #endregion

    #region Unity Functions

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnRoutine());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    #endregion

    #region Supporting Functions

    /// <summary>
    /// Stops spawning upon player death;
    /// </summary>
    public void OnPlayerDeath()
    {
        _stopSpawning = true;
    }

    /// <summary>
    /// The enemy spawning routine
    /// </summary>
    /// <returns></returns>
    IEnumerator SpawnRoutine()
    {
        while (_stopSpawning == false)
        {
            Vector3 posToSpawn = new Vector3(Random.Range(-8f, 8f), 7, 0);
            GameObject newEnemy = Instantiate(_enemyPrefab, posToSpawn, Quaternion.identity);
            newEnemy.transform.parent = _enemyContainer.transform;

            yield return new WaitForSeconds(_spawnWait);
        }
    }

    #endregion
}
