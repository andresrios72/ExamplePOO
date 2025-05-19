using UnityEngine;

public class Movimiento : MonoBehaviour
{
    [Header("Movimiento")]
    public float velocidadMovimiento = 5f;

    [Header("Salto")]
    public float fuerzaSalto = 8f;
    public float gravedad = 20f;

    [Header("Rotación")]
    public Transform camaraFPS;
    public float sensibilidadMouse = 2f;
    public float limiteVertical = 80f;

    private float rotacionX = 0f;
    private CharacterController controller;
    private Vector3 direccionMovimiento;
    private float velocidadVertical;

    void Start()
    {
        controller = GetComponent<CharacterController>();
        Cursor.lockState = CursorLockMode.Locked; // Oculta el cursor
    }

    void Update()
    {
        // Movimiento horizontal
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        Vector3 direccionHorizontal = transform.right * h + transform.forward * v;
        direccionHorizontal *= velocidadMovimiento;

        // Saltar si está en el suelo
        if (controller.isGrounded)
        {
            velocidadVertical = -1f; // Mantenlo pegado al suelo

            if (Input.GetButtonDown("Jump"))
            {
                velocidadVertical = fuerzaSalto;
            }
        }
        else
        {
            velocidadVertical -= gravedad * Time.deltaTime;
        }

        // Combinar el movimiento horizontal con el vertical
        direccionMovimiento = direccionHorizontal + Vector3.up * velocidadVertical;
        controller.Move(direccionMovimiento * Time.deltaTime);

        // Rotación de cámara y personaje
        float mouseX = Input.GetAxis("Mouse X") * sensibilidadMouse;
        float mouseY = Input.GetAxis("Mouse Y") * sensibilidadMouse;

        rotacionX -= mouseY;
        rotacionX = Mathf.Clamp(rotacionX, -limiteVertical, limiteVertical);

        camaraFPS.localRotation = Quaternion.Euler(rotacionX, 0, 0);
        transform.Rotate(Vector3.up * mouseX);
    }
}
