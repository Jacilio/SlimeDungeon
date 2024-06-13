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
        //Conjunto que controla a rota��o da c�mera
        float horizontalDelta = Input.GetAxisRaw("Mouse Y") * sensitivityY;
        float verticalDelta = Input.GetAxisRaw("Mouse X") * sensitivityX;

        rotationY += verticalDelta;
        rotationX += horizontalDelta;

        transform.localEulerAngles = new Vector3(0f, rotationY, 0f);
        playerCamera.transform.localEulerAngles = new Vector3(-rotationX, 0f, 0f);

        //Limita o angulo de rota��o vertical da c�mera
        //O m�todo Mathf.Clamp tem como par�metros o valor a ser verificado junto com os valores m�ximo e m�nimo
        //que n�o deixam retornar valores al�m desses limitadores.
        rotationX = Mathf.Clamp(rotationX, angleMin, angleMax);
    }
}
