using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    #region Variables
    
    // Public Variables
    
    // Private Variables
    [SerializeField] private float walkSpeed, runSpeed;
    
    private PlayerMovementBaseState _currentState;

    private float _verticalInput, _horizontalInput;
    private float _movementSpeed;
    
    #endregion Variables
    
    private void Awake()
    {
        ChangeState(new PlayerMovementIdleState(this));
    }

    private void Update()
    {
        _verticalInput = Input.GetAxisRaw("Vertical");
        _horizontalInput = Input.GetAxisRaw("Horizontal");

        _currentState.Update();
    }

    public void Move()
    {
        var forwardDir = transform.forward * _verticalInput;
        var horizontalDir = transform.right * _horizontalInput;
        var dir = (horizontalDir + forwardDir).normalized;
        
        transform.position += dir * (_movementSpeed * Time.deltaTime);
    }
    
    public bool IsMoving()
    {
        return _verticalInput != 0 || _horizontalInput != 0;
    }

    public void SetWalkSpeed() => _movementSpeed = walkSpeed;
    public void SetRunSpeed() => _movementSpeed = runSpeed;

    public void ChangeState(PlayerMovementBaseState newState) => _currentState = newState;
}
