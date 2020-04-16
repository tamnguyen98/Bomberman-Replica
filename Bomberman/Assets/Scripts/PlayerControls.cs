using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControls : MonoBehaviour
{
    Rigidbody2D rgbody;
    // Start is called before the first frame update
    void Start()
    {
        rgbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        rgbody.velocity = new Vector2(Input.GetAxis("Horizontal") * 5, Input.GetAxis("Vertical")* 5);
        // transform.Translate(new Vector3(Input.GetAxisRaw("Horizontal") *Time.deltaTime * 5, Input.GetAxisRaw("Vertical")*Time.deltaTime * 5, 0), Space.Self);
    }
}
