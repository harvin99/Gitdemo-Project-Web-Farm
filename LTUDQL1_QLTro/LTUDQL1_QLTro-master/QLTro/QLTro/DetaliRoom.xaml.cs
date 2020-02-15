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
    /// Interaction logic for DetaliRoom.xaml
    /// </summary>
    public partial class DetaliRoom : Window
    {
        Room item;
        List<RoomCategory> listroomcategory;
        public DetaliRoom(Room room, List<RoomCategory> list)
        {
            listroomcategory = list;
            item = room;
            this.WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
            InitializeComponent();
        }

        private void btapply_Click(object sender, RoutedEventArgs e)
        {
            this.IsEnabled = false;
            var creen = new ConfirmWindow($"Ban Co Chac Muon Edit Loai Phong");
            creen.ShowDialog();
            if (creen.DialogResult == true)
            {
                using (var database = new RoomManagerEntities2())
                {
                    var victim = database.Rooms.Find(item.Id);
                    victim.Name = tbsophong.Text;
                    victim.IdCategory = GetMaLoaiComBoBox();
                    victim.Status = Classify_Status();
                    database.SaveChanges();
                }
                stackpennalshow.Height = stackpennaledit.Height;
                stackpennaledit.Height = 0;
                btedit.Content = "Edit";
                btapply.IsEnabled = false;
            }
            this.IsEnabled = true;
        }

        private void btedit_Click(object sender, RoutedEventArgs e)
        {
            if (btedit.Content.ToString() == "Edit")
            {
                stackpennaledit.Height = stackpennalshow.Height;
                stackpennalshow.Height = 0;
                btedit.Content = "Show";
                btapply.IsEnabled = true;

                windowedit();
            }
            else
            {
                stackpennalshow.Height = stackpennaledit.Height;
                stackpennaledit.Height = 0;
                btedit.Content = "Edit";
                btapply.IsEnabled = false;
                //it.OperEqual(item);
            }
        }

        private void btdelete_Click(object sender, RoutedEventArgs e)
        {
            this.IsEnabled = false;
            var creen = new ConfirmWindow($"Ban Co Chac Muon Delete Room");
            creen.ShowDialog();
            if (creen.DialogResult == true)
            {
                using (var db = new RoomManagerEntities2())
                {
                    var victim = db.Rooms.Find(item.Id);
                    db.Rooms.Remove(victim);
                    db.SaveChanges();
                }   
                this.Close();
            }
            this.IsEnabled = true;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            LoadComBoBox();
            //NameCategoryConverter.LoadRoomCategory(list_roomcategory);
            stackpennalshow.DataContext = item;
        }
        private void windowedit()
        {
            for (int i = 0; i < cbbRctgr.Items.Count; i++)
            {
                string value = cbbRctgr.Items[i].ToString();
                if (value == item.TenLoai(listroomcategory))
                    cbbRctgr.SelectedIndex = i;
            }
            
            tbsophong.Text = item.Name;
            if (tbstatus.Text == "Trống")
            {
                rbttrong.IsChecked = true;
            }
            else if (tbstatus.Text == "Đã Có Người Thuê")
            {
                rbtdaconguoithue.IsChecked = true;
            }
            else
            {
                rbtsuachua.IsChecked = true;
            }
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

        private void btnRent_Click(object sender, RoutedEventArgs e)
        {
            using (var db = new RoomManagerEntities2())
            {
                this.IsEnabled = false;
                var creen = new ConfirmWindow($"Ban Co Chac Muon  Rent Room {item.Id}");
                creen.ShowDialog();
                if (creen.DialogResult == true)
                {
                    var result = db.Rooms.SingleOrDefault(b => b.Id == item.Id && b.Status == 1);
                    if (result != null)
                    {
                        this.IsEnabled = false;

                        var Rentscreen = new RentRoomInfoWindow(RentRoomInfoWindow.ADDACTION, null, result.Id);
                        this.IsEnabled = false;


                        if (Rentscreen.ShowDialog() == true)
                        {
                            MessageBox.Show(" Rent Room Successfull");
                        }
                        else
                        {
                            MessageBox.Show(" Rent Room Fail");
                        }
                        this.IsEnabled = true;
                    }
                    else
                    {
                        MessageBox.Show(" not room available");
                    }



                }
                this.IsEnabled = true;
            }
        }
    }
}
