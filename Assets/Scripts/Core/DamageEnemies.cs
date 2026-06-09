using UnityEngine;

public class DamageEnemies : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public float DamageNum = 100.0f;
    
    void OnTriggerEnter2D ( Collider2D other ) {
          Health OtherHealth = other.GetComponent<Health>();
          Controller OtherController = other.GetComponent<Controller>();
          if (OtherController != null) { return; }
          if (OtherHealth != null) {
              OtherHealth.InflictDamage(DamageNum);
          }
     }
}
