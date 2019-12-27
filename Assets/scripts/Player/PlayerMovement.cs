﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float _jumpHeight = 5.0f;
    public float _speed = 2.0f;

    public Transform _groundCheck;

    private Animator _animator;
    private Rigidbody2D _rigidbody2D;
    private SpriteRenderer _spriteRenderer;
    // Start is called before the first frame update
    void Start()
    {
        _animator = GetComponent<Animator>();
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        var moveHorizontal = Input.GetAxis("Horizontal");

        var isMoving = moveHorizontal == 1 | moveHorizontal == -1;

        _animator.SetBool("isMoving", isMoving);
        _animator.SetBool("isGrounded", isGrounded());

        if (Input.GetAxis("Jump") == 1 && isGrounded())
        {
            _rigidbody2D.velocity = new Vector3(_rigidbody2D.velocity.x, _jumpHeight * 0.5f);
        }

        if (moveHorizontal == 1)
        {
            _spriteRenderer.flipX = false;

            transform.position += _speed * Time.deltaTime * Vector3.right;
        }

        if (moveHorizontal == -1)
        {
            _spriteRenderer.flipX = true;

            transform.position += _speed * Time.deltaTime * -Vector3.right;
        }    
    }

    bool isGrounded()
    {
        var grounded = Physics2D.Raycast(_groundCheck.position, Vector2.down, 0.1f);

        return grounded; 
    }
}