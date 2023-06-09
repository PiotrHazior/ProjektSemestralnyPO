﻿using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Data.SqlClient;

namespace ProjectCarRentalPH
{
    /// <summary>
    /// Interaction logic for RentalMenu.xaml
    /// </summary>
    public partial class RentalMenu : Window
    {
        #region Pola
        private List<Customer> registeredCustomers;
        private DataRowView selectedRow;  
        private int loggedInCustomerId;
        SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\piotr\Desktop\GITHUB\ProjektSemestralnyPO\ProjectCarRentalPH\ProjectCarRentalPH\Database.mdf;Integrated Security=True");
        #endregion

        #region Konstruktor
        public RentalMenu(List<Customer> registeredCustomers, int loggedInCustomerId)
        {
            InitializeComponent();
            this.registeredCustomers = registeredCustomers;
            this.loggedInCustomerId = loggedInCustomerId;
            LoadDataGrid();
        }
        #endregion

        #region Obsługa zdarzeń
        /// <summary>
        /// Przenosi do poprzedniego okna (Customer Menu)
        /// </summary>
        private void CustomerMenu(object sender, RoutedEventArgs e)
        {
            CustomerMenu objCustomerMenu = new CustomerMenu(registeredCustomers, loggedInCustomerId);
            this.Visibility = Visibility.Hidden;
            objCustomerMenu.Show();
        }

        private void LoadDataGrid()
        {
            try
            {
                Con.Open();

                // Pobiera wszystkie samochody dostępne do wynajęcia
                string availableCarsQuery = "SELECT * FROM SportCars";
                SqlDataAdapter availableCarsAdapter = new SqlDataAdapter(availableCarsQuery, Con);
                DataTable availableCarsDt = new DataTable();
                availableCarsAdapter.Fill(availableCarsDt);

                // Pobiera rezerwacje danego klienta
                string customerRentalsQuery = "SELECT * FROM RentalCar WHERE ID_Customer = @CustomerId";
                SqlDataAdapter customerRentalsAdapter = new SqlDataAdapter(customerRentalsQuery, Con);
                customerRentalsAdapter.SelectCommand.Parameters.AddWithValue("@CustomerId", loggedInCustomerId);
                DataTable customerRentalsDt = new DataTable();
                customerRentalsAdapter.Fill(customerRentalsDt);

                // Wyświetla dostępne samochody i rezerwacje klienta w odpowiednich DataGrids
                RentalDGV.ItemsSource = availableCarsDt.DefaultView;
                YourRental.ItemsSource = customerRentalsDt.DefaultView;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                Con.Close();
            }
        }

        /// <summary>
        /// Wynajem auta
        /// </summary>
        private void Button_Add3(object sender, RoutedEventArgs e)
        {
            if (selectedRow == null || RentalDate.SelectedDate == null || DateOfReturn.SelectedDate == null)
            {
                MessageBox.Show("Missing information");
            }
            else
            {
                try
                {
                    string query = "INSERT INTO RentalCar (RentalDate, DateOfReturn, ID_Customer, ID_SportCar) VALUES (@RentalDate, @DateOfReturn, @ID_Customer, @ID_SportCar)";
                    using (SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\piotr\Desktop\GITHUB\ProjektSemestralnyPO\ProjectCarRentalPH\ProjectCarRentalPH\Database.mdf;Integrated Security=True"))
                    {
                        con.Open();

                        int sportCarId = Convert.ToInt32(selectedRow["ID_SportCar"]);
                        int customerId = loggedInCustomerId;

                        if (customerId != 0)
                        {
                            using (SqlCommand cmdInsert = new SqlCommand(query, con))
                            {
                                cmdInsert.Parameters.AddWithValue("@RentalDate", RentalDate.SelectedDate.Value);
                                cmdInsert.Parameters.AddWithValue("@DateOfReturn", DateOfReturn.SelectedDate.Value);
                                cmdInsert.Parameters.AddWithValue("@ID_Customer", customerId);
                                cmdInsert.Parameters.AddWithValue("@ID_SportCar", sportCarId);

                                cmdInsert.ExecuteNonQuery();
                                MessageBox.Show("Car rented. Have a nice ride :) ");

                                // Odśwież DataGrid z rezerwacjami klienta
                                RefreshCustomerRentalsDataGrid();
                            }
                        }
                        else
                        {
                            MessageBox.Show("Failed to insert customer record. Please try again.");
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                    //MessageBox.Show(ex.Message);
                }
            }
        }

        private void RefreshCustomerRentalsDataGrid()
        {
            try
            {
                Con.Open();

                // Pobiera rezerwacje danego klienta
                string customerRentalsQuery = "SELECT * FROM RentalCar WHERE ID_Customer = @CustomerId";
                SqlDataAdapter customerRentalsAdapter = new SqlDataAdapter(customerRentalsQuery, Con);
                customerRentalsAdapter.SelectCommand.Parameters.AddWithValue("@CustomerId", loggedInCustomerId);
                DataTable customerRentalsDt = new DataTable();
                customerRentalsAdapter.Fill(customerRentalsDt);

                // Wyświetla rezerwacje klienta w DataGrid
                YourRental.ItemsSource = customerRentalsDt.DefaultView;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                Con.Close();
            }
        }


        private void Window_Closed(object sender, EventArgs e)
        {
            Con.Close();
        }

        private void Car_Load(object sender, RoutedEventArgs e)
        {
            LoadDataGrid();
        }   

        /// <summary>
        /// Umożliwia przesuwanie konsoli poprzez nacisnięcie lewego przycisku myszki
        /// </summary>
        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                DragMove();
            }
        }

        /// <summary>
        /// Anulowanie wynajmu auta
        /// </summary>

        private void Button_Delete3(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(ID_SportCar.Text))
            {
                MessageBox.Show("Please enter the SportCar ID to delete.");
                return;
            }

            int sportCarId;
            if (!int.TryParse(ID_SportCar.Text, out sportCarId))
            {
                MessageBox.Show("Invalid SportCar ID. Please enter a valid ID.");
                return;
            }

            try
            {
                string query = "DELETE FROM RentalCar WHERE ID_SportCar = @SportCarId AND ID_Customer = @CustomerId";
                using (SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\piotr\Desktop\GITHUB\ProjektSemestralnyPO\ProjectCarRentalPH\ProjectCarRentalPH\Database.mdf;Integrated Security=True"))
                {
                    con.Open();

                    using (SqlCommand cmdDelete = new SqlCommand(query, con))
                    {
                        cmdDelete.Parameters.AddWithValue("@SportCarId", sportCarId);
                        cmdDelete.Parameters.AddWithValue("@CustomerId", loggedInCustomerId);
                        int rowsAffected = cmdDelete.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Car rental deleted successfully");
                        }
                        else
                        {
                            MessageBox.Show("Failed to delete car rental. Please make sure you are deleting your own rental.");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
            finally
            {
                RefreshCustomerRentalsDataGrid();
            }
        }

        private void RentalDGV_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (RentalDGV.SelectedItem != null)
            {
                selectedRow = RentalDGV.SelectedItem as DataRowView;
            }
        }

        /// <summary>
        /// Przycisk INFO - pomaga użytkownikowi
        /// </summary>
        private void INFO(object sender, RoutedEventArgs e)
        {
            string message = "Aby zarezerwować auto należy kliknąć w wybrane auto w tabeli, podać datę wynajmu, datę zwrotu i kliknąć w przycisk ADD.\n"
                             + "Natomiast aby zrezygnować z wynajmu auta należy podać tylko ID tego samochodu i kliknąć w przycisk DELETE.";

            MessageBox.Show(message, "Informacja");
        }

        private void YourRental_SelectionChanged(object sender, SelectionChangedEventArgs e) { }
        #endregion
 
    }
}
