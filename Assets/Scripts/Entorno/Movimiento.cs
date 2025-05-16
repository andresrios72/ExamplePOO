using UnityEngine;

public class Movimiento : MonoBehaviour
{
    [Header("Movimiento")]
    public float velocidadMovimiento = 5f;

    [Header("Rotación")]
    public Transform camaraFPS;
    public float sensibilidadMouse = 2f;
    public float limiteVertical = 80f;

    private float rotacionX = 0f;
    private CharacterController controller;

    void Start()
    {
        controller = GetComponent<CharacterController>();
        Cursor.lockState = CursorLockMode.Locked; // Oculta el cursor
    }

    void Update()
    {
        // Movimiento
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        Vector3 direccion = transform.right * h + transform.forward * v;
        controller.Move(direccion * velocidadMovimiento * Time.deltaTime);

        // Rotación del mouse
        float mouseX = Input.GetAxis("Mouse X") * sensibilidadMouse;
        float mouseY = Input.GetAxis("Mouse Y") * sensibilidadMouse;

        rotacionX -= mouseY;
        rotacionX = Mathf.Clamp(rotacionX, -limiteVertical, limiteVertical);

        camaraFPS.localRotation = Quaternion.Euler(rotacionX, 0, 0);
        transform.Rotate(Vector3.up * mouseX);
    }
}
