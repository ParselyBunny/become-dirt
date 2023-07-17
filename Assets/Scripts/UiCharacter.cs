using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UiCharacter : MonoBehaviour
{
    public Image character;
    public String name;
    public Animator anim;

    public void setActive(bool b)
    {
        anim.SetBool("Active", b);
    }
}
