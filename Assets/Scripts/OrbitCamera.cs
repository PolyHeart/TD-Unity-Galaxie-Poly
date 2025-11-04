using UnityEngine;

public class OrbitCamera : MonoBehaviour
{
    [Header("Cible à orbiter (ex: le Soleil)")]
    [SerializeField] private Transform target;

    [Header("Contrôles")]
    [SerializeField] private float rotationSpeed = 100f;
    [SerializeField] private float zoomSpeed = 5f;
    [SerializeField] private float minDistance = 2f;
    [SerializeField] private float maxDistance = 50f;

    private float currentDistance = 10f;
    private float xRotation = 0f;
    private float yRotation = 0f;

    void Start()
    {
    

        currentDistance = Vector3.Distance(transform.position, target.position);

        Vector3 angles = transform.eulerAngles;
        xRotation = angles.y;
        yRotation = angles.x;

        Cursor.lockState = CursorLockMode.None;
    }

    void LateUpdate()
    {
        if (target == null) return;

        float inputX = Input.GetAxis("Horizontal");
        float inputY = Input.GetAxis("Vertical");

        if (Input.GetMouseButton(1)) 
        {
            inputX += Input.GetAxis("Mouse X");
            inputY -= Input.GetAxis("Mouse Y");
        }

        xRotation += inputX * rotationSpeed * Time.deltaTime;
        yRotation += inputY * rotationSpeed * Time.deltaTime;
        yRotation = Mathf.Clamp(yRotation, -80f, 80f); 

        float scroll = Input.GetAxis("Mouse ScrollWheel");
        currentDistance -= scroll * zoomSpeed;
        currentDistance = Mathf.Clamp(currentDistance, minDistance, maxDistance);

        Quaternion rotation = Quaternion.Euler(yRotation, xRotation, 0);
        Vector3 offset = rotation * new Vector3(0, 0, -currentDistance);
        transform.position = target.position + offset;
        transform.LookAt(target);
    }
}

