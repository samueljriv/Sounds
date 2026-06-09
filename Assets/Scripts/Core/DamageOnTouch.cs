using UnityEngine;

public class DamageOnTouch : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public float DamageNum = 10.0f;
    
    void OnTriggerEnter2D ( Collider2D other ) {
          Health OtherHealth = other.GetComponent<Health>();
          if (OtherHealth != null) {
              OtherHealth.InflictDamage(DamageNum);
          }
     }
}
