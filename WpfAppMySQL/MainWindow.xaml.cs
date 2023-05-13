using System;
using System.Collections.Generic;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using MySqlConnector;
using MySqlConnector.Authentication;

namespace WpfAppMySQL
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<Gyarto> gyartok = new List<Gyarto>();
        public MainWindow()
        {
            InitializeComponent();
        }

        // SELECT gyártó, COUNT(*) as darabSzám,  MAX(ár) as maxÁr, AVG(ár) as Átlag FROM termékek"  WHERE  kategória = '{txtKategoria.Text}' GROUP BY  Gyártó;";

        private void btnBetolt_Click(object sender, RoutedEventArgs e)
        {


            MySqlConnection SQLkapcsolat = new MySqlConnection("datasource=127.0.0.1;port=3306;database=hardver;username=root;password=;");

            SQLkapcsolat.Open();

            string SQLselect = "SELECT gyártó," +
                "COUNT(*) as darabSzám, " +
                "MAX(ár) as maxÁr, " +
                "AVG(ár) as Átlag FROM termékek" +
                $" WHERE  kategória = '{txtKategoria.Text}'" +
                "GROUP BY  Gyártó;";
                ;

            MySqlCommand SQLparancs = new MySqlCommand(SQLselect, SQLkapcsolat);

            MySqlDataReader eredmenyOlvaso = SQLparancs.ExecuteReader();

            while (eredmenyOlvaso.Read())
            {
                Gyarto ujsor = new Gyarto(eredmenyOlvaso.GetString("Gyártó"),
                    eredmenyOlvaso.GetInt32("darabSzám"),
                    eredmenyOlvaso.GetInt32("maxÁr"),
                    eredmenyOlvaso.GetDouble("Átlag")
                    );
gyartok.Add(ujsor);
            }
            eredmenyOlvaso.Close();
            SQLkapcsolat.Close();
            dgRekordok.ItemsSource = gyartok;
        }
        
    }
}
