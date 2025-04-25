using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Zenject;
using static UnityEngine.GraphicsBuffer;

public class PlayerCamera : MonoBehaviour
{
    [Inject] PlayerMovement _PlayerMovement;
    [SerializeField] private Vector3 _offset = new(0, 15, 0);
    [SerializeField] private float _deadZoneWidth = 1f;
    [SerializeField] private float _deadZoneHeight = 1f;
    [SerializeField] private float _smoothSpeed = 0.125f;

    private Vector3 _targetPosition;
    private Vector3 _desiredPosition;

    void Start()
    {
        
    }

    void LateUpdate()
    {
        if (_PlayerMovement == null) return;

        _desiredPosition = _PlayerMovement.transform.position + _offset;

        float deltaX = Mathf.Abs(_desiredPosition.x - transform.position.x);
        float deltaY = Mathf.Abs(_desiredPosition.y - transform.position.y);

        if (deltaX > _deadZoneWidth || deltaY > _deadZoneHeight)
        {
            _targetPosition = _desiredPosition;
        }

        transform.position = Vector3.Lerp(transform.position, _targetPosition, _smoothSpeed * Time.deltaTime);
    }
}
