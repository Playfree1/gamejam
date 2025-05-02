using UnityEngine;

public class hammer : MonoBehaviour
{
    private GameObject[] generator;
    private generator[] scripts; // Изменил тип на generator (имя вашего класса)

    void Start()
    {
        generator = GameObject.FindGameObjectsWithTag("Generator");
        scripts = new generator[generator.Length]; // Инициализируем массив

        for (int i = 0; i < generator.Length; i++)
        {
            scripts[i] = generator[i].GetComponent<generator>();
        }
    }

    void Update()
    {
        bool allPowered = true; // Предполагаем, что все включены

        for (int i = 0; i < scripts.Length; i++)
        {
            if (scripts[i] == null) continue; // Пропускаем если скрипт не найден

            // Проверяем, что переменная _powered равна false
            // Предполагаю, что _powered - это поле или свойство в вашем классе generator
            if (!scripts[i]._powered)
            {
                allPowered = false;
                break; // Если хотя бы один не включен, прерываем цикл
            }
        }

        if (allPowered && scripts.Length > 0)
        {
            // Все генераторы включены, делаем что-то
            Debug.Log("All generators are powered!");
            for (int i = 0; i < scripts.Length; i++) { scripts[i]._powered = false; }
        }
    }
}
