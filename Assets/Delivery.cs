using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Delivery : MonoBehaviour
{
    [SerializeField]
    private float packageDelay = 0;

    [SerializeField]
    private Color32 hasPackageColor = new Color32(1, 1, 1, 1);

    [SerializeField]
    private Color32 noPackageColor = new Color32(1, 1, 1, 1);

    private bool hasPackage = false;

    private SpriteRenderer spriteRenderer;

    private void Start()
    {
        this.spriteRenderer = this.GetComponent<SpriteRenderer>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Collision detected.");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Package" && !this.hasPackage)
        {
            this.PickUpPackage(collision);
        }
        else if (collision.tag == "Customer" && this.hasPackage)
        {
            this.DeliverPackage();
        }
    }

    private void PickUpPackage(Collider2D collision)
    {
        Debug.Log("Package acquired.");
        this.hasPackage = true;
        this.spriteRenderer.color = this.hasPackageColor;

        Destroy(collision.gameObject, this.packageDelay);
    }

    private void DeliverPackage()
    {
        Debug.Log("Package delivered!");
        this.hasPackage = false;
        this.spriteRenderer.color = this.noPackageColor;
    }
}
