using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Driver : MonoBehaviour
{
    [SerializeField]
    private float steerSpeed = 240f;

    [SerializeField]
    private float moveSpeed = 10f;

    [SerializeField]
    private float boostSpeed = 20f;

    [SerializeField]
    private float slowSpeed = 7f;

    /// <summary>
    /// Hit something, slow down.
    /// </summary>
    /// <param name="collision"></param>
    private void OnCollisionEnter2D()
    {
        this.moveSpeed = this.slowSpeed;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Boost")
        {
            this.moveSpeed = this.boostSpeed;
        }
    }

    // Update is called once per frame
    void Update()
    {
        float steerAmount = Input.GetAxis("Horizontal") * this.steerSpeed * Time.deltaTime;
        float moveAmount = Input.GetAxis("Vertical") * this.moveSpeed * Time.deltaTime;
        this.transform.Rotate(0, 0, -steerAmount);
        this.transform.Translate(0, moveAmount, 0);
    }
}
