using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.SqlClient;
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
    /// Interaction logic for RentRoomInfoWindow.xaml
    /// </summary>
    public partial class RentRoomInfoWindow : Window
    {
        public const int INFOACTION = 0;
        public const int EDITACTION = 1;
        public const int ADDACTION = 2;
        public int type = INFOACTION;
        public int roomID;
        public RentRoom rentRoom;
        public RentRoom bindingRentRoom = new RentRoom();
        public RentRoomInfoWindow(int Type,RentRoom RR = null,int roomID =-1)
        {
            this.WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
            InitializeComponent();
            this.type = Type;
            this.roomID = roomID;
            if (RR != null)
            {
                this.rentRoom = RR;
            }
            else
            {
                this.rentRoom = new RentRoom();
            }
           
            this.DataContext = this.bindingRentRoom;
            if (type ==EDITACTION)
            {
                switchToEditAction();
            }
            else if (type == ADDACTION)
            {
                switchToAddAction();
            }
            else
            {
                switchToInfoAction();
            }
            //this.DialogResult = false;
        }
        private void spRentRoomInfo_Loaded(object sender, RoutedEventArgs e)
        {

        }
        public string catchErrorValidate()
        {
            var errorMessage = "";
            if (Validation.GetHasError(tbxID) == true)
            {

                foreach (ValidationError error in Validation.GetErrors(tbxID))
                {
                    errorMessage += error.ErrorContent +", ";
                }

            }
            if (Validation.GetHasError(tbxRoomID) == true)
            {

                foreach (ValidationError error in Validation.GetErrors(tbxRoomID))
                {
                    errorMessage += error.ErrorContent + ", ";
                }

            }
            if (Validation.GetHasError(tbxRenterName) == true)
            {

                foreach (ValidationError error in Validation.GetErrors(tbxRenterName))
                {
                    errorMessage += error.ErrorContent + ", ";
                }

            }
            if (Validation.GetHasError(tbxTel) == true)
            {

                foreach (ValidationError error in Validation.GetErrors(tbxTel))
                {
                    errorMessage += error.ErrorContent + ", ";
                }

            }
            if (Validation.GetHasError(tbxPrice) == true)
            {

                foreach (ValidationError error in Validation.GetErrors(tbxPrice))
                {
                    errorMessage += error.ErrorContent + ", ";
                }

            }
            


            return errorMessage;
        }
        public RentRoom getDataFromForm()
        {
            RentRoom result = new RentRoom();
            
            //result.id = 0;// int.Parse( tbxID.Text);
            result.roomID = int.Parse(tbxRoomID.Text);
            result.renterName = tbxRenterName.Text;
            result.tel = tbxTel.Text;
            result.price = float.Parse(tbxPrice.Text);
            result.date = dpDate.SelectedDate.Value;
            return result;
        }
        public void setDataToForm(RentRoom rentRoom) {
            tbxID.Text = rentRoom.id.ToString();
            tbxRoomID.Text = rentRoom.roomID.ToString();
            tbxRenterName.Text = rentRoom.renterName;
            tbxTel.Text = rentRoom.tel;
            tbxPrice.Text = rentRoom.price.ToString();
            var dateString = rentRoom.date.ToString();
            dpDate.SelectedDate = rentRoom.date;


        }

        public RentRoom getRentRoomFromData(int id)
        {
            using (var db = new RoomManagerEntities2())
            {
                return db.RentRooms.SingleOrDefault(b => b.id == rentRoom.id);
            }
        }
        public void switchToAddAction()
        {
            type = ADDACTION;
            lbTitle.Content = "Add Rent Room";
            spRentRoomAE.Visibility = Visibility.Visible;
            spRentRoomInfo.Visibility = Visibility.Collapsed;
            btnSaveRentRoom.Visibility = Visibility.Collapsed;

            //data
            //tbxDate = new DatePicker();
            if (roomID != -1)
            {
                tbxRoomID.Text = roomID.ToString();
            }
            dpDate.SelectedDate = DateTime.Now;
        }
        public void switchToInfoAction()
        {
            type = INFOACTION;
            lbTitle.Content = "Info Rent Room";
            spRentRoomInfo.Visibility = Visibility.Visible;
            spRentRoomAE.Visibility = Visibility.Collapsed;

            //data
            if (type == INFOACTION)
            {
                rentRoom = getRentRoomFromData(rentRoom.id);
                tbID.Text = rentRoom.id.ToString();
                tbRoomID.Text = rentRoom.roomID.ToString();
                tbRenterName.Text = rentRoom.renterName;
                tbTel.Text = rentRoom.tel;
                tbPrice.Text = rentRoom.price.ToString();
                tbDate.Text = rentRoom.date.ToString();
            }
        }
        public void switchToEditAction()
        {
            type = EDITACTION;
            lbTitle.Content = "Edit Rent Room";
            spRentRoomAE.Visibility = Visibility.Visible;
            spRentRoomInfo.Visibility = Visibility.Collapsed;
            btnAddRentRoom.Visibility = Visibility.Collapsed;

            //data
            setDataToForm(rentRoom);
        }
        private void btnEditRentRoom_Click(object sender, RoutedEventArgs e)
        {
            switchToEditAction();
        }

        private void btnDeleteRentRoom_Click(object sender, RoutedEventArgs e)
           
        {
            try
            {
                using (var db = new RoomManagerEntities2())
                {
                
                    this.IsEnabled = false;
                    var screen = new ConfirmWindow($"Ban Co Chac Muon Xoa Rent Room {rentRoom.id}");
                    screen.ShowDialog();
                    if (screen.DialogResult == true)
                    {
                        var deleteItem = new RentRoom() { id = rentRoom.id };
                        db.RentRooms.Attach(deleteItem);
                        db.RentRooms.Remove(deleteItem);
                        db.SaveChanges();
                        var oldRoom = db.Rooms.SingleOrDefault(b => b.Id == this.rentRoom.roomID);
                        oldRoom.Status = 1;

                        db.SaveChanges();
                        this.Close();
                    }
                    this.IsEnabled = true;
               
            }
                 }
                catch (Exception ex)
            {
                this.IsEnabled = true;
                MessageBox.Show("delete failure");
                switchToInfoAction();
            }


        }

        

        private void btnSaveRentRoom_Click(object sender, RoutedEventArgs e)
        {
            var errorMessage = catchErrorValidate();
            if (errorMessage!= "")
            {
                tbErrorMessage.Text = errorMessage;
                return;
            }
            var editedItem = getDataFromForm();
            editedItem.id = rentRoom.id;
            using (var db = new RoomManagerEntities2())
            {
                this.IsEnabled = false;
                var creen = new ConfirmWindow($"Ban Co Chac Muon Edit Rent Room {editedItem.id}");
                creen.ShowDialog();
                if (creen.DialogResult == true)
                {
                    var result = db.RentRooms.SingleOrDefault(b => b.id == editedItem.id);
                    if (result != null)
                    {
                        try
                        {
                            result.roomID = editedItem.roomID;
                            result.renterName = editedItem.renterName;
                            result.tel = editedItem.tel;
                            result.price = editedItem.price;
                            result.date = editedItem.date;
                            db.SaveChanges();
                            // save ok
                            if (editedItem.roomID != this.rentRoom.roomID)
                            {
                                var editedRoom = db.Rooms.SingleOrDefault(b => b.Id == editedItem.roomID);
                                editedRoom.Status = 2;
                                var oldRoom = db.Rooms.SingleOrDefault(b => b.Id == this.rentRoom.roomID);
                                oldRoom.Status = 1;

                                db.SaveChanges();
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }
                    }
                }
                this.IsEnabled = true;
            }
            //complete action
            switchToInfoAction();
        }

        private void btnAddRentRoom_Click(object sender, RoutedEventArgs e)
        {
            var errorMessage = catchErrorValidate();
            if (errorMessage != "")
            {
                tbErrorMessage.Text = errorMessage;
                return;
            }
            var addItem = getDataFromForm();
            using (var db = new RoomManagerEntities2())
            {
                try
                {
                    db.RentRooms.Add(addItem);

                    db.SaveChanges();

                    //MessageBox.Show("Thêm Sản Phẩm Thành Công");
                    var rentedRoom =db.Rooms.SingleOrDefault(b => b.Id == addItem.roomID);
                    rentedRoom.Status = 2;
                    db.SaveChanges(); 
                    this.DialogResult = true;
                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message);
                }
                
            }
            //complete action
            Close();
        }

        private void btnCancelRentRoom_Click(object sender, RoutedEventArgs e)
        {

            //complete action
            if (type == EDITACTION)
            {
                //MessageBox.Show(this.DialogResult.ToString());
                switchToInfoAction();
            }
            else
            {
                this.Close();
            }
            
           
        }

        private void dpDate_Loaded(object sender, RoutedEventArgs e)
        {
           
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            e.Cancel = false;
        }

        private void btnCheckOutRentRoom_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                using (var db = new RoomManagerEntities2())
                {

                    this.IsEnabled = false;
                    var screen = new ConfirmWindow($"Ban Co Chac Muon Xoa Rent Room {rentRoom.id}");
                    screen.ShowDialog();
                    if (screen.DialogResult == true)
                    {
                        var checkOutWindow = new CheckOutWindow(rentRoom);
                        checkOutWindow.ShowDialog();
                    }
                    this.IsEnabled = true;

                }
            }
            catch (Exception ex)
            {
                this.IsEnabled = true;
                //MessageBox.Show("delete failure");
                switchToInfoAction();
            }
        }
    }
}
