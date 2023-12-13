using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void StartButton()
    {
        SceneManager.LoadSceneAsync("SampleScene"); // ปุ่ม start ไปหน้าเล่นเกม

    }
    public void BackButton()
    {
        SceneManager.LoadSceneAsync("StartScene"); // ปุ่มกลับมาหน้า main menu
    }
    public void ExitButton()
    {
        Application.Quit(); // ปุ่มออกเกม
    }
}
