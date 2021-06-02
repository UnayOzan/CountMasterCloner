using TMPro;
using UnityEngine;

public class Adder : MonoBehaviour
{
    [SerializeField] private int amount;
    [SerializeField] private GameObject pointEffect;

    private void OnTriggerEnter(Collider other)
    {
        var player = other.GetComponent<Player>();
        if (player != null)
        {
            var pointEff = Instantiate(pointEffect, transform.position, Quaternion.identity);
            var tmpText = pointEff.GetComponentInChildren<TMP_Text>();
            tmpText.text = "+" + amount;
            
            player.currentProjectileAmount += amount;
            player.UpdatePositions();
        }
    }
}