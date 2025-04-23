using System;
using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

public class Enemy : CharacterBase
{
    [Serializable]
    public struct IntervalFire
    {
        public float min;
        public float max;
    }

    [SerializeField] private IntervalFire _intervalFire;
    private Player _player;

    private void Start()
    {
        GameObject.FindGameObjectWithTag("Player").TryGetComponent(out _player);
        StartCoroutine(WaitFire());
    }

    private void Update()
    {
        if (_player == null) return;

        transform.LookAt(_player.transform.position);
    }

    private IEnumerator WaitFire()
    {
        while (_player != null)
        {
            var timeToShoot = Random.Range(_intervalFire.min, _intervalFire.max);
            yield return new WaitForSeconds(timeToShoot);
            Shoot();
        }
    }
}