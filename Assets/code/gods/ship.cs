using System.Collections;
using UnityEngine;

public class ship : MonoBehaviour
{
    public GameObject preShip;   // Предварительный объект
    public GameObject mainShip;  // Основной объект

    public float spawnDelay = 4f;     // Когда активировать основной объект (через 4 секунды)
    public float hideDelay = 6f;      // Через сколько отключить предварительный объект
    public float mainHideDelay = 10f; // Через сколько отключить основной объект

    void Start()
    {
        if (preShip != null) preShip.SetActive(false);
        if (mainShip != null) mainShip.SetActive(false);
    }

    public IEnumerator RepeatActivation()
    {
        yield return StartCoroutine(ActivateObjects());
    }

    IEnumerator ActivateObjects()
    {
        if (preShip != null) preShip.SetActive(true);
        yield return new WaitForSeconds(spawnDelay);

        if (mainShip != null) mainShip.SetActive(true);
        yield return new WaitForSeconds(hideDelay - spawnDelay);

        if (preShip != null) preShip.SetActive(false);
        yield return new WaitForSeconds(mainHideDelay - hideDelay);

        if (mainShip != null) mainShip.SetActive(false);
    }
}