using UnityEngine;
using UnityEngine.InputSystem;

public class CameraRotater : MonoBehaviour
{
    [SerializeField] public float _moveSpeed;

    [SerializeField] public float _rotateSpeed;

    [SerializeField] private float _additionMoveSpeed, _additionRotateSpeed;

    [SerializeField] private float _minMoveSpeed, _maxMoveSpeed, _minRotateSpeed, _maxRotateSpeed;

    private Camera _camera;
    private CarControls _controls;
    private bool _isRotating;

    private void Start()
    {
        _camera = Camera.main;
    }

    private void Update()
    {
        Rotation();
        _moveSpeed = Mathf.Clamp(_moveSpeed, _minMoveSpeed, _maxMoveSpeed);
        _rotateSpeed = Mathf.Clamp(_rotateSpeed, _minRotateSpeed, _maxRotateSpeed);
        if (Input.GetKey(KeyCode.Equals)) _moveSpeed += _additionMoveSpeed * Time.deltaTime;
        if (Input.GetKey(KeyCode.Minus)) _moveSpeed -= _additionMoveSpeed * Time.deltaTime;
        if (Input.GetKey(KeyCode.Q)) _rotateSpeed += _additionRotateSpeed * Time.deltaTime;
        if (Input.GetKey(KeyCode.R)) _rotateSpeed -= _additionRotateSpeed * Time.deltaTime;
    }

    private void OnEnable()
    {
        _controls = new CarControls();
        _controls.Enable();
        _controls.Camera.ActivateRotation.performed += ActivateRotation;
        _controls.Camera.ActivateRotation.canceled += ActivateRotation;
    }

    private void ActivateRotation(InputAction.CallbackContext obj)
    {
        var lockCursor = obj.performed;
        _isRotating = lockCursor;
        if (lockCursor)
            Cursor.lockState = CursorLockMode.Locked;
        else
            Cursor.lockState = CursorLockMode.None;
    }

    private void Rotation()
    {
        if (_isRotating == false) return;
        var dir = _controls.Camera.Rotation.ReadValue<Vector2>();

        var angle = Vector3.zero;
        angle.x = 0;
        angle.y += dir.x * _rotateSpeed * Time.deltaTime;
        angle.z = 0;

        transform.rotation *= Quaternion.Euler(angle);
        transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y, 0);
    }
}