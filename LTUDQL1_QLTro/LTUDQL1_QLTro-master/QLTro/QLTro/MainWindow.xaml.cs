using Aspose.Cells;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
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

namespace QLTro
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<RoomCategory> lsctgry;
        List<Room> lsr;
        List<ImagesRoomCategory> listimgcategory;
        List<RentRoom> RentRoomList = null;
        List<Service> ServiceList = null;
        List<UsedService> UsedServiceList = null;

        public MainWindow()
        {
            this.WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
            InitializeComponent();
        }

        private void btinsert_Click(object sender, RoutedEventArgs e)
        {
            this.IsEnabled = false;
            var ti = tabctrlRoom.SelectedItem as TabItem;
            if(ti.Header.ToString() == "Loại Phòng")
            {
                var creen = new InsertRoomCategory(loaiphongdatagrid);
                creen.ShowDialog();
            }
            else
            {
                var creen = new InsertRoom(phongdatagrid, lsctgry);
                creen.ShowDialog();
            }
            LoadDuLieu();
            this.IsEnabled = true;
        }

        private void btimprot_SP_Click(object sender, RoutedEventArgs e)
        {
            InprotExcel();
            LoadDuLieu();
        }
        private void DataGridRow_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            var ti = tabctrlRoom.SelectedItem as TabItem;
            if (ti.Header.ToString() == "Loại Phòng")
            {
                RoomCategory roomctgr = loaiphongdatagrid.SelectedItem as RoomCategory;
                if (roomctgr != null)
                {
                    var creen = new DetailRoomCategory(roomctgr);
                    this.IsEnabled = false;
                    creen.ShowDialog();
                    LoadDuLieu();
                    this.IsEnabled = true;
                }
            }
            else
            {
                Room room = phongdatagrid.SelectedItem as Room;
                if (room != null)
                {
                    var creen = new DetaliRoom(room, lsctgry);
                    this.IsEnabled = false;
                    creen.ShowDialog();
                    LoadDuLieu();
                    this.IsEnabled = true;
                }
            }
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            LoadDuLieu();
            
        }
        private void LoadDuLieu()
        {
            var db = new RoomManagerEntities2();
            lsctgry = db.RoomCategories.ToList();
            lsr = db.Rooms.ToList();
            listimgcategory = db.ImagesRoomCategories.ToList();
            loaiphongdatagrid.ItemsSource = lsctgry.ToList();
            phongdatagrid.ItemsSource = lsr.ToList();
            LoadRentRoomData(currentRentRoomPage);
            LoadServicesData(currentServicesPage);
            LoadUsedServicesData(currentUsedServicesPage);
        }

        private void btSave_Click(object sender, RoutedEventArgs e)
        {
            //db.SaveChanges();
        }
        private void InprotExcel()
        {
            
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if(openFileDialog.ShowDialog() == true)
            {
                var wookbook = new Workbook(openFileDialog.FileName);
                var tabs = wookbook.Worksheets;
                using (var db = new RoomManagerEntities2())
                {
                    foreach (var tab in tabs)
                    {
                        try
                        {
                            if (tab.Name == "Category")
                            {
                                var col = 'B';
                                var row = 2;
                                var cell = tab.Cells[$"{ col}{ row}"];
                                while (cell.Value != null)
                                {
                                    var name = tab.Cells[$"C{row}"].StringValue;
                                    var price = tab.Cells[$"D{row}"].FloatValue;
                                    var des = tab.Cells[$"E{row}"].StringValue;

                                    var newCategory = new RoomCategory()
                                    {
                                        Name = name,
                                        Price = price,
                                        Description = des
                                    };
                                    db.RoomCategories.Add(newCategory);

                                    db.SaveChanges();

                                    row++;
                                    cell = tab.Cells[$"{ col}{ row}"];
                                }

                            }
                            else if (tab.Name == "Image")
                            {
                                var col = 'B';
                                var row = 2;
                                var cell = tab.Cells[$"{ col}{ row}"];
                                while (cell.Value != null)
                                {
                                    var idcategory = tab.Cells[$"B{row}"].IntValue;
                                    var src = tab.Cells[$"C{row}"].StringValue;

                                    //lay duong dan cu Foder anh
                                    var srcImageInfo = new FileInfo(openFileDialog.FileName);
                                    var srcPath = $"{srcImageInfo.DirectoryName}\\Images\\{src}";
                                    var sourceImageInfo = new FileInfo(srcPath);

                                    //Tao ten duy nhat
                                    var uniqueName = $"{Guid.NewGuid()}{sourceImageInfo.Extension}";

                                    var basePath = AppDomain.CurrentDomain.BaseDirectory;
                                    var desPath = $"{basePath}Image_RoomCategory\\{uniqueName}";
                                    if (!File.Exists(desPath))
                                    {
                                        File.Copy(srcPath, desPath);
                                    }

                                    var newimg = new ImagesRoomCategory()
                                    {
                                        IdCategory = idcategory,
                                        Source = uniqueName,
                                    };

                                    db.ImagesRoomCategories.Add(newimg);

                                    db.SaveChanges();
                                    //await db.SaveChangesAsync();

                                    row++;
                                    cell = tab.Cells[$"{ col}{ row}"];
                                }
                            }
                            else if (tab.Name == "Room")
                            {
                                var col = 'B';
                                var row = 2;
                                var cell = tab.Cells[$"{ col}{ row}"];
                                while (cell.Value != null)
                                {
                                    var idcategory = tab.Cells[$"B{row}"].IntValue;
                                    var name = tab.Cells[$"C{row}"].StringValue;
                                    string str_status = tab.Cells[$"D{row}"].StringValue;
                                    int status;
                                    if (str_status == "Trống")
                                    {
                                        status = 1;
                                    }
                                    else if (str_status == "Đã Có Người Thuê")
                                    {
                                        status = 2;
                                    }
                                    else
                                    {
                                        status = 3;
                                    }

                                    var newimg = new Room()
                                    {
                                        IdCategory = idcategory,
                                        Name = name,
                                        Status = status
                                    };
                                    db.Rooms.Add(newimg);
                                    db.SaveChanges();
                                    row++;
                                    cell = tab.Cells[$"{ col}{ row}"];
                                }
                            }
                        }
                        catch(Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }        
                    }
                }    
            }
        }

        private void tbfiltername_TextChanged(object sender, TextChangedEventArgs e)
        {
            var keyword = tbfiltername.Text;
            var datacategory = from product in lsctgry
                               where product.Name.ToLower().AccentRemoved().Contains(keyword.ToLower())
                               select product;
            loaiphongdatagrid.ItemsSource = datacategory;
            var dataroom = from product in lsr
                           where product.Name.ToLower().AccentRemoved().Contains(keyword.ToLower())
                           select product;
            phongdatagrid.ItemsSource = dataroom;
        }
        private void LoadRentRoomData(int page =1)
        {
            var db = new RoomManagerEntities2();
            RentRoomList = db.RentRooms.ToList();
            //Load Datagrid
            dgRentRoom.ItemsSource = RentRoomList.Skip((page-1) * 10).Take(10);

            tbTotalPageRentRoom.Text = (RentRoomList.Count() % 10!=0?RentRoomList.Count()/10+1: RentRoomList.Count() / 10).ToString();
            tbxCurrentPageRentRoom.Text = currentRentRoomPage.ToString();
        }
        private void dgRentRoom_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            RentRoom rr = dgRentRoom.SelectedItem as RentRoom;
            if (rr != null )
            {
                var screen = new RentRoomInfoWindow(RentRoomInfoWindow.INFOACTION, rr);
                this.IsEnabled = false;
                screen.ShowDialog();
                
                this.IsEnabled = true;
            }
            LoadDuLieu();

        }
        private void dgServices_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            Service sv = dgServices.SelectedItem as Service;
            if (sv != null)
            {
                var screen = new ServicesInfoWindow(ServicesInfoWindow.INFOACTION, sv);
                this.IsEnabled = false;
                screen.ShowDialog();

                this.IsEnabled = true;
            }
            LoadDuLieu();

        }
        private void dgUsedServices_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            UsedService sv = dgUsedServices.SelectedItem as UsedService;
            if (sv != null)
            {
                var screen = new UsedServicesInfoWindow(UsedServicesInfoWindow.INFOACTION, sv);
                this.IsEnabled = false;
                screen.ShowDialog();

                this.IsEnabled = true;
            }
            LoadDuLieu();

        }
        private void btnInsertRentRoom_Click(object sender, RoutedEventArgs e)
        {
            var screen = new RentRoomInfoWindow(RentRoomInfoWindow.ADDACTION);
            this.IsEnabled = false;
            screen.ShowDialog();
            LoadDuLieu();
            this.IsEnabled = true;
        }

        private void btnImportRentRoom_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == true)
            {
                var wookbook = new Workbook(openFileDialog.FileName);
                var tabs = wookbook.Worksheets;
                using (var db = new RoomManagerEntities2())
                {
                    foreach (var tab in tabs)
                    {
                        try
                        {
                            if (tab.Name == "RentRoom")
                            {
                                var col = 'B';
                                var row = 2;
                                var cell = tab.Cells[$"{ col}{ row}"];
                                while (cell.Value != null)
                                {

                                    var newRent = new RentRoom()
                                    {
                                        roomID = tab.Cells[$"B{row}"].IntValue,
                                        renterName = tab.Cells[$"C{row}"].StringValue,
                                        tel = tab.Cells[$"D{row}"].StringValue,
                                        price = tab.Cells[$"E{row}"].DoubleValue,
                                        date = tab.Cells[$"F{row}"].DateTimeValue,
                                };
                                    db.RentRooms.Add(newRent);

                                    db.SaveChanges();

                                    row++;
                                    cell = tab.Cells[$"{ col}{ row}"];
                                }
                                LoadRentRoomData();

                            }
                           
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }
                    }
                }
            }
        }

        private void btnSaveRentRoom_Click(object sender, RoutedEventArgs e)
        {

        }

        private void tbSearchRentRoom_TextChanged(object sender, TextChangedEventArgs e)
        {
            
            var str = tbSearchRentRoom.Text.ToLower().AccentRemoved();
            dgRentRoom.ItemsSource = RentRoomList.Where(i => i.renterName.Contains(str) || i.tel.Contains(str));
        }
        private void btnInsertServices_Click(object sender, RoutedEventArgs e)
        {
            var screen = new ServicesInfoWindow(ServicesInfoWindow.ADDACTION);
            this.IsEnabled = false;
            screen.ShowDialog();
            LoadDuLieu();
            this.IsEnabled = true;
        }

        private void btnImportServices_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == true)
            {
                var wookbook = new Workbook(openFileDialog.FileName);
                var tabs = wookbook.Worksheets;
                using (var db = new RoomManagerEntities2())
                {
                    foreach (var tab in tabs)
                    {
                        try
                        {
                            if (tab.Name == "Services")
                            {
                                var col = 'B';
                                var row = 2;
                                var cell = tab.Cells[$"{ col}{ row}"];
                                while (cell.Value != null)
                                {

                                    var newService= new Service()
                                    {
                                       
                                        name = tab.Cells[$"B{row}"].StringValue,
                                       
                                        price = tab.Cells[$"C{row}"].DoubleValue,
                                      
                                    };
                                    db.Services.Add(newService);

                                    db.SaveChanges();

                                    row++;
                                    cell = tab.Cells[$"{ col}{ row}"];
                                }
                                LoadServicesData();

                            }

                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }
                    }
                }
            }
        }

        private void btnSaveServices_Click(object sender, RoutedEventArgs e)
        {

        }

        private void tbSearchServices_TextChanged(object sender, TextChangedEventArgs e)
        {
            var str = tbSearchServices.Text.ToLower().AccentRemoved();
            dgServices.ItemsSource = ServiceList.Where(i => i.name.Contains(str));

        }
        private void btnInsertUsedServices_Click(object sender, RoutedEventArgs e)
        {
            var screen = new UsedServicesInfoWindow(UsedServicesInfoWindow.ADDACTION);
            this.IsEnabled = false;
            screen.ShowDialog();
            LoadDuLieu();
            this.IsEnabled = true;
        }

        private void btnImportUsedServices_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == true)
            {
                var wookbook = new Workbook(openFileDialog.FileName);
                var tabs = wookbook.Worksheets;
                using (var db = new RoomManagerEntities2())
                {
                    foreach (var tab in tabs)
                    {
                        try
                        {
                            if (tab.Name == "Services")
                            {
                                var col = 'B';
                                var row = 2;
                                var cell = tab.Cells[$"{ col}{ row}"];
                                while (cell.Value != null)
                                {

                                    var newUService = new UsedService()
                                    {

                                        rentRoomID = tab.Cells[$"B{row}"].IntValue,

                                        date = tab.Cells[$"C{row}"].DateTimeValue,
                                        status = tab.Cells[$"D{row}"].IntValue,

                                    };
                                    db.UsedServices.Add(newUService);

                                    db.SaveChanges();

                                    row++;
                                    cell = tab.Cells[$"{ col}{ row}"];
                                }
                                LoadServicesData();

                            }

                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }
                    }
                    foreach (var tab in tabs)
                    {
                        try
                        {
                            if (tab.Name == "USDDetails")
                            {
                                var col = 'B';
                                var row = 2;
                                var cell = tab.Cells[$"{ col}{ row}"];
                                while (cell.Value != null)
                                {

                                    var newUSDDetail = new USDDetail()
                                    {

                                         usID= tab.Cells[$"B{row}"].IntValue,
                                        sID = tab.Cells[$"C{row}"].IntValue,
                                        times = tab.Cells[$"D{row}"].IntValue,
                                        price = tab.Cells[$"E{row}"].DoubleValue,
                                        date = tab.Cells[$"F{row}"].DateTimeValue,

                                    };
                                    db.USDDetails
                                        .Add(newUSDDetail);

                                    db.SaveChanges();

                                    row++;
                                    cell = tab.Cells[$"{ col}{ row}"];
                                }
                                LoadServicesData();

                            }

                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }
                    }
                }
            }
        }

        private void btnSaveUsedServices_Click(object sender, RoutedEventArgs e)
        {

        }

        private void tbSearchUsedServices_TextChanged(object sender, TextChangedEventArgs e)
        {
            var id = int.Parse( tbSearchUsedServices.Text);
            dgUsedServices.ItemsSource = UsedServiceList.Where(i => i.rentRoomID==id);
        }

        public int currentRentRoomPage = 1;
        private void tbxCurrentPageRentRoom_KeyDown(object sender, KeyEventArgs e)
        {
            {
                if (e.Key == Key.Enter)
                {
                    MessageBox.Show(tbxCurrentPageRentRoom.Text);
                    currentRentRoomPage = int.Parse(tbxCurrentPageRentRoom.Text);
                    LoadRentRoomData(currentRentRoomPage);
                }
            }
        }

        private void btnPreviousPageRentRoom_Click(object sender, RoutedEventArgs e)
        {
            if (currentRentRoomPage >0)
            {
                currentRentRoomPage--;
                LoadRentRoomData(currentRentRoomPage );
            }
            
        }

        private void btnNextPageRentRoom_Click(object sender, RoutedEventArgs e)
        {
            var totalPage = int.Parse(tbTotalPageRentRoom.Text);
            if (currentRentRoomPage<totalPage )
            {
                currentRentRoomPage++;
                LoadRentRoomData(currentRentRoomPage);
            }
            
        }
        public int currentServicesPage = 1;
        private void LoadServicesData(int page = 1)
        {
            var db = new RoomManagerEntities2();
            ServiceList = db.Services.ToList();
            //Load Datagrid
            dgServices.ItemsSource = ServiceList.Skip((page - 1) * 10).Take(10);
            tbTotalPageServices.Text = (ServiceList.Count() % 10 != 0 ? ServiceList.Count() / 10 + 1 : ServiceList.Count() / 10).ToString();
            tbxCurrentPageServices.Text = currentServicesPage.ToString();
        }
        private void tbxCurrentPageServices_KeyDown(object sender, KeyEventArgs e)
        {
            {
                if (e.Key == Key.Enter)
                {
                    MessageBox.Show(tbxCurrentPageServices.Text);
                    currentServicesPage = int.Parse(tbxCurrentPageServices.Text);
                    LoadServicesData(currentServicesPage);
                }
            }
        }

        private void btnPreviousPageServices_Click(object sender, RoutedEventArgs e)
        {
            if (currentServicesPage > 1)
            {
                currentServicesPage--;
                LoadServicesData(currentServicesPage);
            }

        }

        private void btnNextPageServices_Click(object sender, RoutedEventArgs e)
        {
            var totalPage = int.Parse(tbTotalPageServices.Text);
            if (currentServicesPage < totalPage)
            {
                currentServicesPage++;
                LoadServicesData(currentServicesPage);
            }

        }
        // #used services
        public int currentUsedServicesPage = 1;
        private void LoadUsedServicesData(int page = 1)
        {
            var db = new RoomManagerEntities2();
            UsedServiceList = db.UsedServices.ToList();
            
            //Load Datagrid
            dgUsedServices.ItemsSource = UsedServiceList.Skip((page - 1) * 10).Take(10);
            tbTotalPageUsedServices.Text = (UsedServiceList.Count() % 10 != 0 ? UsedServiceList.Count() / 10 + 1 : UsedServiceList.Count() / 10).ToString();
            tbxCurrentPageUsedServices.Text = currentUsedServicesPage.ToString();
        }
        private void tbxCurrentPageUsedServices_KeyDown(object sender, KeyEventArgs e)
        {
            {
                if (e.Key == Key.Enter)
                {
                    MessageBox.Show(tbxCurrentPageUsedServices.Text);
                    currentUsedServicesPage = int.Parse(tbxCurrentPageUsedServices.Text);
                    LoadUsedServicesData(currentUsedServicesPage);
                }
            }
        }

        private void btnPreviousPageUsedServices_Click(object sender, RoutedEventArgs e)
        {
            if (currentUsedServicesPage > 1)
            {
                currentUsedServicesPage--;
                LoadUsedServicesData(currentUsedServicesPage);
            }

        }

        private void btnNextPageUsedServices_Click(object sender, RoutedEventArgs e)
        {
            var totalPage = int.Parse(tbTotalPageUsedServices.Text);
            if (currentUsedServicesPage < totalPage)
            {
                currentUsedServicesPage++;
                LoadUsedServicesData(currentUsedServicesPage);
            }

        }

        private void StackPanel_Refresh_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            LoadDuLieu();
        }
    }
}
