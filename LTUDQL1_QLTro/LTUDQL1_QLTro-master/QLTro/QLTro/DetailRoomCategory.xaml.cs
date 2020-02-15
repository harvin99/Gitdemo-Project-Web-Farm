using Microsoft.Win32;
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
    /// Interaction logic for DetailRoomCategory.xaml
    /// </summary>
    public partial class DetailRoomCategory : Window
    {
        List<ImagesRoomCategory> imgs;
        RoomCategory item;
        RoomCategory it = new RoomCategory();
        List<int> idimgsdelete;
        List<ImagesRoomCategory> insert;
        public DetailRoomCategory(RoomCategory roomctgr)
        {
            item = roomctgr;
            this.WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
            InitializeComponent();
        }

        private async void btapply_Click(object sender, RoutedEventArgs e)
        {

            this.IsEnabled = false;
            var creen = new ConfirmWindow($"Ban Co Chac Muon Edit Loai Phong");
            creen.ShowDialog();
            if (creen.DialogResult == true)
            {
                using (var db = new RoomManagerEntities2())
                {
                    try
                    {
                        var result = db.RoomCategories.SingleOrDefault(b => b.Id == item.Id);
                        if (result != null)
                        {
                            try
                            {
                                result.Name = it.Name;
                                result.Price = it.Price;
                                result.Description = it.Description;

                                await db.SaveChangesAsync();

                                foreach (var insr in insert)
                                {
                                    var newsource = ImageUniqueName.UniqueName(insr.Source);
                                    insr.Source = newsource;
                                    ImagesRoomCategory newimg = new ImagesRoomCategory()
                                    {
                                        IdCategory = insr.IdCategory,
                                        Source = insr.Source,
                                    };
                                    
                                    db.ImagesRoomCategories.Add(insr);
                                    await db.SaveChangesAsync();
                                }
                                foreach (var dele in idimgsdelete)
                                {
                                    var img = db.ImagesRoomCategories.Find(dele);
                                    db.ImagesRoomCategories.Remove(img);

                                    await db.SaveChangesAsync();
                                }
                            }
                            catch (Exception ex)
                            {
                                throw ex;
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
                stackpennalshow.Height = stackpennaledit.Height;
                stackpennaledit.Height = 0;
                btedit.Content = "Edit";

                var dba = new RoomManagerEntities2();
                item = dba.RoomCategories.Find(item.Id);
                stackpennalshow.DataContext = item;

                btapply.IsEnabled = false;
            }
            this.IsEnabled = true;
        }

        private void btedit_Click(object sender, RoutedEventArgs e)
        {
            if (btedit.Content.ToString() == "Edit")
            {
                //Load Du Lieu Cho edit
                it.OperEqual(item);
                LoadListImageEdit();
                lsviewedit.ItemsSource = imgs.ToList();
                idimgsdelete.Clear();
                insert.Clear();

                stackpennaledit.Height = stackpennalshow.Height;
                stackpennalshow.Height = 0;
                btedit.Content = "Show";
                btapply.IsEnabled = true;
            }
            else
            {
                stackpennalshow.Height = stackpennaledit.Height;
                stackpennaledit.Height = 0;
                btedit.Content = "Edit";
                btapply.IsEnabled = false;
            }
        }

        private void btdelete_Click(object sender, RoutedEventArgs e)
        {
            this.IsEnabled = false;
            var creen = new ConfirmWindow($"Ban Co Chac Muon Delete Loai Phong");
            creen.ShowDialog();
            if (creen.DialogResult == true)
            {
                if (item.Rooms.Count == 0)
                {
                    using (var db = new RoomManagerEntities2())
                    {
                        try
                        {
                            //Xoa Ảnh Trước
                            foreach (var img in item.ImagesRoomCategories)
                            {
                                var dele = db.ImagesRoomCategories.Find(img.Id);
                                db.ImagesRoomCategories.Remove(dele);
                                db.SaveChanges();
                            }
                            // Xóa Loại Room
                            var itemdelete = db.RoomCategories.Find(item.Id);
                            db.RoomCategories.Remove(itemdelete);
                            db.SaveChanges();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }
                    }
                    MessageBox.Show("Xoa Loai Phong Thanh Cong");
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Xoa That Bai Loai Phong Nay Dang Ton Tai Trong Mot Phong Nao Do");
                }
            }
            this.IsEnabled = true;
        }

        private void btchooseimage_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Multiselect = true;
            if (openFileDialog.ShowDialog() == true)
            {
                var images = openFileDialog.FileNames;
                foreach (var img in images)
                {
                    ImagesRoomCategory newimg = new ImagesRoomCategory
                    {
                        IdCategory = item.Id,
                        Source = img,
                    };
                    insert.Add(newimg);
                    imgs.Add(newimg);
                }
            }
            lsviewedit.ItemsSource = imgs.ToList();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            it.OperEqual(item);
            imgs = new List<ImagesRoomCategory>();
            LoadListImageEdit();

            lsviewedit.ItemsSource = imgs.ToList();

            idimgsdelete = new List<int>();
            insert = new List<ImagesRoomCategory>();
            this.DataContext = this;
            stackpennaledit.DataContext = it;
            stackpennalshow.DataContext = item;
        }
        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            var select = lsviewedit.SelectedItem as ImagesRoomCategory;
            if (select != null)
            {
                imgs.RemoveAt(imgs.IndexOf(select));
                if (insert.IndexOf(select) >= 0)
                {
                    insert.RemoveAt(insert.IndexOf(select));
                }
                if(select.Id != 0)
                {
                    idimgsdelete.Add(select.Id);
                }
                //else
                //{
                //    idimgsdelete.Add(select.Id);
                //}
                lsviewedit.ItemsSource = imgs.ToList();
            }
        }
        private void LoadListImageEdit()
        {
            imgs.Clear();
            foreach (var img in item.ImagesRoomCategories)
            {
                var baseDirectory = AppDomain.CurrentDomain.BaseDirectory;

                //Đường dẫn folder Image trong file exe
                var destinationPath = $"{baseDirectory}Image_RoomCategory\\{img.Source}";

                ImagesRoomCategory newimg = new ImagesRoomCategory()
                {
                    Id = img.Id,
                    IdCategory = img.IdCategory,
                    Source = destinationPath,
                };
                imgs.Add(newimg);
            }
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
                    var result = db.Rooms.FirstOrDefault(b => b.IdCategory == item.Id && b.Status ==1);
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
