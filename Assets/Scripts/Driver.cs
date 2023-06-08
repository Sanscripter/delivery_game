using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Driver : MonoBehaviour
{
    [SerializeField] float steeringSpeed = 200f;
    [SerializeField] float steeringDirection = 0;
    [SerializeField] float acceleration = 20f;
    [SerializeField] float currentSpeed = 0f;
    [SerializeField] float boostSpeed = 100f;
    [SerializeField] float nerfedSpeed = 6f;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Driver is initialized.");
    }

    // Update is called once per frame
    void Update()
    {
        //rotate drver
        steeringDirection = Input.GetAxis("Horizontal") * Time.deltaTime;
        currentSpeed = Input.GetAxis("Vertical") * acceleration * Time.deltaTime;
        this.transform.Rotate(0, 0 , - steeringSpeed * steeringDirection);
        this.transform.Translate(0, currentSpeed, 0);
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.tag == "Boost") {
            Debug.Log("Boosted");
           acceleration = boostSpeed;
           return;
        }
    }

    void OnCollisionEnter2D(Collision2D other) {
            Debug.Log("Nerfed");
            acceleration = nerfedSpeed;
    }

}
