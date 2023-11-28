using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

public class MenuHandler : MonoBehaviour
{
    [SerializeField]
    private RectTransform selector;
    [SerializeField]
    private List<MenuButton> buttons;

    private int indexNow;

    private void Awake()
    {
        for (int i = 0; i < buttons.Count; ++i)
        {
            buttons[i].index = i;
        }

        indexNow = 0;
        CheckButtonSelected(indexNow);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ClickButton(int index)
    {
        if (CheckButtonSelected(index))
        {
            buttons[index].events.Invoke();
        }
    }

    private bool CheckButtonSelected(int index)
    {
        if(indexNow == index)
            return true;

        indexNow = index;
        selector.SetParent(buttons[index].rectTransform);
        selector.anchorMin = new Vector2(0, 0);
        selector.anchorMax = new Vector2(1, 1);
        selector.offsetMin = new Vector2(0, 0);
        selector.offsetMax = new Vector2(1, 1);
        return false;
    }

    public void MovePrevious()
    {
        if (!gameObject.activeSelf)
            return;

        --indexNow;
        if (indexNow < 0)
            indexNow = buttons.Count - 1;

        CheckButtonSelected(indexNow);
    }
    public void MoveNext()
    {
        if (!gameObject.activeSelf)
            return;

        ++indexNow;
        if (indexNow >= buttons.Count)
            indexNow = 0;

        CheckButtonSelected(indexNow);
    }

    public void SelectMenu() => buttons[indexNow].events.Invoke();
}
