using UnityEngine;
using UnityEngine.Networking;
using System.Collections;

public class Player : Character {
    Animator anim;
    Rigidbody2D rigid;
    PolygonCollider2D collider;

    void Start() {
        base.Start();
        anim = GetComponent<Animator>();
        rigid = GetComponent<Rigidbody2D>();
        collider = GetComponent<PolygonCollider2D>();
    }

    override public void MoveLeft() {
        rigid.velocity = new Vector2(-stats.MoveSpeed.buffed, rigid.velocity.y);
        transform.localScale = new Vector3(-Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
        IsStay = false;
    }

    override public void MoveRight() {
        rigid.velocity = new Vector2(stats.MoveSpeed.buffed, rigid.velocity.y);
        transform.localScale = new Vector3(Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
        IsStay = false;
    }

    override public void Stop() {
        if (!IsStay) {
            rigid.velocity = new Vector2(0, rigid.velocity.y);
            transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
            IsStay = true;
        }
    }

    override public void Jump() {
        if (IsOnGround) {
            rigid.velocity = new Vector2(rigid.velocity.x, rigid.velocity.y/2 + stats.JumpStrength.buffed);
            IsOnGround = false;
        }
    }

    override public void ReceiveDamage(Damage damage) {
        stats.Health.current -= damage.count;
    }

    override public void ReceiveBuff(Buff buff) {
        CurrentBuffs.Add(buff);
    }

    void OnTriggerEnter2D(Collider2D other) {
        IsOnGround = true;
    }

    void Update() {
        if (!isLocalPlayer) return;

        if (Input.GetAxis("Horizontal") < 0) {
            MoveLeft();
        }

        if (Input.GetAxis("Horizontal") > 0) {
            MoveRight();
        }

        if (Input.GetAxis("Horizontal") == 0) {
            Stop();
        }

        if (Input.GetButtonDown("Jump")) {
            Jump();
        }
        
        anim.SetFloat("SpeedX", Mathf.Abs(rigid.velocity.x));
        anim.SetFloat("SpeedY", (rigid.velocity.y));
        anim.SetBool("IsOnGround", IsOnGround);
        anim.SetBool("IsStay", IsStay);
        Camera.main.transform.position = new Vector3(transform.position.x, transform.position.y, -10);
    }
}
