using System;
using System.Collections.Generic;
using System.Data.Entity;
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
    /// Interaction logic for UsedServicesInfoWindow.xaml
    /// </summary>
    public partial class UsedServicesInfoWindow : Window
    {
        public const int INFOACTION = 0;
        public const int EDITACTION = 1;
        public const int ADDACTION = 2;
        public int type = INFOACTION;
        public int rentRoomID;
        public UsedService UsedServices;
        public UsedService bindingUsedServices = new UsedService();
        public UsedServicesInfoWindow(int Type, UsedService sv = null, int rentRoomID = -1)
        {
            this.WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
            InitializeComponent();
            this.type = Type;
            this.rentRoomID = rentRoomID;
            if (sv != null)
            {
                
                this.UsedServices = sv;
            }
            else
            {
                this.UsedServices = new UsedService();
            }

            this.DataContext = this.bindingUsedServices;
            if (type == EDITACTION)
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
        private void spUsedServicesInfo_Loaded(object sender, RoutedEventArgs e)
        {

        }
        public string catchErrorValidate()
        {
            var errorMessage = "";
            if (Validation.GetHasError(tbxID) == true)
            {

                foreach (ValidationError error in Validation.GetErrors(tbxID))
                {
                    errorMessage += error.ErrorContent + ", ";
                }

            }
            if (Validation.GetHasError(tbxRentRoomID) == true)
            {

                foreach (ValidationError error in Validation.GetErrors(tbxRentRoomID))
                {
                    errorMessage += error.ErrorContent + ", ";
                }

            }
           
            if (Validation.GetHasError(tbxStatus) == true)
            {

                foreach (ValidationError error in Validation.GetErrors(tbxStatus))
                {
                    errorMessage += error.ErrorContent + ", ";
                }

            }



            return errorMessage;
        }
        public UsedService getDataFromForm()
        {
            UsedService result = new UsedService();

            //result.id = 0;// int.Parse( tbxID.Text);
            result.rentRoomID = int.Parse(tbxRentRoomID.Text);
           
            result.status = int.Parse(tbxStatus.Text);
            result.date = dpDate.SelectedDate.Value;
            return result;
        }
        public void setDataToForm(UsedService UsedServices)
        {
            tbxID.Text = UsedServices.id.ToString();
            tbxRentRoomID.Text = UsedServices.rentRoomID.ToString();
            
            tbxStatus.Text = UsedServices.status.ToString();
            var dateString = UsedServices.date.ToString();
            dpDate.SelectedDate = UsedServices.date;


        }

        public UsedService getUsedServicesFromData(int id)
        {
            using (var db = new RoomManagerEntities2())
            {
                return db.UsedServices.SingleOrDefault(b => b.id == UsedServices.id);
            }
        }
        public void switchToAddAction()
        {
            type = ADDACTION;
            lbTitle.Content = "Add Used Services";
            spUsedServicesAE.Visibility = Visibility.Visible;
            spUsedServicesInfo.Visibility = Visibility.Collapsed;
            btnSaveUsedServices.Visibility = Visibility.Collapsed;

            //data
            //tbxDate = new DatePicker();
            if (rentRoomID != -1)
            {
                tbxRentRoomID.Text = rentRoomID.ToString();
            }
            dpDate.SelectedDate = DateTime.Now;
        }
        public void switchToInfoAction()
        {
            type = INFOACTION;
            lbTitle.Content = "Info Used Services";
            spUsedServicesInfo.Visibility = Visibility.Visible;
            spUsedServicesAE.Visibility = Visibility.Collapsed;

            //data
            if (type == INFOACTION)
            {
                UsedServices = getUsedServicesFromData(UsedServices.id);
                tbID.Text = UsedServices.id.ToString();
                tbRentRoomID.Text = UsedServices.rentRoomID.ToString();
               
                tbStatus.Text = UsedServices.status.ToString();
                tbDate.Text = UsedServices.date.ToString();
                
                LoadUSDDetailsData(currentUSDDetailsPage);
            }
           
        }
        public void switchToEditAction()
        {
            type = EDITACTION;
            lbTitle.Content = "Edit Used Services";
            spUsedServicesAE.Visibility = Visibility.Visible;
            spUsedServicesInfo.Visibility = Visibility.Collapsed;
            btnAddUsedServices.Visibility = Visibility.Collapsed;

            //data
            setDataToForm(UsedServices);
        }
        private void btnEditUsedServices_Click(object sender, RoutedEventArgs e)
        {
            switchToEditAction();
        }

        private void btnDeleteUsedServices_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                using (var db = new RoomManagerEntities2())
                {
                    this.IsEnabled = false;
                    var screen = new ConfirmWindow($"Ban Co Chac Muon Xoa Used Services {UsedServices.id}");
                    screen.ShowDialog();
                    if (screen.DialogResult == true)
                    {
                        var deleteItem = new UsedService() { id = UsedServices.id };
                        var deleteDetailItem = new USDDetail() { usID = UsedServices.id };
                        db.Entry(deleteDetailItem).State = EntityState.Modified;
                        db.USDDetails.Attach(deleteDetailItem);
                        db.USDDetails.Remove(deleteDetailItem);
                        db.SaveChanges();
                        switchToInfoAction();
                        //db.UsedServices.Attach(deleteItem);
                        //db.UsedServices.Remove(deleteItem);


                        //db.SaveChanges();
                        //this.Close();
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



        private void btnSaveUsedServices_Click(object sender, RoutedEventArgs e)
        {
            var errorMessage = catchErrorValidate();
            if (errorMessage != "")
            {
                tbErrorMessage.Text = errorMessage;
                return;
            }
            var editedItem = getDataFromForm();
            editedItem.id = UsedServices.id;
            using (var db = new RoomManagerEntities2())
            {
                this.IsEnabled = false;
                var creen = new ConfirmWindow($"Ban Co Chac Muon Edit Used Services {editedItem.id}");
                creen.ShowDialog();
                if (creen.DialogResult == true)
                {
                    var result = db.UsedServices.SingleOrDefault(b => b.id == editedItem.id);
                    if (result != null)
                    {
                        try
                        {
                            result.rentRoomID = editedItem.rentRoomID;
                            
                            result.status = editedItem.status;
                            result.date = editedItem.date;
                            db.SaveChanges();
                            // save ok
                            //if (editedItem.rentRoomID != this.UsedServices.rentRoomID)
                            //{
                            //    var editedRoom = db.Rooms.SingleOrDefault(b => b.Id == editedItem.rentRoomID);
                            //    editedRoom.Status = 2;
                            //    var oldRoom = db.Rooms.SingleOrDefault(b => b.Id == this.UsedServices.rentRoomID);
                            //    oldRoom.Status = 1;

                            //    db.SaveChanges();
                            //}
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

        private void btnAddUsedServices_Click(object sender, RoutedEventArgs e)
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
                    db.UsedServices.Add(addItem);

                    db.SaveChanges();

                    //MessageBox.Show("Thêm Sản Phẩm Thành Công");
                    //var rentedRoom = db.Rooms.SingleOrDefault(b => b.Id == addItem.rentRoomID);
                    //rentedRoom.Status = 2;
                    //db.SaveChanges();
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

        private void btnCancelUsedServices_Click(object sender, RoutedEventArgs e)
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

        //used services info detail
        private void dgUSDDetails_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            USDDetail ud = dgUSDDetails.SelectedItem as USDDetail;
            if (ud != null)
            {
                var screen = new USDDetailWindow(USDDetailWindow.INFOACTION,ud );
                this.IsEnabled = false;
                screen.ShowDialog();

                this.IsEnabled = true;
            }
            switchToInfoAction();

        }
        public List<USDDetail> USDDetailList = null;
        public int currentUSDDetailsPage = 1;
        public void LoadUSDDetailsData(int page = 1)
        {
            using(var db = new RoomManagerEntities2()) { 
            
            db.UsedServices.Attach(UsedServices);

            db.Entry(UsedServices).Collection(s => s.USDDetails).Load();
            USDDetailList = UsedServices.USDDetails.ToList();
            
            //Load Datagrid
            dgUSDDetails.ItemsSource = USDDetailList.Skip((page - 1) * 10).Take(10);
            tbTotalPageUSDDetails.Text = (USDDetailList.Count() % 10 != 0 ? USDDetailList.Count() / 10 + 1 : USDDetailList.Count() / 10).ToString();
            tbxCurrentPageUSDDetails.Text = currentUSDDetailsPage.ToString();}
        }
        private void tbxCurrentPageUSDDetails_KeyDown(object sender, KeyEventArgs e)
        {
            {
                if (e.Key == Key.Enter)
                {
                    MessageBox.Show(tbxCurrentPageUSDDetails.Text);
                    currentUSDDetailsPage = int.Parse(tbxCurrentPageUSDDetails.Text);
                    LoadUSDDetailsData(currentUSDDetailsPage);
                }
            }
        }

        private void btnPreviousPageUSDDetails_Click(object sender, RoutedEventArgs e)
        {
            if (currentUSDDetailsPage > 1)
            {
                currentUSDDetailsPage--;
                LoadUSDDetailsData(currentUSDDetailsPage);
            }

        }

        private void btnNextPageUSDDetails_Click(object sender, RoutedEventArgs e)
        {
            var totalPage = int.Parse(tbTotalPageUSDDetails.Text);
            if (currentUSDDetailsPage < totalPage)
            {
                currentUSDDetailsPage++;
                LoadUSDDetailsData(currentUSDDetailsPage);
            }

        }

        private void btnAddDetails_Click(object sender, RoutedEventArgs e)
        {
            var screen = new USDDetailWindow(USDDetailWindow.ADDACTION,null,UsedServices.id);
            this.IsEnabled = false;
            screen.ShowDialog();
            switchToInfoAction();
            this.IsEnabled = true;
        }
    }
}
