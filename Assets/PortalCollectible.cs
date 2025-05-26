using UnityEngine;

public class PortalCollectible : MonoBehaviour
{
    public GameObject questionUI; // referință la UI
    public Transform teleportTarget;
    private GameObject player;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        questionUI.SetActive(false);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            questionUI.SetActive(true);
            Time.timeScale = 0f; // oprește timpul ca să răspundă
        }
    }

    // Funcție corectă care va fi selectabilă în OnClick
    public void AnswerCorrect()
    {
        questionUI.SetActive(false);
        Time.timeScale = 1f;
        player.transform.position = teleportTarget.position;
        Destroy(gameObject);
    }

    // Funcție corectă care va fi selectabilă în OnClick
    public void AnswerWrong()
    {
        questionUI.SetActive(false);
        Time.timeScale = 1f;
        Destroy(gameObject); // dispare portalul
    }
}