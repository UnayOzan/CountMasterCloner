using UnityEngine;

public class Multiplier : MonoBehaviour
{
    [SerializeField] private int amount;

    private void OnTriggerEnter(Collider other)
    {
        var player = other.GetComponent<Player>();
        if (player != null)
        {
            player.currentProjectileAmount *= amount;
            player.UpdatePositions();
        }
    }
}
