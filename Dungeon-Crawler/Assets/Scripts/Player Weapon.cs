using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWeapon : MonoBehaviour
{
    public float damage;
    public float knockback;
    public SpriteRenderer weaponSprite;
    private float attackCooldown = .5f;
    private float lastSwing;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0)) {
            if (Time.time - lastSwing > attackCooldown) {
                lastSwing = Time.time;
                attack();
            }
        }
    }

    private void attack() {
        Debug.Log("Attack");
    }
    private void OnCollisionEnter2D(Collision2D other) {
        Debug.Log(other.collider.name);
    }
}
