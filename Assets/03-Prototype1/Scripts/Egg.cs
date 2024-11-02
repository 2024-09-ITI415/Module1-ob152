using UnityEngine;
using UnityEngine.SceneManagement;
public class Egg : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Congratulatios! You found the Egg and won!");
        }
    }
}
