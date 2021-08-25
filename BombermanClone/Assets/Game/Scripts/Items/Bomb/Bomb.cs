using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    public event Action OnExplode;

    [SerializeField] ExplosionSettings explosionPrefab;

    CheckGridPosition bombPos;
    PlayerSkills playerSkill;

    List<Vector3> explosionRange = new List<Vector3>();

    float timeToExplode = 2.0f;

    void Start()
    {
        bombPos = FindObjectOfType(typeof(CheckGridPosition)) as CheckGridPosition;
        playerSkill = FindObjectOfType(typeof(PlayerSkills)) as PlayerSkills;

        GeneratePositionList();
        StartCoroutine(BombSettings());
    }

    private void GeneratePositionList()
    {
        explosionRange.Add(bombPos.PositionInGrid(transform));

        for (int i = 1; i <= playerSkill.FireRange; i++)
        {
            explosionRange.Add(new Vector3(explosionRange[0].x, explosionRange[0].y + i, explosionRange[0].z));
            explosionRange.Add(new Vector3(explosionRange[0].x, explosionRange[0].y - i, explosionRange[0].z));
            explosionRange.Add(new Vector3(explosionRange[0].x + i, explosionRange[0].y, explosionRange[0].z));
            explosionRange.Add(new Vector3(explosionRange[0].x - i, explosionRange[0].y, explosionRange[0].z));
        }
    }

    void InstantiateExplosion()
    {
        for (int i = 0; i < explosionRange.Count; i++)
        {
            Instantiate(explosionPrefab, explosionRange[i], transform.rotation);
        }
    }

    IEnumerator BombSettings()
    {
        yield return new WaitForSeconds(timeToExplode);
        if (OnExplode != null)
        {
            OnExplode.Invoke();
        }
        InstantiateExplosion();
        Destroy(gameObject);
    }
}
