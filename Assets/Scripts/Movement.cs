using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
  Rigidbody rb;
  [SerializeField] float RocketThrust = 1000f;
  [SerializeField] float RocketRotation = 100f;

  // Start is called before the first frame update
  void Start()
  {
    rb = GetComponent<Rigidbody>();
  }

  // Update is called once per frame
  void Update()
  {
    ProcessThrust();
    ProcessRotation();
  }

  void ProcessThrust()
  {
    if (Input.GetKey(KeyCode.Space))
    {
      rb.AddRelativeForce(Vector3.up * RocketThrust * Time.deltaTime);
    }
  }

  void ProcessRotation()
  {
    if (Input.GetKey(KeyCode.A))
    {
      ApplyRotation(RocketRotation);
    }
    else if (Input.GetKey(KeyCode.D))
    {
      ApplyRotation(-RocketRotation);
    }
  }

  public void ApplyRotation(float rotationThisFrame)
  {
    // Freeze Physics Rotation whenever we collide with objects in level
    rb.freezeRotation = true; // So we can manually rotate.
    transform.Rotate(Vector3.forward * rotationThisFrame * Time.deltaTime);
    rb.freezeRotation = false; // unfreezing rotation so the physics system can take over.
  }
}
