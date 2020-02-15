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
    /// Interaction logic for USDDetailWindow.xaml
    /// </summary>
    public partial class USDDetailWindow : Window
    {
        public const int INFOACTION = 0;
        public const int EDITACTION = 1;
        public const int ADDACTION = 2;
        public int type = INFOACTION;
        public int usID;
        public int sID;
        public USDDetail USDetail;
        public USDDetail bindingUSDetail = new USDDetail();
        public USDDetailWindow(int Type, USDDetail ud = null, int usID = -1, int sID =-1)
        {
            this.WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
            InitializeComponent();
            this.type = Type;
            this.usID = usID;
            this.sID = sID;
            if (ud != null)
            {
                this.USDetail = ud;
            }
            else
            {
                this.USDetail = new USDDetail();
            }

            this.DataContext = this.bindingUSDetail;
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
        private void spUSDDetailsInfo_Loaded(object sender, RoutedEventArgs e)
        {

        }
        public string catchErrorValidate()
        {
            var errorMessage = "";
            if (Validation.GetHasError(tbxUsID) == true)
            {

                foreach (ValidationError error in Validation.GetErrors(tbxUsID))
                {
                    errorMessage += error.ErrorContent + ", ";
                }

            }
            if (Validation.GetHasError(tbxSID) == true)
            {

                foreach (ValidationError error in Validation.GetErrors(tbxSID))
                {
                    errorMessage += error.ErrorContent + ", ";
                }

            }
            if (Validation.GetHasError(tbxTimes) == true)
            {

                foreach (ValidationError error in Validation.GetErrors(tbxTimes))
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
        public USDDetail getDataFromForm()
        {
            USDDetail result = new USDDetail();

            //result.id = ;// int.Parse( tbxID.Text);
            result.usID = int.Parse(tbxUsID.Text);
            result.sID = int.Parse(tbxSID.Text);
            result.times = int.Parse(tbxTimes.Text);

            result.price = float.Parse(tbxPrice.Text);
            result.date = dpDate.SelectedDate.Value;
            return result;
        }
        public void setDataToForm(USDDetail ud)
        {
            tbxUsID.Text = ud.usID.ToString();
            tbxSID.Text = ud.sID.ToString();
            tbxTimes.Text = ud.times.ToString();
            tbxPrice.Text = ud.price.ToString();
            //var dateString = ud.date.ToString();
            dpDate.SelectedDate = ud.date;


        }

        public USDDetail getUSDDetailFromData(int usID,int sID,int times)
        {
            using (var db = new RoomManagerEntities2())
            {
                return db.USDDetails.SingleOrDefault(b => (b.usID == usID && b.sID ==sID && b.times == times));
            }
        }
        public void switchToAddAction()
        {
            type = ADDACTION;
            lbTitle.Content = "Add USDetail";
            spUSDDetailsAE.Visibility = Visibility.Visible;
            spUSDDetailsInfo.Visibility = Visibility.Collapsed;
            btnSaveUSDDetails.Visibility = Visibility.Collapsed;
            
            
            

            //data
            //tbxDate = new DatePicker();
            if (usID != -1)
            {
                bindingUSDetail.usID = usID;

            }
            else
            {
                tbxUsID.IsReadOnly = false;
                tbxUsID.Background = Brushes.White;
            }
            if (sID != -1)
            {
                bindingUSDetail.sID = sID;

            }
            else
            {
                tbxSID.IsReadOnly = false;
                tbxSID.Background = Brushes.White;
            }
            dpDate.SelectedDate = DateTime.Now;
            
             
            
        }
        public void switchToInfoAction()
        {
            type = INFOACTION;
            lbTitle.Content = "Info USDetail";
            spUSDDetailsInfo.Visibility = Visibility.Visible;
            spUSDDetailsAE.Visibility = Visibility.Collapsed;

            //data
            if (type == INFOACTION)
            {
                USDDetail ud = getUSDDetailFromData(USDetail.usID,USDetail.sID,USDetail.times);
                tbUsID.Text = ud.usID.ToString();
                tbSID.Text = ud.sID.ToString();
                tbTimes.Text = ud.times.ToString();
                tbPrice.Text = ud.price.ToString();
                //var dateString = ud.date.ToString();
                tbDate.Text = ud.date.ToString() ;
            }
        }
        public void switchToEditAction()
        {
            type = EDITACTION;
            lbTitle.Content = "Edit USDetail";
            spUSDDetailsAE.Visibility = Visibility.Visible;
            spUSDDetailsInfo.Visibility = Visibility.Collapsed;
            btnAddUSDDetails.Visibility = Visibility.Collapsed;

            //data
            setDataToForm(USDetail);
        }
        private void btnEditUSDDetails_Click(object sender, RoutedEventArgs e)
        {
            switchToEditAction();
        }

        private void btnDeleteUSDDetails_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                using (var db = new RoomManagerEntities2())
                {
                    this.IsEnabled = false;
                    var screen = new ConfirmWindow($"Ban Co Chac Muon Xoa USDetail {USDetail.usID} {USDetail.sID} {USDetail.times}");
                    screen.ShowDialog();
                    if (screen.DialogResult == true)
                    {
                        var deleteItem = new USDDetail { usID = USDetail.usID, sID = USDetail.sID, times = USDetail.times };
                        db.USDDetails.Attach(deleteItem);
                        db.USDDetails.Remove(deleteItem);
                        db.SaveChanges();
                        //var oldRoom = db.Rooms.SingleOrDefault(b => b.Id == this.USDDetails.roomID);
                        //oldRoom.Status = 1;

                        //db.SaveChanges();
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



        private void btnSaveUSDDetails_Click(object sender, RoutedEventArgs e)
        {
            var errorMessage = catchErrorValidate();
            if (errorMessage != "")
            {
                tbErrorMessage.Text = errorMessage;
                return;
            }
            var editedItem = getDataFromForm();
            //editedItem.id = USDDetails.id;
            using (var db = new RoomManagerEntities2())
            {
                this.IsEnabled = false;
                var creen = new ConfirmWindow($"Ban Co Chac Muon Edit USDetail {editedItem.usID} {editedItem.sID} {editedItem.times}");
                creen.ShowDialog();
                if (creen.DialogResult == true)
                {
                    var result = db.USDDetails.SingleOrDefault(b => (b.usID == editedItem.usID && b.sID == editedItem.sID && b.times == editedItem.times));
                    if (result != null)
                    {
                        try
                        {
                            
                            result.price = editedItem.price;
                            result.date = editedItem.date;
                            db.SaveChanges();
                            // save ok
                 
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

        private void btnAddUSDDetails_Click(object sender, RoutedEventArgs e)
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
                // var a = db.USDDetails.Where(i => i.usID == USDetail.usID && i.sID == USDetail.sID);
                //var b = a.Select(p => p.times);
                //var c = b.DefaultIfEmpty(0);
                //var times = c.Max().FirstOrDefault();
                //MessageBox.Show(record.ToString());
                var lastTimes = db.USDDetails.Where(i => i.usID == addItem.usID && i.sID == addItem.sID).Select(x => x.times)
                         .DefaultIfEmpty(0)
                         .Max(); 
                var times = lastTimes + 1;
                
                addItem.times = times;
               
                try
                {
                    db.USDDetails.Add(addItem);

                    db.SaveChanges();

                    //MessageBox.Show("Thêm Sản Phẩm Thành Công");
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

        private void btnCancelUSDDetails_Click(object sender, RoutedEventArgs e)
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
    }
}
