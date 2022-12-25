using System.Collections.Generic;
using UnityEngine;

namespace BusinessSimulator
{
    public class UI : MonoBehaviour
    {
        [SerializeField] private Window[] _windows;

        [ContextMenu("Find Windows In Childrens")]
        private void FindWindowsInChildrens()
        {
            List<Window> windows = new(transform.childCount);

            for (int i = 0; i < transform.childCount; i++)
            {
                if (transform.GetChild(i).TryGetComponent(out Window window))
                    windows.Add(window);
            }

            Debug.Log($"Found {windows.Count} windows!");
            _windows = windows.ToArray();
        }

        private void Awake()
        {
            if (_windows.Length == 0)
                FindWindowsInChildrens();

            for (int i = 0; i < _windows.Length; i++)
                _windows[i].Initialize();
        }
    }
}
