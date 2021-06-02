using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private GameObject projectile;
    [SerializeField] private List<Transform> centers;

    [SerializeField] private List<int> centerProjectileAmounts;

    [SerializeField] private int currentProjectileAmount;
    private int remainingProjectileAmount;

    private void Start()
    {
        UpdatePositions();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            UpdatePositions();
        }
    }

    private void UpdatePositions()
    {
        //cleanup the list
        foreach (var item in centers.SelectMany(center => center.Cast<Transform>()))
        {
            Destroy(item.gameObject);
        }

        remainingProjectileAmount = currentProjectileAmount;

        for (var i = 0; i < centerProjectileAmounts.Count; i++)
        {
            var lenght = centerProjectileAmounts[i];
            var rotationAmount = 360f / lenght;
            
            for (var j = 0; j < lenght; j++)
            {
                remainingProjectileAmount--;
                Debug.Log("Spend:" + remainingProjectileAmount);
                
                if(remainingProjectileAmount <= 0 )
                    break;
                
                var pos = centers[i].transform.position + Vector3.right * (i + 1);
                var project = Instantiate(projectile, pos, Quaternion.identity, centers[i]);
                project.name += " - " + j;
                project.transform.RotateAround(centers[i].transform.position, Vector3.forward, rotationAmount * j);
            }
            
            if(remainingProjectileAmount <= 0 )
                break;
        }
    }
}