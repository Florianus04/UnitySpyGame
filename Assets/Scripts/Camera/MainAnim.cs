using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainAnim : MonoBehaviour
{
    public float sensitivity = 10f; // Fare hassasiyeti
    public float maxVerticalAngle = 2f; // Dikey dönüþ sýnýrý (derece)
    public float maxHorizontalAngle = 2f; // Yatay dönüþ sýnýrý (derece)
    public float smoothTime = 0.1f; // Dönüþün smooth olma süresi

    private float verticalRotation = 0f;
    private float horizontalRotation = 0f;
    private Vector3 currentRotation;
    private Vector3 rotationVelocity = Vector3.zero;
    private Vector3 initialRotation;

    void Start()
    {
        // Kameranýn baþlangýç rotasyonunu al
        initialRotation = transform.localEulerAngles;
        currentRotation = initialRotation;
    }

    void Update()
    {
        // Fare giriþini al
        float mouseX = Input.GetAxis("Mouse X") * sensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * sensitivity * Time.deltaTime;

        // Yatay ve dikey dönüþleri sýnýrla
        horizontalRotation += mouseX;
        verticalRotation -= mouseY;

        horizontalRotation = Mathf.Clamp(horizontalRotation, -maxHorizontalAngle, maxHorizontalAngle);
        verticalRotation = Mathf.Clamp(verticalRotation, -maxVerticalAngle, maxVerticalAngle);

        // Hedef rotasyonu ayarla, baþlangýç rotasyonuna göre
        Vector3 targetRotation = initialRotation + new Vector3(verticalRotation, horizontalRotation, 0f);

        // Kamerayý smooth þekilde döndür
        currentRotation = Vector3.SmoothDamp(currentRotation, targetRotation, ref rotationVelocity, smoothTime);
        transform.localRotation = Quaternion.Euler(currentRotation);
    }
}
