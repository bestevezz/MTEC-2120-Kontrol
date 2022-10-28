using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class RingBehaviour2 : MonoBehaviour
{
    private Vector2 m_Rotation;
    private Vector2 m_Movement;
    public float rotateSpeed;
    public float moveSpeed;
    public GameObject _Ring2;
    public void Update()
    {
        var gamepad = Gamepad.current;
        if (gamepad == null)
            return;

        var leftStick = gamepad.leftStick.ReadValue();
        var rightStick = gamepad.rightStick.ReadValue();

        Rotate2(leftStick);
        Move(rightStick);

        if (gamepad.buttonSouth.wasPressedThisFrame)
        {
            changeColor2Red();
        }

        if (gamepad.buttonEast.wasPressedThisFrame)
        {
            changeColor2Green();
        }

        if (gamepad.buttonWest.wasPressedThisFrame)
        {
            changeColor2Blue();
        }

        if (gamepad.buttonNorth.wasPressedThisFrame)
        {
            changeColorBack();

        }
        if (gamepad.rightShoulder.wasPressedThisFrame)
        {
            randomColor();
        }

        if (gamepad.rightTrigger.wasPressedThisFrame)
        {
            randomColor();
        }

        if (gamepad.rightTrigger.wasReleasedThisFrame)
        {
            randomColor();
        }

        if (gamepad.leftShoulder.wasPressedThisFrame)
        {
            randomColor();
        }

        if (gamepad.leftTrigger.wasPressedThisFrame)
        {
            randomColor();
        }

        if (gamepad.leftTrigger.wasReleasedThisFrame)
        {
            randomColor();
        }
    }

    private void Rotate2(Vector2 rotate)
    {
        if (rotate.sqrMagnitude < 0.01)
            return;
        var scaledRotateSpeed = rotateSpeed * Time.deltaTime;
        m_Rotation.y += rotate.y * scaledRotateSpeed;
        m_Rotation.x += rotate.x * scaledRotateSpeed;
        transform.localEulerAngles = m_Rotation;
    }

    public void changeColor2Red()
    {
        var colorRenderer2 = _Ring2.GetComponent<Renderer>();
        Color newPink = new Color(.9339623f, .6379139f, .8992653f, 1f);
        colorRenderer2.material.SetColor("_Color", newPink);
    }

    public void changeColor2Green()
    {
        var colorRenderer2 = _Ring2.GetComponent<Renderer>();
        Color newPink = new Color(0.6035095f, 0.9811321f, 0.003702312f, 1f);
        colorRenderer2.material.SetColor("_Color", newPink);
    }

    public void changeColor2Blue()
    {
        var colorRenderer2 = _Ring2.GetComponent<Renderer>();
        Color newBlue = new Color(0f, 0.505842f, 0.9622642f, 1f);
        colorRenderer2.material.SetColor("_Color", newBlue);
    }

    public void changeColorBack()
    {
        var colorRenderer2 = _Ring2.GetComponent<Renderer>();
        colorRenderer2.material.SetColor("_Color", Color.white);
    }

    public void randomColor()
    {
        _Ring2.GetComponent<Renderer>().material.color = Random.ColorHSV(0f, 1f, 0f, 1f, 0.5f, 1f);
    }

    private void Move(Vector2 direction)
    {
        if (direction.sqrMagnitude < 0.01)
            return;
        var scaledMoveSpeed = moveSpeed * Time.deltaTime;
        // For simplicity's sake, we just keep movement in a single plane here. Rotate
        // direction according to world Y rotation of player.
        var move = Quaternion.Euler(0, 0, 0) * new Vector3(direction.x, direction.y, 0);
        transform.position += move * scaledMoveSpeed;
    }

}
