using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour {

    public float RotateSpeed;
    public float InvertSpeed;
    private Animator animator;

    private float invert = 1.0f;

	// Use this for initialization
	void Start () {
        animator = GetComponent<Animator>();
    }
	
	// Update is called once per frame
	void Update () {
        float inputX = Input.GetAxis("Horizontal");
        float inputY = Input.GetAxis("Vertical");
        float inputRun = Input.GetAxis("Run");

        inputRun += 1;

        if (inputY < 0) {
            invert = Mathf.Max(invert - InvertSpeed * Time.deltaTime, -1.0f);
        } else if (inputY > 0) {
            invert = Mathf.Min(invert + InvertSpeed * Time.deltaTime, 1.0f);
        }

        animator.SetFloat("BlendX", inputX * inputRun * invert);
        animator.SetFloat("BlendY", inputY * inputRun);

        if (Mathf.Abs(inputY) < 0.1f) return;

        float angle = Mathf.Rad2Deg * Mathf.Atan2(0, inputY);
        Quaternion targetRotation = Quaternion.Euler(0, angle, 0);
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, RotateSpeed * Time.deltaTime);
    }
}
