using System.Collections;
using UnityEngine;

public class damAttack : MonoBehaviour
{
    public GameObject[] death; // Основные объекты для спавна
    public Transform spawnPoint; // Точка спавна
    public float spawnDelay = 5f; // Задержка перед спавном
    public float destroyDelay = 5f; // Время до уничтожения

    public GameObject knowOne, knowTwo, knowThree, knowFour; // Объекты, активирующиеся перед спавном

    public void SpawnPrefab()
    {
        if (death == null || death.Length == 0 || spawnPoint == null)
        {
            Debug.LogWarning("DamAttack: Массив death пуст или spawnPoint не назначен!");
            return;
        }

        StartCoroutine(SpawnWithDelay());
    }

    private IEnumerator SpawnWithDelay()
    {
        int index = Random.Range(0, death.Length);

        // Деактивируем все Know-объекты перед активацией нужного
        DisableAllKnowObjects();

        // Включаем соответствующий Know-объект
        GameObject activeKnow = null;
        switch (index)
        {
            case 0:
                if (knowOne != null) activeKnow = knowOne;
                break;
            case 1:
                if (knowTwo != null) activeKnow = knowTwo;
                break;
            case 2:
                if (knowThree != null) activeKnow = knowThree;
                break;
            case 3:
                if (knowFour != null) activeKnow = knowFour;
                break;
            default:
                Debug.LogWarning("DamAttack: Индекс вышел за пределы массива!");
                yield break;
        }

        if (activeKnow != null)
        {
            activeKnow.SetActive(true);
        }

        // Ждем перед спавном основного объекта
        yield return new WaitForSeconds(spawnDelay);

        // Спавним основной объект
        GameObject spawnedObject = Instantiate(death[index], spawnPoint.position, Quaternion.identity);

        // Ждем перед удалением основного объекта
        yield return new WaitForSeconds(destroyDelay);
        Destroy(spawnedObject);

        // Отключаем Know-объект после удаления основного
        if (activeKnow != null)
        {
            activeKnow.SetActive(false);
        }
    }

    private void DisableAllKnowObjects()
    {
        if (knowOne != null) knowOne.SetActive(false);
        if (knowTwo != null) knowTwo.SetActive(false);
        if (knowThree != null) knowThree.SetActive(false);
        if (knowFour != null) knowFour.SetActive(false);
    }
}