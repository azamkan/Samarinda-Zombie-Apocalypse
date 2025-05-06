using UnityEngine;

public class CameraController : MonoBehaviour
{
    [Header("Follow Settings")]
    [SerializeField] private Transform target; // Objek yang diikuti
    [SerializeField] private float smoothSpeed = 0.125f;
    [SerializeField] private Vector3 offset = new Vector3(0f, 0f, -10f); // Z tetap untuk kamera 2D

    [Header("Camera Boundaries")]
    [SerializeField] private bool useBounds = true;
    [SerializeField] private Collider2D boundaryObject;
    [SerializeField] private float edgeBuffer = 0.5f;
    [SerializeField] private float playerYOffset = 2f; // Jarak player dari bawah kamera

    private float minX, maxX, minY, maxY;
    private Camera cam;

    void Start()
    {
        cam = GetComponent<Camera>();
        if (useBounds && boundaryObject != null)
        {
            CalculateBoundsFromObject();
        }
    }

    void LateUpdate()
    {
        if (target == null) return;

        // Hitung posisi kamera yang diinginkan
        Vector3 desiredPosition = new Vector3(
            target.position.x + offset.x,
            target.position.y + offset.y,
            offset.z
        );

        // Sesuaikan Y kamera agar player selalu di bagian bawah
        float cameraBottomY = desiredPosition.y - cam.orthographicSize;
        float targetBottomY = target.position.y - playerYOffset;
        desiredPosition.y += (targetBottomY - cameraBottomY);

        if (useBounds && boundaryObject != null)
        {
            // Batasi posisi kamera
            desiredPosition.x = Mathf.Clamp(desiredPosition.x, minX, maxX);
            desiredPosition.y = Mathf.Clamp(desiredPosition.y, minY, maxY);
        }

        // Smoothing pergerakan kamera
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        transform.position = smoothedPosition;
    }

    private void CalculateBoundsFromObject()
    {
        if (boundaryObject == null) return;

        Bounds bounds = boundaryObject.bounds;
        float camHeight = cam.orthographicSize;
        float camWidth = camHeight * cam.aspect;

        minX = bounds.min.x + camWidth;
        maxX = bounds.max.x - camWidth;
        minY = bounds.min.y + camHeight;
        maxY = bounds.max.y - camHeight;

        // Pastikan kamera tidak keluar batas jika area terlalu kecil
        if (minX > maxX) minX = maxX = (minX + maxX) * 0.5f;
        if (minY > maxY) minY = maxY = (minY + maxY) * 0.5f;
    }
    //[Header("Follow Settings")]
    //[SerializeField] private Transform target; // Objek yang diikuti
    //[SerializeField] private float smoothSpeed = 0.125f;
    //[SerializeField] private Vector3 offset = new Vector3(0f, 0f, -10f);

    //[Header("Camera Boundaries")]
    //[SerializeField] private bool useBounds = true;
    //[SerializeField] private Collider2D boundaryObject; // Collider pembatas (BoxCollider2D, dll)
    //[SerializeField] private float edgeBuffer = 0.5f; // Jarak tambahan dari batas

    //private float minX, maxX, minY, maxY;

    //void Start()
    //{
    //    if (useBounds && boundaryObject != null)
    //    {
    //        CalculateBoundsFromObject();
    //    }
    //}

    //void LateUpdate()
    //{
    //    if (target == null) return;

    //    Vector3 desiredPosition = target.position + offset;

    //    if (useBounds && boundaryObject != null)
    //    {
    //        // Pastikan posisi kamera tidak melewati batas
    //        desiredPosition.x = Mathf.Clamp(desiredPosition.x, minX, maxX);
    //        desiredPosition.y = Mathf.Clamp(desiredPosition.y, minY, maxY);
    //    }

    //    Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
    //    transform.position = smoothedPosition;
    //}

    //private void CalculateBoundsFromObject()
    //{
    //    if (boundaryObject == null) return;

    //    // Dapatkan batas (bounds) dari Collider2D atau SpriteRenderer
    //    Bounds bounds = boundaryObject.bounds;

    //    // Hitung batas kamera berdasarkan ukuran kamera
    //    Camera cam = GetComponent<Camera>();
    //    float camHeight = cam.orthographicSize;
    //    float camWidth = camHeight * cam.aspect;

    //    // Hitung batas dengan buffer
    //    minX = bounds.min.x + camWidth - edgeBuffer;
    //    maxX = bounds.max.x - camWidth + edgeBuffer;
    //    minY = bounds.min.y + camHeight - edgeBuffer;
    //    maxY = bounds.max.y - camHeight + edgeBuffer;

    //    // Pastikan max >= min (jika kamera terlalu besar)
    //    if (minX > maxX) minX = maxX = (minX + maxX) * 0.5f;
    //    if (minY > maxY) minY = maxY = (minY + maxY) * 0.5f;
    //}

    // Visualisasi batas di Editor (opsional)
    private void OnDrawGizmosSelected()
    {
        if (useBounds && boundaryObject != null)
        {
            Gizmos.color = Color.green;
            Bounds bounds = boundaryObject.bounds;
            Gizmos.DrawWireCube(bounds.center, bounds.size);
        }
    }


    //[Header("Follow Settings")]
    //[SerializeField] private Transform target;
    //[SerializeField] private float smoothSpeed = 1f;
    //[SerializeField] private Vector3 offset = new Vector3(0f, 0f, -10f);

    //[Header("Camera Boundaries")]
    //[SerializeField] private bool useBounds = false;
    //[SerializeField] private float minX, maxX, minY, maxY;

    //void LateUpdate()
    //{
    //    if (target == null) return;

    //    Vector3 desiredPosition = target.position + offset;

    //    // Jika menggunakan batas kamera
    //    if (useBounds)
    //    {
    //        desiredPosition.x = Mathf.Clamp(desiredPosition.x, minX, maxX);
    //        desiredPosition.y = Mathf.Clamp(desiredPosition.y, minY, maxY);
    //    }

    //    Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
    //    transform.position = smoothedPosition;
    //}
}
