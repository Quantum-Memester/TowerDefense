using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControls : MonoBehaviour
{
  [Header("Movement Settings")]
  [SerializeField]
  Transform CamTransform;
  [SerializeField]
  float MoveSpeed;
  [SerializeField]
  float VerticalSpeed;

  [Header("Mouse Settings")]
  [SerializeField]
  float MouseSensitivity;

  // Start is called before the first frame update
  void Start()
  {
    Cursor.lockState = CursorLockMode.Locked;
  }

  // Update is called once per frame
  void Update()
  {
    Movement();
    ViewRotation();
  }

  void Movement()
  {
    var leftRight = (Input.GetAxis("LeftRight") * MoveSpeed * Time.deltaTime * CamTransform.right);
    var backForth = (Input.GetAxis("BackForth") * MoveSpeed * Time.deltaTime * CamTransform.forward);
    var upDown = (CamTransform.up * Input.GetAxis("UpDown") * VerticalSpeed * Time.deltaTime);
    var totalMovement = CamTransform.position + leftRight + backForth + upDown;
    CamTransform.position = totalMovement;
  }

  void ViewRotation()
  {
    var yaw = (Input.GetAxis("Mouse X") * MouseSensitivity * Time.deltaTime);
    var pitch = (-1 * Input.GetAxis("Mouse Y") * MouseSensitivity * Time.deltaTime);
    var totalRotation =  CamTransform.rotation.eulerAngles + new Vector3(pitch, yaw, 0);
    CamTransform.SetPositionAndRotation(CamTransform.position, Quaternion.Euler(totalRotation));
  }
}
