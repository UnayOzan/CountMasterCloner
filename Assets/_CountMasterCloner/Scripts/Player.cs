using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using DG.Tweening;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private GameObject projectile;
    [SerializeField] private List<GameObject> projectilePool;
    [SerializeField] private int poolAmount;
    [SerializeField] private Transform poolHolder;
    [SerializeField] private List<Transform> centers;

    [SerializeField] private List<int> centerProjectileAmounts;

    [SerializeField] public int currentProjectileAmount;
    private int remainingProjectileAmount;

    private void Start()
    {
        for (var i = 0; i < poolAmount; i++)
        {
            var project = Instantiate(projectile, poolHolder);
            project.SetActive(false);
            projectilePool.Add(project);
        }

        UpdatePositions();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            UpdatePositions();
        }
    }

    public void UpdatePositions()
    {
        remainingProjectileAmount = currentProjectileAmount;

        for (var i = 0; i < centerProjectileAmounts.Count; i++)
        {
            var lenght = centerProjectileAmounts[i];

            if (lenght > remainingProjectileAmount)
                lenght = remainingProjectileAmount - 1;

            var rotationAmount = 360f / lenght;

            for (var j = 0; j < lenght; j++)
            {
                remainingProjectileAmount--;

                if (remainingProjectileAmount <= 0)
                    break;

                var pos = centers[i].transform.position + Vector3.right * (i / 1.5f + 1);
                var project = projectilePool[remainingProjectileAmount];
                project.SetActive(true);
                project.transform.parent = centers[i];
                project.transform.position = pos; //DOLocalMove(pos, 1f);
                project.transform.RotateAround(centers[i].transform.position, Vector3.forward, rotationAmount * j);
            }

            if (remainingProjectileAmount <= 0)
                break;
        }
    }
}