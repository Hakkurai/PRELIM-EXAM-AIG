using UnityEngine;
using UnityEngine.SceneManagement;

public class ItemCollector : MonoBehaviour
{
    private bool isNearCube = false;
    private GameObject targetCube;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && isNearCube && targetCube != null)
        {
            // Collect the cube
            Destroy(targetCube);

            // Load next scene
            SceneManager.LoadScene("Level_2");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Pickup"))
        {
            isNearCube = true;
            targetCube = other.gameObject;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Pickup"))
        {
            isNearCube = false;
            targetCube = null;
        }
    }
}
