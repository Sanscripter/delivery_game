using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Delivery : MonoBehaviour
{
    [SerializeField] Color32 packageHolderColor = new Color32(255, 255, 255, 255);
    [SerializeField] Color32 defaultColor = new Color32(1, 1, 1, 1);
    bool hasPackage = false;
    SpriteRenderer spriteRenderer;

    private void Start() {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void OnCollisionEnter2D(Collision2D other) {
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.tag == "Package" && !hasPackage) {
            hasPackage = true;
            spriteRenderer.color = packageHolderColor;
            Destroy(other.gameObject);
            Debug.Log("Picked up Package");
            return;
        }	
        if (other.tag == "Customer" && hasPackage) {
            hasPackage = false;
            spriteRenderer.color = defaultColor;
            Debug.Log(defaultColor);
            Debug.Log("Delivered to Customer");
            return;
        } 
        if (other.tag == "Customer" && !hasPackage) {
            Debug.Log("No Package");
            return;
        }	
    }
}
