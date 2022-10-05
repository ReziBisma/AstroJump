using UnityEngine;
using UnityEngine.UI;

public class Healthbar : MonoBehaviour
{
    [SerializeField] private Player playerHealth;
    [SerializeField] private Image currenthealthBar;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        currenthealthBar.fillAmount = playerHealth.currentHealth/10;
    }
}
