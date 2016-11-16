using UnityEngine;
using System.Collections.Generic;

/// <summary>
/// Controls the player's movement in virtual reality.
/// </summary>
[RequireComponent(typeof(CharacterController))]
public class BobbingWalkingOVRPlayerController : OVRPlayerController
{
    private const float GravYHighLimit = 2.0f;
    private const float GravYLowLimit = -2.0f;
    private const float DiffMax = 3.0f;
    private const float TimeLimitUntilChangingFlag = 2.0f;
    private const float PitchHightLimit = 325f;
    private const float PitchLowLimit = 270f;

    private Transform _playerTransform;
    private Transform _cameraTransform = null;
    private bool _landFlag = false;
    private float _timerUntilChangingFlag = 0;

    protected override void Start()
    {
        base.Start();
    }

    protected override void Awake()
    {
        base.Awake();
        _playerTransform = GameObject.Find("OVRPlayerController").transform;
        _cameraTransform = GameObject.Find("CenterEyeAnchor").transform;
    }

    protected override void Update()
    {
        base.Update();
        if (UnityEngine.VR.VRDevice.isPresent == false)
        {
            return;
        }

        Vector3 accel = OVRManager.display.acceleration;
        Vector3 grav = _playerTransform.localToWorldMatrix.MultiplyPoint(accel);

        if (_landFlag)
        {
            if (grav.y > GravYHighLimit)
            {
                _landFlag = false;
                float diff = grav.y - GravYHighLimit;
                if (diff > DiffMax)
                {
                    diff = DiffMax;
                }
                float pitch = _cameraTransform.localEulerAngles.x;
                if ((pitch > PitchLowLimit) && (pitch < PitchHightLimit)) 
                {
                    MoveBackward(diff * 0.13f);
                }
                else
                {
                    MoveForward(diff * 0.13f);
                }

            }
            _timerUntilChangingFlag += Time.deltaTime;
            if (_timerUntilChangingFlag > TimeLimitUntilChangingFlag)
            {
                _timerUntilChangingFlag = 0.0f;
                _landFlag = false;
            }
        }
        if (grav.y < GravYLowLimit)
        {
            _landFlag = true;
        }
    }

    /// <summary>
    /// MoveForward! Must be enabled manually.
    /// </summary>
    public bool MoveForward(float rate)
    {
        if (!Controller.isGrounded)
            return false;

        MoveThrottle += new Vector3(0, 0.5f, 0) * rate;
        Transform dirXform = (HmdRotatesY) ? CameraRig.centerEyeAnchor : transform;
        MoveThrottle += dirXform.TransformDirection(Vector3.forward) * rate;

        return true;
    }

    /// <summary>
    /// MoveBackward! Must be enabled manually.
    /// </summary>
    public bool MoveBackward(float rate)
    {
        if (!Controller.isGrounded)
            return false;

        MoveThrottle += new Vector3(0, 0.5f, 0) * rate;
        Transform dirXform = (HmdRotatesY) ? CameraRig.centerEyeAnchor : transform;
        MoveThrottle += dirXform.TransformDirection(Vector3.back) * rate;

        return true;
    }
}

