using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class ButtonHandler : MonoBehaviour {

    [SerializeField] GameObject[] buttons;
    int selectedButton = -1;

    public void Quit()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            selectedButton += 1;
            if (selectedButton >= buttons.Length)
            {
                selectedButton = 0;
            }
            EventSystem.current.SetSelectedGameObject(buttons[selectedButton]);
        }
        else if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            selectedButton -= 1;
            if (selectedButton < 0)
            {
                selectedButton = buttons.Length - 1;
            }
            EventSystem.current.SetSelectedGameObject(buttons[selectedButton]);
        }
    }
}
