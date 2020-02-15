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
using System.Windows.Shapes;

namespace QLTro
{
    /// <summary>
    /// Interaction logic for InsertRoom.xaml
    /// </summary>
    public partial class InsertRoom : Window
    {
        DataGrid data;
        List<RoomCategory> listroomcategory;
        public InsertRoom(DataGrid dt, List<RoomCategory> list)
        {
            data = dt;
            listroomcategory = list;
            this.WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
            InitializeComponent();
        }

        private void btinsert_Click(object sender, RoutedEventArgs e)
        {
            using (var db = new RoomManagerEntities2())
            {
                try
                {
                    var newitem = new Room()
                    {
                        Name = tbsophong.Text,
                        IdCategory = GetMaLoaiComBoBox(),
                        Status = Classify_Status(),
                    };
                    db.Rooms.Add(newitem);
                    db.SaveChanges();
                    data.ItemsSource = db.Rooms.ToList();
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            tbsophong.Text = "";
            rbttrong.IsChecked = true;
            MessageBox.Show("Them Phong Thanh Cong");
        }

        private void btcancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            LoadComBoBox();
        }
        private void LoadComBoBox()
        {
            foreach (var item in listroomcategory)
            {
                cbbRctgr.Items.Add(item.Name);
            }
        }
        private int Classify_Status()
        {
            if (rbttrong.IsChecked == true)
            {
                return 1;
            }
            else if (rbtdaconguoithue.IsChecked == true)
            {
                return 2;
            }
            else
            {
                return 3;
            }
        }
        private int GetMaLoaiComBoBox()
        {
            foreach (var it in listroomcategory)
            {
                if (it.Name == cbbRctgr.SelectedItem.ToString())
                {
                    return it.Id;
                }
            }
            return 0;
        }
    }
}
