using System.Windows;
using System.Windows.Controls;

namespace NumberManipulator;

public static class Core
{
    /// <summary>
    /// This method clear Calculator display.
    /// </summary>
    public static void Clear(TextBox display)
    {
        display.Text = string.Empty;
    }

    /// <summary>
    /// This method remove last operation or number.
    /// </summary>
    public static void RemoveLast(TextBox display)
    {
        string txt = display.Text;

        for (int i = txt.Length - 1; i >= 0; i--)
        {
            string removedCharter = txt[i].ToString();
            if (string.IsNullOrWhiteSpace(removedCharter))  // Если это пробел
            {
                txt = txt.Remove(i, 1); // удаляем
            }
            else    // Если это НЕ пробел
            {
                txt = txt.Remove(i, 1); // удаляем
                break;  // завершаем работу цикла
            }
        }

        display.Text = txt;
    }

    /// <summary>
    /// This method close programm.
    /// </summary>
    public static void Exit()
    {
        Application.Current.Shutdown();
    }

    public static void PrintButtonText(TextBox display, Button button)
    {
        display.Text += button.Content.ToString();
    }
}
