using UnityEngine;

public class hammer : MonoBehaviour
{
    private GameObject[] generator;
    private generator[] scripts; // Изменил тип на generator (имя вашего класса)
    public float rotationSpeed = 50f;
    public float returnSpeed = 25f;
    public float targetAngle = 145f;

    private float currentAngle = 0f;
    private bool returning = false, done = true;

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
            done = false;
        }
        if (!done)
        {
            if (!returning)
            {
                // Вращаемся к цели
                float rotation = Time.deltaTime * rotationSpeed;
                currentAngle += rotation;

                transform.Rotate(0, 0, rotation);

                // Проверяем, достигли ли целевого угла
                if (currentAngle >= targetAngle)
                {
                    returning = true;
                }
            }
            else
            {
                // Возвращаемся назад
                float rotation = Time.deltaTime * returnSpeed;
                currentAngle -= rotation;

                transform.Rotate(0, 0, -rotation);

                // Проверяем, вернулись ли в исходное положение
                if (currentAngle <= 0f)
                {
                    currentAngle = 0f;
                    returning = false;
                    done = true;
                }
            }
        }
    }
}
