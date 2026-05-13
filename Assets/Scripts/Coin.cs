using UnityEngine;

public class Coin : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
       
        if (other.CompareTag("Player"))
        {
           
            Debug.Log("Moneda encontrada. Destruyendo baliza sonora.");
            Destroy(gameObject);
        }
    }
}
