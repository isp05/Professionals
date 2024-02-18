using System.Diagnostics;
using System.Drawing.Text;
using System.IO;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using Avalonia.Media;
using System.Linq;
using MySqlConnector;
using System.Data.Common;
using System;
using System.Net.Mail;


namespace AvaloniaDemo_3.App;
public partial class MainWindow : Window
{   
    private MySqlConnection connection;
    public MainWindow()
    {
        DatePicker birthDatePicker = new DatePicker();
        InitializeComponent(); 
        }
    public void InitializeComponent()
    {
        AvaloniaXamlLoader.Load(this);
    }
    public void Clear_OnClick(object? sender, RoutedEventArgs e)
    {
        TextBox textBoxFirst = this.FindControl<TextBox>("InputFirstName");
        textBoxFirst.Clear();
        TextBox textBoxLast = this.FindControl<TextBox>("InputLastName");
        textBoxLast.Clear();
        TextBox textBoxPatronymic = this.FindControl<TextBox>("InputPatronymic");
        textBoxPatronymic.Clear();
        TextBox textBoxAddress = this.FindControl<TextBox>("InputAddress");
        textBoxAddress.Clear();
        TextBox textBoxEmail = this.FindControl<TextBox>("InputEmail");
        textBoxEmail.Clear();
        TextBox textBoxMedicalCardNumber = this.FindControl<TextBox>("InputMedicalCardNumber");
        textBoxMedicalCardNumber.Clear();
        TextBox textBoxIndurancePolicyNumber = this.FindControl<TextBox>("InputIndurancePolicyNumber");
        textBoxIndurancePolicyNumber.Clear();
    }
    private void ConnectToDatabase(object? sender, RoutedEventArgs e)
    {
        string connectionString = "server=localhost;user=root;password=142434;database=usersdb;";
        using (MySqlConnection connection = new MySqlConnection(connectionString))
        {
            connection.Open();
            //var datePicker = this.FindControl<DatePicker>("InputBirthday");
            //DateTimeOffset SelectedDate = datePicker.SelectedDate.GetValueOrDefault();
            //string dateOfBirth = SelectedDate.ToString("yyyy-MM-dd");
            //var datePicker2 = this.FindControl<DatePicker>("InputDateMedicalCard");
            //DateTimeOffset SelectedDate2 = datePicker.SelectedDate.GetValueOrDefault();
            //string medicalCardIssueDate = SelectedDate.ToString("yyyy-MM-dd");
            //var datePicker3 = this.FindControl<DatePicker>("InputIndurancePolicyIssueDate");
            //DateTimeOffset SelectedDate3 = datePicker.SelectedDate.GetValueOrDefault();
            //string insurancePolicyEnd = SelectedDate.ToString("yyyy-MM-dd");
            TextBox firstNameTextBox = this.FindControl<TextBox>("InputFirstName");
            string firstName = firstNameTextBox.Text;
            TextBox lastNameTextBox = this.FindControl<TextBox>("InputLastName");
            string lastName = lastNameTextBox.Text;
            TextBox patronymicTestBox = this.FindControl<TextBox>("InputPatronymic");
            string patronymic = patronymicTestBox.Text;
            TextBox addressTextBox = this.FindControl<TextBox>("InputAddress");
            string address = addressTextBox.Text;
            //TextBox emailTextBox = this.FindControl<TextBox>("InputEmail");
            //string email = emailTextBox.Text;
            if (string.IsNullOrWhiteSpace(firstName) || string.IsNullOrWhiteSpace(lastName) || string.IsNullOrWhiteSpace(patronymic) || 
            string.IsNullOrWhiteSpace(address))
            {
                return;
            }
            string query = "INSERT INTO users (firstName, surname, patronymic, address) VALUES (@firstName, @surname, @patronymic, @address)";

            using (MySqlCommand command = new MySqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@firstName", firstName);
                command.Parameters.AddWithValue("@surname", lastName);
                command.Parameters.AddWithValue("@patronymic", patronymic);
                command.Parameters.AddWithValue("@address", address);
                //command.Parameters.AddWithValue("@email", email);
                //command.Parameters.AddWithValue("@dateOfBirth", dateOfBirth);
                //command.Parameters.AddWithValue("@medicalCardIssueDate", medicalCardIssueDate);
               // command.Parameters.AddWithValue("@insurancePolicyEnd", insurancePolicyEnd);
                command.ExecuteNonQuery();

            }
        }
    }
}
public partial class NewWindow : Window
{
    public NewWindow()
    {
        InitializeComponent();
    }
    public void InitializeComponent()
    {
        AvaloniaXamlLoader.Load(this);
    }
}
public partial class ThirdWindow : Window
{
    public ThirdWindow()
    {
        InitializeComponent();
    }
    public void InitializeComponent()
    {
        AvaloniaXamlLoader.Load(this);
    }
}

