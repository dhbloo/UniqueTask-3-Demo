using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour {

    public float RotateSpeed;
    private Animator animator;

    private GameController game_controller;

	// Use this for initialization
	void Start () {
        animator = GetComponent<Animator>();

        game_controller = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
    }
	
	// Update is called once per frame
	void Update () {
        if (game_controller.IsPause())
            return;

        float inputX = Input.GetAxis("Horizontal");
        float inputY = Input.GetAxis("Vertical");
        float inputRun = Input.GetAxis("Run");

        inputRun += 1;

        animator.SetFloat("BlendX", inputX * inputRun);
        animator.SetFloat("BlendY", inputY * inputRun);

        if (Mathf.Abs(inputX) < 0.01f && Mathf.Abs(inputY) < 0.01f) return;

        float angle = Mathf.Rad2Deg * Mathf.Atan2(inputX, inputY);
        Quaternion targetRotation = Quaternion.Euler(0, angle, 0);
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, RotateSpeed * Time.deltaTime);
    }
}
