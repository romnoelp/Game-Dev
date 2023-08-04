using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWeapon : MonoBehaviour
{
    public float damage;
    public float knockback;
    public SpriteRenderer weaponSprite;
    private readonly float attackCooldown = .2f;
    private float lastSwing;
    private Animator weaponAnimator;

    // Start is called before the first frame update
    void Start()
    {
        weaponAnimator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0)) {
            if (Time.time - lastSwing > attackCooldown) {
                lastSwing = Time.time;
                Attack();
            }
        }
    }

    private void Attack() {
        weaponAnimator.SetTrigger("isAttacking");
    }
    private void OnCollisionEnter2D(Collision2D other) {
        Debug.Log(other.collider.name);
    }
}
