using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private DynamicJoystick dynamicJoystick;

    private void Update()
    {
        var pos = transform.position;
        pos.x = dynamicJoystick.Horizontal;
        pos.z = transform.position.z + Time.deltaTime * 10f;
        pos.y = dynamicJoystick.Vertical;
        transform.position = pos;
    }
}