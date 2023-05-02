using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RegisterPage : MonoBehaviour
{
    public Canvas login;
    public Canvas register;

    public void Register()
    {
        login.gameObject.SetActive(false);
        register.gameObject.SetActive(true);
    }
}
