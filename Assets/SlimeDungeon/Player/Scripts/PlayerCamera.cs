using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCamera : MonoBehaviour
{
    float rotationX;
    float rotationY;
    float angleMax = 90;
    float angleMin = -90;
    public Camera playerCamera;
    public float sensitivityX;
    public float sensitivityY;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }



    // Update is called once per frame
    void Update()
    {
        //Conjunto que controla a rotação da câmera
        float horizontalDelta = Input.GetAxisRaw("Mouse Y") * sensitivityY;
        float verticalDelta = Input.GetAxisRaw("Mouse X") * sensitivityX;

        rotationY += verticalDelta;
        rotationX += horizontalDelta;

        transform.localEulerAngles = new Vector3(0f, rotationY, 0f);
        playerCamera.transform.localEulerAngles = new Vector3(-rotationX, 0f, 0f);

        //Limita o angulo de rotação vertical da câmera
        //O método Mathf.Clamp tem como parâmetros o valor a ser verificado junto com os valores máximo e mínimo
        //que não deixam retornar valores além desses limitadores.
        rotationX = Mathf.Clamp(rotationX, angleMin, angleMax);
    }
}
