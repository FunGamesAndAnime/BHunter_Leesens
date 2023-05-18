﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NavPlayerMovement : MonoBehaviour
{
    public float speed = 40.0f;
    public float rotationSpeed = 30.0f;
    Rigidbody rgBody = null;
    float trans = 0;
    float rotate = 0;

    public delegate void DropHive(Vector3 pos);
    public static event DropHive DroppedHive;
    private Animator anim;
    private Camera camera;
    private Transform LookTarget;
    private void Start()
    {
        rgBody = GetComponent<Rigidbody>();
        anim = GetComponentInChildren<Animator>();
        camera = GetComponentInChildren<Camera>();
        LookTarget = GameObject.Find("headaim target").transform;
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            DroppedHive?.Invoke(transform.position + (transform.forward * 10));
        }
        // Get the horizontal and vertical axis.
        // By default they are mapped to the arrow keys.
        // The value is in the range -1 to 1
        float translation = Input.GetAxis("Vertical");
        float rotation = Input.GetAxis("Horizontal");
        anim.SetFloat("speed", translation);

        trans += translation;
        rotate += rotation;
    }

    private void FixedUpdate()
    {
        Vector3 rot = transform.rotation.eulerAngles;
        rot.y += rotate * rotationSpeed * Time.deltaTime;
        rgBody.MoveRotation(Quaternion.Euler(rot));
        rotate = 0;

        Vector3 move = transform.forward * trans;
        move.y = rgBody.velocity.y;
        rgBody.velocity = move; //* Time.deltaTime;
        trans = 0;
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Hazard"))
        {
            anim.SetTrigger("died");
            StartCoroutine(ZoomOut());

        }
        else
        {
            anim.SetTrigger("twicth L ear");
        }
    }
    IEnumerator ZoomOut()
    {
        const int ITERATIONS = 5;
        for(int z = 0; z < ITERATIONS; z++)
        {
            camera.transform.Translate(camera.transform.forward * -1 * 5.0f/ITERATIONS);
            yield return new WaitForSeconds(1.0f / ITERATIONS);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Hazard"))
        {
            //LookTarget.position = other.transform.position;
            StartCoroutine(LookAndLookAway(LookTarget.position, other.transform.position));
        }
    }
    private IEnumerator LookAndLookAway(Vector3 targetPos, Vector3 hazardPos)
    {
        Vector3 targetDir = targetPos - transform.position;
        Vector3 hazardDir = hazardPos - transform.position;

        float angle = Vector2.SignedAngle(new Vector2(targetPos.x, targetPos.z), new Vector2(hazardPos.x, hazardPos.z));

        const int INTERVALS = 20;
        const float INTERAVL = 0.5f / INTERVALS;

        float angleInterval = angle / INTERVALS;
        for(int i = 0; i < INTERVALS; i++)
        {
            LookTarget.RotateAround(transform.position, Vector3.up, -angleInterval);
            yield return new WaitForSeconds(INTERAVL);
        }
        for (int i = 0; i < INTERVALS; i++)
        {
            LookTarget.RotateAround(transform.position, Vector3.up, angleInterval);
            yield return new WaitForSeconds(INTERAVL);
        }
    }
}
