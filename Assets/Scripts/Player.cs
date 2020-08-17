using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // Dragging
    private float distance;
    private bool dragging;
    private float limiteSuperior;
    private float limiteInferior;
    private float limiteIzquierdo;
    private float limiteDerecho;

    // Start is called before the first frame update
    void Start()
    {
        dragging = false;
        limiteSuperior = 4.06f;
        limiteInferior = -4.22f;
        limiteIzquierdo = -7.96f;
        limiteDerecho = 8.16f;   
    }

    // Update is called once per frame
    void Update()
    {
        if (dragging) {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            Vector3 rayPoint = ray.GetPoint(distance);
            rayPoint.z = 0;
            if (rayPoint.y > limiteSuperior) {
                rayPoint.y = limiteSuperior;
            }
            if (rayPoint.y < limiteInferior) {
                rayPoint.y = limiteInferior;
            }
            if (rayPoint.x > limiteDerecho) {
                rayPoint.x = limiteDerecho;
            }
            if (rayPoint.x < limiteIzquierdo) {
                rayPoint.x = limiteIzquierdo;
            }
            transform.position = rayPoint;
        }
    }

    private void OnMouseDown() {
        dragging = true;
        distance = Vector3.Distance(transform.position, Camera.main.transform.position);

    }

    private void OnMouseUp() {
        dragging = false;
    }
}
