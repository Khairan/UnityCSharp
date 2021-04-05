using System.Threading;
#if UNITY_EDITOR
using UnityEditor;
#endif
using UnityEngine;


namespace RollABall
{
    public sealed class TestEditorBehaviour : MonoBehaviour
    {
        public float Count = 20;
        public int Step = 1;
        private void Start()
        {
#if UNITY_EDITOR
            for (var i = 0; i < Count; i++)
            {
                EditorUtility.DisplayProgressBar("Загрузка", $" проценты {i}",
                   i / Count);
                Thread.Sleep(Step * 100);
            }
            EditorUtility.ClearProgressBar();
            var isPressed = EditorUtility.DisplayDialog("Вопрос", @"Поставить на паузу ? ", "Да", "Нет");
            if (isPressed)
            {
                EditorApplication.isPaused = true;
            }
#endif
        }
    }
}