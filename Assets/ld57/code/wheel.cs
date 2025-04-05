using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections;
public class wheel : dragable
{
    private RectTransform rectTransform;  // Для получения RectTransform объекта
    private float initialRotation;        // Начальный угол вращения
    private float currentRotation;        // Текущий угол
    private float lastMouseX;             // Последняя позиция мыши по оси X
    private bool isDragging = false;      // Флаг, показывающий, что перетаскивание начато

    public float sensitivity = 0.1f;      // Чувствительность вращения
    public float smoothing = 0.1f;        // Плавность движения руля

    // Инициализация
    public override void Init()
    {
        base.Init();
        rectTransform = GetComponent<RectTransform>();  // Получаем RectTransform объекта
        initialRotation = rectTransform.rotation.eulerAngles.z;  // Сохраняем начальный угол
        currentRotation = initialRotation;  // Начальный угол равен текущему
        lastMouseX = Input.mousePosition.x;  // Запоминаем начальную позицию мыши по оси X
    }

    // Метод для обработки перетаскивания
    public override void drag_handler(PointerEventData eventData)
    {
        if (!isDragging)
            return;

        // Получаем текущую позицию мыши на экране
        float mouseX = Input.mousePosition.x;

        // Разница между текущей и предыдущей позицией мыши по оси X
        float deltaX = lastMouseX - mouseX;  // Инвертируем направление поворота

        // Вычисляем новый угол с учетом чувствительности
        float targetRotation = currentRotation + (deltaX * sensitivity);

        // Ограничиваем угол, чтобы руль не крутился на 180 градусов
        targetRotation = Mathf.Clamp(targetRotation, initialRotation - 90f, initialRotation + 90f);

        // Плавно изменяем текущий угол с учетом сглаживания
        currentRotation = Mathf.Lerp(currentRotation, targetRotation, smoothing);

        // Поворачиваем руль
        rectTransform.rotation = Quaternion.Euler(0, 0, currentRotation);

        // Обновляем последнюю позицию мыши для следующего шага
        lastMouseX = mouseX;
    }

    // Метод, который вызывается, когда перетаскивание начинается
    public override void begin_drag_handler(PointerEventData eventData)
    {
        base.begin_drag_handler(eventData);
        isDragging = true;  // Устанавливаем флаг, что перетаскивание началось
    }

    // Метод, который вызывается, когда перетаскивание заканчивается
    public override void end_drag_handler(PointerEventData eventData)
    {
        base.end_drag_handler(eventData);
        isDragging = false;  // Останавливаем перетаскивание

        // Плавно возвращаем руль в исходное положение
        StartCoroutine(SmoothReturnToInitialPosition());
    }

    // Плавное возвращение руля в исходное положение
    private IEnumerator SmoothReturnToInitialPosition()
    {
        float timeElapsed = 0f;
        float duration = 0.5f; // Длительность анимации (секунды)
        float startRotation = currentRotation;

        while (timeElapsed < duration)
        {
            currentRotation = Mathf.Lerp(startRotation, initialRotation, timeElapsed / duration);
            rectTransform.rotation = Quaternion.Euler(0, 0, currentRotation);
            timeElapsed += Time.deltaTime;
            yield return null;
        }

        currentRotation = initialRotation;  // Устанавливаем точное значение в конце
        rectTransform.rotation = Quaternion.Euler(0, 0, currentRotation);
    }

    // Функция для вывода угла поворота корабля относительно руля
    public float GetShipRotationAngle()
    {
        return currentRotation - initialRotation;
    }
}
