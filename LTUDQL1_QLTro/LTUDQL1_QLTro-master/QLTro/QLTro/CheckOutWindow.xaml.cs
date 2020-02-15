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
    /// Interaction logic for CheckOutWindow.xaml
    /// </summary>
    public partial class CheckOutWindow : Window
    {
        public RentRoom rentRoom = null;
        public List<USDDetail> UsDetailList = null;
        public CheckOutWindow(RentRoom rr)
        {
            InitializeComponent();
            rentRoom = rr;
        }
        public RentRoom getRentRoomFromData(int id)
        {
            using (var db = new RoomManagerEntities2())
            {
                return db.RentRooms.SingleOrDefault(b => b.id == rentRoom.id);
            }
        }
        public List<USDDetail> getUSDDetailFromData()
        {
            using (var db = new RoomManagerEntities2())
            {

                db.RentRooms.Attach(rentRoom);

                db.Entry(rentRoom).Collection(s => s.UsedServices).Load();
                var us = rentRoom.UsedServices.Where(i=>i.status ==0).ToList();
                if (us.Count>0)
                {
                    return us[0].USDDetails.ToList();
                }
                return null;

            }
        }
        public void LoadData()
        {
            rentRoom = getRentRoomFromData(rentRoom.id);
            tbID.Text = rentRoom.id.ToString();
            tbRoomID.Text = rentRoom.roomID.ToString();
            tbRenterName.Text = rentRoom.renterName;
            tbTel.Text = rentRoom.tel;
            tbPrice.Text = rentRoom.price.ToString();
            tbDate.Text = rentRoom.date.ToString();
            UsDetailList= getUSDDetailFromData();
            dgUSDDetails.ItemsSource = UsDetailList;
            var priceUsDetail = UsDetailList.Select(i => i.price).DefaultIfEmpty(0).Sum();
            tbTotalPrice.Text = (priceUsDetail + rentRoom.price).ToString()+" USD";
        }
        private void btnCheckOutRentRoom_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                using (var db = new RoomManagerEntities2())
                {
                    var us = db.UsedServices.SingleOrDefault(i => i.rentRoomID == rentRoom.id && i.status == 0);
                    us.status = 1;
                    db.SaveChanges();
                    var rr = db.Rooms.SingleOrDefault(i => i.Id == rentRoom.roomID);
                    rr.Status = 1;
                    db.SaveChanges();
                    this.Close();
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void spRentRoomInfo_Loaded(object sender, RoutedEventArgs e)
        {
            LoadData();
        }
    }
}
