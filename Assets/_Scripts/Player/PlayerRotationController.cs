using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRotationController : MonoBehaviour
{
    #region Variables
    
    // Public Variables
    
    // Private Variables
    [SerializeField] private float lookSpeed = 3.5f;
    [SerializeField] private float lookXLimit = 60f;

    private Transform _camTransform;
    
    private float _camRotationX;
    private float _playerRotationY;

    #endregion Variables
    
    private void Awake()
    {
        InitComponents();

        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void Update()
    {
        CalculateCamRotation(out Quaternion targetCamRot);
        CalculatePlayerRotation(out Quaternion targetPlayerRot);
        
        RotatePlayerAndCamera(ref targetCamRot, ref targetPlayerRot);
    }

    private void InitComponents()
    {
        _camTransform = GetComponentInChildren<Camera>().transform;
    }

    private void CalculateCamRotation(out Quaternion targetCamRot)
    {
        _camRotationX += -Input.GetAxis("Mouse Y") * lookSpeed;
        _camRotationX = Mathf.Clamp(_camRotationX, -lookXLimit, lookXLimit);
        
        targetCamRot = Quaternion.Euler(_camRotationX, 0, 0);
    }

    private void CalculatePlayerRotation(out Quaternion targetPlayerRot)
    {
        _playerRotationY += Input.GetAxis("Mouse X") * lookSpeed;
        targetPlayerRot = Quaternion.Euler(0, _playerRotationY, 0);
    }
    
    private void RotatePlayerAndCamera(ref Quaternion targetCamRot, ref Quaternion targetPlayerRot)
    {
        _camTransform.localRotation = Quaternion.Lerp(_camTransform.localRotation, targetCamRot, 10 * Time.deltaTime);
        transform.rotation = Quaternion.Lerp(transform.rotation, targetPlayerRot, 10 * Time.deltaTime);
    }
}
