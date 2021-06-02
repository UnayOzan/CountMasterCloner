using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private DynamicJoystick dynamicJoystick;

    private void Update()
    {
        var pos = transform.position;
        pos.x = dynamicJoystick.Horizontal;
        pos.y = dynamicJoystick.Vertical;
        transform.position = pos;
    }
}