using UnityEngine;
using UnityEngine.Events;

public class OpenGate : MonoBehaviour
{
    [SerializeField] GameObject gate;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")){
            Debug.Log("Abrir portão");
            gate.SetActive(false);
        }
    }
}
