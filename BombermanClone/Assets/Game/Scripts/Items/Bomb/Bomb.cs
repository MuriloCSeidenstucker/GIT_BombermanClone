using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    public event Action OnExplode;

    [SerializeField] ExplosionSettings explosion;

    CheckGridPosition bombPos;
    PlayerSkills playerSkill;

    List<Vector3> explosionRange = new List<Vector3>();

    float timeToExplode = 2.0f;

    void Start()
    {
        bombPos = FindObjectOfType(typeof(CheckGridPosition)) as CheckGridPosition;
        playerSkill = FindObjectOfType(typeof(PlayerSkills)) as PlayerSkills;

        GenerateList();
        StartCoroutine(BombSettings());
    }

    private void GenerateList()
    {
        explosionRange.Add(bombPos.GridPosition(transform));

        for (int i = 0; i < playerSkill.FireRange*4; i++)
        {
            explosionRange.Add(new Vector3(explosionRange[0].x, explosionRange[0].y + playerSkill.FireRange, explosionRange[0].z));
        }

        if (playerSkill.FireRange == 2)
        {
            explosionRange.Add(new Vector3(explosionRange[0].x, explosionRange[0].y + 1, explosionRange[0].z));
            explosionRange.Add(new Vector3(explosionRange[0].x, explosionRange[0].y - 1, explosionRange[0].z));
            explosionRange.Add(new Vector3(explosionRange[0].x, explosionRange[0].y + 2, explosionRange[0].z));
            explosionRange.Add(new Vector3(explosionRange[0].x, explosionRange[0].y - 2, explosionRange[0].z));
            explosionRange.Add(new Vector3(explosionRange[0].x + 1, explosionRange[0].y, explosionRange[0].z));
            explosionRange.Add(new Vector3(explosionRange[0].x - 1, explosionRange[0].y, explosionRange[0].z));
            explosionRange.Add(new Vector3(explosionRange[0].x + 2, explosionRange[0].y, explosionRange[0].z));
            explosionRange.Add(new Vector3(explosionRange[0].x - 2, explosionRange[0].y, explosionRange[0].z));
        }
        explosionRange.Add(new Vector3(explosionRange[0].x, explosionRange[0].y + 1, explosionRange[0].z));
        explosionRange.Add(new Vector3(explosionRange[0].x, explosionRange[0].y - 1, explosionRange[0].z));
        explosionRange.Add(new Vector3(explosionRange[0].x + 1, explosionRange[0].y, explosionRange[0].z));
        explosionRange.Add(new Vector3(explosionRange[0].x - 1, explosionRange[0].y, explosionRange[0].z));
    }

    void InstantiateExplosion()
    {
        for (int i = 0; i < explosionRange.Count; i++)
        {
            Instantiate(explosion, explosionRange[i], transform.rotation);
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
