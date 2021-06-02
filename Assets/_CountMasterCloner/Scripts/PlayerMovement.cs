using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private DynamicJoystick dynamicJoystick;

    private void Update()
    {
        var pos = transform.position;
        pos.x = dynamicJoystick.Horizontal * 7;
        pos.z = transform.position.z + Time.deltaTime * 30f;
        pos.y = dynamicJoystick.Vertical * 7;
        transform.position = pos;
    }
}