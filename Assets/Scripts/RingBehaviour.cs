using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class RingBehaviour : MonoBehaviour
{
    private Vector2 m_Rotation;
    public float rotateSpeed;
    public float moveSpeed;
    public GameObject Planet;
    public GameObject _Ring;
    public GameObject _Ring3;
    public Material _Planet;
    public Material _Red;
    public Material _Green;
    public Material _Blue;
    public ParticleSystem _Particle;
    public ParticleSystem _smokeParticle;
    public ParticleSystem _smokeParticle2;

    public void Update()
    {
        //Used to make gamepad something to reference
        var gamepad = Gamepad.current;
        if (gamepad == null)
            return;

        //Turns input from gamepad into read values
        var leftStick = gamepad.leftStick.ReadValue();
        var rightStick = gamepad.rightStick.ReadValue();    

        //Functions that reference each individual input
        Rotate(leftStick);
        Move(rightStick);

        //How to call each button individually
        if (gamepad.buttonSouth.wasPressedThisFrame)
        {
            changeColorRed();
        }

        if (gamepad.buttonEast.wasPressedThisFrame)
        {
            changeColorGreen();
        }

        if (gamepad.buttonWest.wasPressedThisFrame)
        {
            changeColorBlue();
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

    private void Rotate(Vector2 rotate)
    {
        //Code taken from the sample simple input using state
        //Adjusted from the look code
        //Sets the vector2 m_rotation and assigns the inverse for x and y
        if (rotate.sqrMagnitude < 0.01)
            return;
        var scaledRotateSpeed = rotateSpeed * Time.deltaTime;
        m_Rotation.y += rotate.x * scaledRotateSpeed;
        m_Rotation.x += rotate.y * scaledRotateSpeed; 
        transform.localEulerAngles = m_Rotation;
    }

    public void changeColorRed()
    {
        //Gets each component and assigns a new color to be called based on input
        var colorRenderer = _Ring.GetComponent<Renderer>();
        var colorRenderer3 = _Ring3.GetComponent<Renderer>();
        colorRenderer.material.SetColor("_Color",Color.magenta);
        colorRenderer3.material.SetColor("_Color", Color.red);
        Planet.GetComponent<Renderer>().material = _Red;
        _Particle.GetComponent<ParticleSystem>().startColor = new Color(1, 0, 1, 1f);
        _smokeParticle.GetComponent<ParticleSystem>().startColor = new Color(1, 0, 1, 1f);
        _smokeParticle2.GetComponent<ParticleSystem>().startColor = new Color(1, 0, 1, 1f);
    }

    public void changeColorGreen()
    {
        var colorRenderer = _Ring.GetComponent<Renderer>();
        var colorRenderer3 = _Ring3.GetComponent<Renderer>();
        Color newYellow = new Color(0.8773585f, .8191074f, 0.03641862f, 1f);
        colorRenderer.material.SetColor("_Color", newYellow);
        Color newGreen = new Color(0.01452472f, 0.6415094f, 0.04633584f, 1f);
        colorRenderer3.material.SetColor("_Color", newGreen);
        Planet.GetComponent<Renderer>().material = _Green;
        _Particle.GetComponent<ParticleSystem>().startColor = new Color(0, 1, 0, 1f);
        _smokeParticle.GetComponent<ParticleSystem>().startColor = new Color(0.8773585f, .8191074f, 0.03641862f, 1f);
        _smokeParticle2.GetComponent<ParticleSystem>().startColor = new Color(0.8773585f, .8191074f, 0.03641862f, 1f);
    }

    public void changeColorBlue()
    {
        var colorRenderer = _Ring.GetComponent<Renderer>();
        var colorRenderer3 = _Ring3.GetComponent<Renderer>();
        Color newCyan = new Color(0f, 1f, 0.7694335f, 1f);
        colorRenderer.material.SetColor("_Color", newCyan);
        Color newPurple = new Color(0.129774f, 0.104806f, 0.6037736f, 1f);
        colorRenderer3.material.SetColor("_Color", newPurple);
        Planet.GetComponent<Renderer>().material = _Blue;
        _Particle.GetComponent<ParticleSystem>().startColor = new Color(0, 0, 1, 1f);
        _smokeParticle.GetComponent<ParticleSystem>().startColor = new Color(0f, 1f, 0.7694335f, 1f);
        _smokeParticle2.GetComponent<ParticleSystem>().startColor = new Color(0f, 1f, 0.7694335f, 1f);
    }

    public void changeColorBack()
    {
        var colorRenderer = _Ring.GetComponent<Renderer>();
        var colorRenderer3 = _Ring3.GetComponent<Renderer>();
        colorRenderer.material.SetColor("_Color", Color.white);
        colorRenderer3.material.SetColor("_Color", Color.white);
        Planet.GetComponent<Renderer>().material = _Planet;
        _Particle.GetComponent<ParticleSystem>().startColor = new Color(1, 1, 1, 1f);
        _smokeParticle.GetComponent<ParticleSystem>().startColor = new Color(1, 1, 1, .5f);
        _smokeParticle2.GetComponent<ParticleSystem>().startColor = new Color(1, 1, 1, .5f);
    }

    public void randomColor()
    {
        _Ring.GetComponent<Renderer>().material.color = Random.ColorHSV(0f, 1f, 0f, 1f, 0.5f, 1f);
        _Ring3.GetComponent<Renderer>().material.color = Random.ColorHSV(0f, 1f, 0f, 1f, 0.5f, 1f);
        Planet.GetComponent<Renderer>().material.color = Random.ColorHSV(0f, 1f, 0f, 1f, 0.5f, 1f);
        _Particle.GetComponent<ParticleSystem>().startColor = Random.ColorHSV(0f, 1f, 0f, 1f, 0.5f, 1f);
        _smokeParticle.GetComponent<ParticleSystem>().startColor = Random.ColorHSV(0f, 1f, 0f, 1f, 0.5f, 1f);
        _smokeParticle2.GetComponent<ParticleSystem>().startColor = Random.ColorHSV(0f, 1f, 0f, 1f, 0.5f, 1f);
    }

    private void Move(Vector2 direction)
    {
        //Taken from Simple controller using state
        //Adjusted to have quaternions set to 0 so it wouldnt move in z direction
        //New vector 3 z is kept at 0 to keep it from moving in that direction
        if (direction.sqrMagnitude < 0.01)
            return;
        var scaledMoveSpeed = moveSpeed * Time.deltaTime;
        // For simplicity's sake, we just keep movement in a single plane here. Rotate
        // direction according to world Y rotation of player.
        var move = Quaternion.Euler(0, 0, 0) * new Vector3(direction.x, direction.y, 0);
        transform.position += move * scaledMoveSpeed;
    }

}
