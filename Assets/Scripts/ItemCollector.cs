using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class ItemCollector : MonoBehaviour
{
    private bool isNearCube = false;
    private GameObject targetCube;

    public TextMeshProUGUI popupText; // Assign in Inspector

    void Start()
    {
        if (popupText != null)
            popupText.gameObject.SetActive(false);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && isNearCube && targetCube != null)
        {
            // Collect the cube
            Destroy(targetCube);

            if (popupText != null)
                popupText.gameObject.SetActive(false);

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

            if (popupText != null)
                popupText.gameObject.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Pickup"))
        {
            isNearCube = false;
            targetCube = null;

            if (popupText != null)
                popupText.gameObject.SetActive(false);
        }
    }
}
