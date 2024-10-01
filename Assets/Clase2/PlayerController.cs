using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerController : MonoBehaviour
{

    public float moveSpeed = 5f; // Velocidad de movimiento del personaje
    public float lookSpeed = 2f; // Sensibilidad de la c�mara
    public float jumpForce = 5f; // Fuerza del salto
    public float gravity = 9.8f; // Gravedad aplicada al personaje
    public Transform cameraTransform; // La c�mara que sigue al jugador

    private CharacterController controller;
    private Vector3 moveDirection = Vector3.zero;
    private float rotationX = 0f;

    void Start()
    {
        
        controller = GetComponent<CharacterController>();
        // Bloquea el cursor en el centro de la pantalla
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {
        // Control de la c�mara con el mouse
        float mouseX = Input.GetAxis("Mouse X") * lookSpeed;
        float mouseY = Input.GetAxis("Mouse Y") * lookSpeed;

        rotationX -= mouseY;
        rotationX = Mathf.Clamp(rotationX, -90f, 90f); // Limita la rotaci�n vertical

        // Rotar la c�mara en el eje X (vertical)
        cameraTransform.localRotation = Quaternion.Euler(rotationX, 0f, 0f);

        // Rotar el personaje en el eje Y (horizontal)
        transform.Rotate(Vector3.up * mouseX);

        // Movimiento del personaje con WASD
        float moveX = Input.GetAxis("Horizontal");
        float moveZ = Input.GetAxis("Vertical");

        Vector3 move = transform.right * moveX + transform.forward * moveZ;
        moveDirection.x = move.x * moveSpeed;
        moveDirection.z = move.z * moveSpeed;

        // Salto
        if (controller.isGrounded)
        {
            if (Input.GetButtonDown("Jump"))
            {
                moveDirection.y = jumpForce;
            }
        }
        else
        {
            moveDirection.y -= gravity * Time.deltaTime; // Aplicar gravedad
        }

        // Mover al personaje
        controller.Move(moveDirection * Time.deltaTime);
    }
}