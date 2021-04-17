using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCam : MonoBehaviour
{
   
   [SerializeField]
	Transform follow = default;
    [SerializeField] private float lookSensitivity = 2.0f;
	[SerializeField, Range(1f, 20f)]public float distance = 5f;
    Vector3 followPoint;
    [SerializeField] private float desiredDistance;
    Vector3 desiredPosition;
    float velocityX,velocityY,rotationXAxis,rotationYAxis = 0.0f;
    public float xSpeed = 20.0f;
    public float ySpeed = 20.0f;
    public float yMinLimit = -90f;
    public float yMaxLimit = 90f;
    public float distanceMin = 10f;
    public float distanceMax = 10f;
    public float smoothTime = 2f;
    private Vector2 input;
    public bool playerGrounded;     
    Ray cameraRay;
    Camera regularCamera;
    [SerializeField]private LayerMask rayMaskForCamera;
    [SerializeField]private float width;
    Vector3 CameraHalfExtends 
    {
		get 
        {
			Vector3 halfExtends;
			halfExtends.y =
				regularCamera.nearClipPlane *
				Mathf.Tan(0.5f * Mathf.Deg2Rad * regularCamera.fieldOfView);
			halfExtends.x = halfExtends.y * regularCamera.aspect;
			halfExtends.z = 0f;
			return halfExtends;
		}
	}

    private void Awake() 
    {
        regularCamera = GetComponent<Camera>();
        Vector3 angles = transform.eulerAngles;
        rotationYAxis = angles.y;
        rotationXAxis = angles.x;
        followPoint = follow.position;
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void Update() 
    {
        GetInput();
        cameraRay = new Ray(followPoint,  (transform.position - followPoint).normalized);
    }

    private void LateUpdate() 
    {
        UpdateCamera();
	}

    public void UpdateCamera()
    {
        CameraRotation();
        UpdateFollowPoint();
    }

    private void CameraRotation()
    {
        
        velocityX = xSpeed * Input.GetAxis("Mouse X") * 0.02f * (lookSensitivity/3);
        velocityY = ySpeed * Input.GetAxis("Mouse Y") * 0.02f * (lookSensitivity/3);

        rotationYAxis += velocityX;
        rotationXAxis -= velocityY;
        rotationXAxis = ClampAngle(rotationXAxis, yMinLimit, yMaxLimit);
        Quaternion toRotation = Quaternion.Euler(rotationXAxis, rotationYAxis, 0);
        Quaternion rotation = toRotation;
 
        transform.rotation = rotation;
    }

    void UpdateFollowPoint()
    {
        Vector3 targetPoint = follow.position;
    	Vector3 lookDirection = transform.forward;
        followPoint = targetPoint;

        bool wallInWay = Physics.BoxCast(cameraRay.origin, CameraHalfExtends,cameraRay.direction,out RaycastHit hit, Quaternion.LookRotation(lookDirection) , distance, rayMaskForCamera);

        if(wallInWay)
        {
            desiredPosition = followPoint - lookDirection * (hit.distance * 19/20 + regularCamera.nearClipPlane);
        }
        else
        {
            desiredPosition =  followPoint - lookDirection * distance;
        }

        transform.localPosition = desiredPosition;
    }
    
     public static float ClampAngle(float angle, float min, float max)
     {
         if (angle < -360F)
             angle += 360F;
         if (angle > 360F)
             angle -= 360F;
         return Mathf.Clamp(angle, min, max);
     }

    private void GetInput()
    {
        input = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
    }
}
