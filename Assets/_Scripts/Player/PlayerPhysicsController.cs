using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPhysicsController : MonoBehaviour
{
    #region Variables
    
    // Public Variables
    
    // Private Variables
    [SerializeField] private LayerMask layerToHit;
    private float _startYOffset;

    #endregion Variables
    
    private void Awake()
    {
        if (Physics.Raycast(transform.position, Vector3.down, out RaycastHit hitInfo, float.MaxValue, layerToHit))
        {
            _startYOffset = transform.position.y - hitInfo.point.y;
        }
    }

    private void Update()
    {
        if (Physics.Raycast(transform.position, Vector3.down, out RaycastHit hitInfo, float.MaxValue, layerToHit))
        {
            var pos = hitInfo.point;
            pos.y += _startYOffset;
            
            transform.position = pos;
        }
    }
}
