using System;
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

    public static void Calculate(TextBox display, Button button)
    {
        char @operator = Convert.ToChar(button.Content.ToString());
        string txt = display.Text.Trim();

        if (string.IsNullOrEmpty(txt))
        {
            return;
        }

        // Если это первое вхождение оператора, добавляем оператор на дисплей
        if (!txt.Contains("+")
            && !txt.Contains("-")
            && !txt.Contains("*")
            && !txt.Contains("/"))
        {
            display.Text += " ";
            display.Text += @operator;
            display.Text += " ";
            return;
        }

        // Если эо первое вхождение, но при этом нужно перезаписать символ, а не произвести вычисления
        if (txt.EndsWith("+"))
        {
            display.Text = display.Text.Replace('+', @operator);
            return;
        }
        else if (txt.EndsWith("-"))
        {
            display.Text = display.Text.Replace('-', @operator);
            return;
        }
        else if (txt.EndsWith("*"))
        {
            display.Text = display.Text.Replace('*', @operator);
            return;
        }
        else if (txt.EndsWith("/"))
        {
            display.Text = display.Text.Replace('/', @operator);
            return;
        }

        // Произвести вычисления в случае если уже имеется оператор 
        if (txt.Contains("+"))
        {
            int startPos = txt.IndexOf('+');

            string parseFirst = txt.Substring(0, startPos).Trim();
            int firstNumber = Convert.ToInt32(parseFirst);

            string parseSecond = txt.Substring(startPos + 1, txt.Length - startPos - 1).Trim();
            int secondNumber = Convert.ToInt32(parseSecond);

            int result = firstNumber + secondNumber;

            display.Text = $"{result} {@operator} ";
            return;
        }
        else if (txt.Contains("-"))
        {
            int startPos = txt.IndexOf('-');

            string parseFirst = txt.Substring(0, startPos).Trim();
            int firstNumber = Convert.ToInt32(parseFirst);

            string parseSecond = txt.Substring(startPos + 1, txt.Length - startPos - 1).Trim();
            int secondNumber = Convert.ToInt32(parseSecond);

            int result = firstNumber - secondNumber;

            display.Text = $"{result} {@operator} ";
            return;
        }
        else if (txt.Contains("*"))
        {
            int startPos = txt.IndexOf('*');

            string parseFirst = txt.Substring(0, startPos).Trim();
            int firstNumber = Convert.ToInt32(parseFirst);

            string parseSecond = txt.Substring(startPos + 1, txt.Length - startPos - 1).Trim();
            int secondNumber = Convert.ToInt32(parseSecond);

            int result = firstNumber * secondNumber;

            display.Text = $"{result} {@operator} ";
            return;
        }
        else if (txt.Contains("/"))
        {
            int startPos = txt.IndexOf('/');

            string parseFirst = txt.Substring(0, startPos).Trim();
            int firstNumber = Convert.ToInt32(parseFirst);

            string parseSecond = txt.Substring(startPos + 1, txt.Length - startPos - 1).Trim();
            int secondNumber = Convert.ToInt32(parseSecond);

            int result = firstNumber / secondNumber;

            display.Text = $"{result} {@operator} ";
            return;
        }
    }
}