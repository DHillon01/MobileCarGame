using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConvyorBelt : MonoBehaviour
{
    Rigidbody rb;
    [SerializeField] private float speed;

    private Material material;
    // The offset of the texture
   [SerializeField] private float offset;
    [SerializeField] private float tex_speed;

    void Start()
    {
         rb = GetComponent<Rigidbody>();
        material = GetComponent<Renderer>().material;
    }
    private void FixedUpdate()
    {
        Vector3 pos = rb.position;
        rb.position += Vector3.right * speed * Time.fixedDeltaTime;
            rb.MovePosition(pos);
        // Update the offset based on the speed and direction
        offset += (float)(tex_speed) * Time.fixedDeltaTime;

        // Set the texture offset of the material
        material.SetTextureOffset("_MainTex", Vector3.left * offset);

    }
}
