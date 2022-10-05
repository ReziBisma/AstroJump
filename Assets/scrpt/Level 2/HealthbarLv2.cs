using UnityEngine;
using UnityEngine.UI;

public class HealthbarLv2 : MonoBehaviour
{
    [SerializeField] private PlayerLv2 playerHealth;
    [SerializeField] private Image currenthealthBar;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        currenthealthBar.fillAmount = playerHealth.currentHealth2/10;
    }
}
