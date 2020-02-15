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
    /// Interaction logic for ServicesInfoWindow.xaml
    /// </summary>
    public partial class ServicesInfoWindow : Window
    {
        public const int INFOACTION = 0;
        public const int EDITACTION = 1;
        public const int ADDACTION = 2;
        public int type = INFOACTION;
       
        public Service Services;
        public Service bindingServices = new Service();
        public ServicesInfoWindow(int Type, Service sv = null)
        {
            this.WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
            InitializeComponent();
            this.type = Type;
           
            if (sv != null)
            {
                this.Services = sv;
            }
            else
            {
                this.Services = new Service();
            }

            this.DataContext = this.bindingServices;
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
        private void spServicesInfo_Loaded(object sender, RoutedEventArgs e)
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
            
            if (Validation.GetHasError(tbxName) == true)
            {

                foreach (ValidationError error in Validation.GetErrors(tbxName))
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
        public Service getDataFromForm()
        {
            Service result = new Service();

            //result.id = 0;// int.Parse( tbxID.Text);
           
            result.name = tbxName.Text;
           
            result.price = float.Parse(tbxPrice.Text);
           
            return result;
        }
        public void setDataToForm(Service Services)
        {
            tbxID.Text = Services.id.ToString();
            
            tbxName.Text = Services.name;
            
            tbxPrice.Text = Services.price.ToString();
           


        }

        public Service getServicesFromData(int id)
        {
            using (var db = new RoomManagerEntities2())
            {
                return db.Services.SingleOrDefault(b => b.id == Services.id);
            }
        }
        public void switchToAddAction()
        {
            type = ADDACTION;
            lbTitle.Content = "Add Services";
            spServicesAE.Visibility = Visibility.Visible;
            spServicesInfo.Visibility = Visibility.Collapsed;
            btnSaveServices.Visibility = Visibility.Collapsed;

            //data
            //tbxDate = new DatePicker();
            
        }
        public void switchToInfoAction()
        {
            type = INFOACTION;
            lbTitle.Content = "Info Services";
            spServicesInfo.Visibility = Visibility.Visible;
            spServicesAE.Visibility = Visibility.Collapsed;

            //data
            if (type == INFOACTION)
            {
                Services = getServicesFromData(Services.id);
                tbID.Text = Services.id.ToString();
                
                tbName.Text = Services.name;
                
                tbPrice.Text = Services.price.ToString();
               
            }
        }
        public void switchToEditAction()
        {
            type = EDITACTION;
            lbTitle.Content = "Edit Services";
            spServicesAE.Visibility = Visibility.Visible;
            spServicesInfo.Visibility = Visibility.Collapsed;
            btnAddServices.Visibility = Visibility.Collapsed;

            //data
            setDataToForm(Services);
        }
        private void btnEditServices_Click(object sender, RoutedEventArgs e)
        {
            switchToEditAction();
        }

        private void btnDeleteServices_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                using (var db = new RoomManagerEntities2())
                {
                    this.IsEnabled = false;
                    var screen = new ConfirmWindow($"Ban Co Chac Muon Xoa Service {Services.id}");
                    screen.ShowDialog();
                    if (screen.DialogResult == true)
                    {
                        var deleteItem = new Service() { id = Services.id };
                        db.Services.Attach(deleteItem);
                        db.Services.Remove(deleteItem);
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



        private void btnSaveServices_Click(object sender, RoutedEventArgs e)
        {
            var errorMessage = catchErrorValidate();
            if (errorMessage != "")
            {
                tbErrorMessage.Text = errorMessage;
                return;
            }
            var editedItem = getDataFromForm();
            editedItem.id = Services.id;
            using (var db = new RoomManagerEntities2())
            {
                this.IsEnabled = false;
                var creen = new ConfirmWindow($"Ban Co Chac Muon Edit Service {editedItem.id}");
                creen.ShowDialog();
                if (creen.DialogResult == true)
                {
                    var result = db.Services.SingleOrDefault(b => b.id == editedItem.id);
                    if (result != null)
                    {
                        try
                        {
                            
                            result.name = editedItem.name;
                           
                            result.price = editedItem.price;
                            
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

        private void btnAddServices_Click(object sender, RoutedEventArgs e)
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
                    db.Services.Add(addItem);

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

        private void btnCancelServices_Click(object sender, RoutedEventArgs e)
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
