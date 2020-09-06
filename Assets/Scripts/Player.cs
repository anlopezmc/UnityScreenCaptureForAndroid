using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // Dragging
    private float distance;
    private bool dragging;
    private float upperLimit;
    private float lowerLimit;
    private float leftLimit;
    private float rightLimit;

    // Start is called before the first frame update
    void Start()
    {
        dragging = false;
        Vector3 world_position_of_bottom_left = Camera.main.ScreenToWorldPoint(new Vector3(0.0f, 0.0f, 0.0f));
        Vector3 world_position_of_bottom_right = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, 0.0f, 0.0f));
        Vector3 world_position_of_up_left = Camera.main.ScreenToWorldPoint(new Vector3(0.0f, Screen.height, 0.0f));
        
        upperLimit = world_position_of_up_left.y - gameObject.GetComponent<SpriteRenderer>().bounds.size.y/2;
        lowerLimit = world_position_of_bottom_left.y + gameObject.GetComponent<SpriteRenderer>().bounds.size.y/2;
        leftLimit = world_position_of_bottom_left.x + gameObject.GetComponent<SpriteRenderer>().bounds.size.x/2;
        rightLimit = world_position_of_bottom_right.x - gameObject.GetComponent<SpriteRenderer>().bounds.size.x/2;
    }

    // Update is called once per frame
    void Update()
    {
        if (dragging) {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            Vector3 rayPoint = ray.GetPoint(distance);
            rayPoint.z = 0;
            if (rayPoint.y > upperLimit) {
                rayPoint.y = upperLimit;
            }
            if (rayPoint.y < lowerLimit) {
                rayPoint.y = lowerLimit;
            }
            if (rayPoint.x > rightLimit) {
                rayPoint.x = rightLimit;
            }
            if (rayPoint.x < leftLimit) {
                rayPoint.x = leftLimit;
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
