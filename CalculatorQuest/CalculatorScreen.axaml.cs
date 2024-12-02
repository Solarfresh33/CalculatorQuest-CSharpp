using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using System;
using Avalonia.Interactivity;

namespace CalculatorQuest;

public partial class CalculatorScreen : Window
{
    public string CurrentInput = "";
    public string FirstInput = "";
    public string Operand = "";

    
    public CalculatorScreen()
    {
        this.Width = 300;
        this.Height = 600;
        InitializeComponent();
    }
    

    private void Number_OnClick(object? sender, RoutedEventArgs e)
    {
     Button? btn = (Button)sender!;
     CurrentInput += btn.Content?.ToString();
     Numero.Content = CurrentInput;
    }
    
    private void Operator_OnClick(object? sender, RoutedEventArgs e)
    {
        Button? btn = (Button)sender!;
        FirstInput = CurrentInput;
        SavedNumber.Content = FirstInput;
        CurrentInput = "";
        Numero.Content = CurrentInput;

        if (btn == More)
        {
            Operation.Content = "+";
        }
        else if (btn == Less)
        {
            Operation.Content = "-";
        }
        else if (btn == Multiply)
        {
            Operation.Content = "x";
        }
        else if (btn == Divide)
        {
            Operation.Content = "/";
        }
        else if (btn == Mod)
        {
            Operation.Content = "%";
        }
        else if (btn == Sign)
        {
            Operation.Content = "+/-";
        }
    }

    private void C_Button_Click(object sender, RoutedEventArgs e)
    {
        CurrentInput = "";
        SavedNumber.Content = "";
        Numero.Content = CurrentInput;
    }
    private void EqualButton_Click(object sender, RoutedEventArgs e)
    {
        Calculs c = new Calculs();
        string operatorContent = Operation.Content.ToString(); 
        if (!string.IsNullOrEmpty(operatorContent))
        {
            string expression = FirstInput + operatorContent + CurrentInput;
            string result = c.Operator(expression);
            
            SavedNumber.Content = result.ToString();
            CurrentInput = result.ToString();
            Numero.Content = "";
            Operation.Content = "";
        }
    }
    
    private void Control_OnClick(object? sender, RoutedEventArgs e)
    {
        Button? btn = (Button)sender!;
        CurrentInput += btn.Content?.ToString();
        if (btn  == ClearAll)
        {
            CurrentInput = "";
            Numero.Content = CurrentInput;
        }       
    }
        private void Del_Button_Click(object sender, RoutedEventArgs e)
    {
        if (CurrentInput.Length != 0)
        {
        var size = CurrentInput.Length;
            CurrentInput = CurrentInput.Remove(size - 1);
            Numero.Content = CurrentInput;
        }
    }
}