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
using System.Windows.Shapes;

namespace QLTro
{
    /// <summary>
    /// Interaction logic for InsertRoomCategory.xaml
    /// </summary>
    public partial class InsertRoomCategory : Window
    {
        RoomCategory item = new RoomCategory();
        List<string> imgs;
        DataGrid data;
        public InsertRoomCategory(DataGrid dt)
        {
            data = dt;
            this.WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
            InitializeComponent();
        }
        private async void btinsert_Click(object sender, RoutedEventArgs e)
        {
            if (item.Name != "" && item.Price != 0 && item.Description != "")
            {
                using (var db = new RoomManagerEntities2())
                {
                    try
                    {
                        RoomCategory newitem = new RoomCategory();
                        newitem.OperEqual(item);
                        db.RoomCategories.Add(newitem);
                        await db.SaveChangesAsync();
                        foreach (var img in imgs)
                        {
                            ////Đường Dẫn File Ảnh Gốc
                            //var sourceImageFileInfo = new FileInfo(img);

                            ////Tao ten duy nhat
                            //var uniqueName = $"{Guid.NewGuid()}{sourceImageFileInfo.Extension}";

                            ////Đường dẫn tập tin exe
                            //var baseDirectory = AppDomain.CurrentDomain.BaseDirectory;

                            ////Đường dẫn folder Image trong file exe
                            //var destinationPath = $"{baseDirectory}Image_RoomCategory\\{uniqueName}";

                            ////Copy Ảnh từ File Ảnh Gốc Sang Folder Ảnh Trong File Exe
                            //if (!File.Exists(destinationPath))
                            //{
                            //    File.Copy(img, destinationPath);
                            //}
                            var newsource = ImageUniqueName.UniqueName(img);
                            var newimg = new ImagesRoomCategory()
                            {
                                IdCategory = newitem.Id,
                                Source = newsource,
                            };

                            newitem.ImagesRoomCategories.Add(newimg);
                            await db.SaveChangesAsync();
                        }
                        MessageBox.Show("Them Loai Phong Thanh Cong");
                        item.ResetValue();
                        tbname.Text = "";
                        tbgia.Text = "";
                        tbdes.Text = "";
                        imgs.Clear();
                        lsviewinsert.ItemsSource = imgs.ToList();
                        data.ItemsSource = db.RoomCategories.ToList();
                    }
                    catch(Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
            }
            else
            {
                MessageBox.Show("Vui Long Nhap Du Thong Tin Loai Phong");
            }
        }
        private void btcancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        private void btchooseimage_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Multiselect = true;
            if (openFileDialog.ShowDialog() == true)
            {
                var images = openFileDialog.FileNames;
                foreach (var imge in images)
                {
                    imgs.Add(imge);
                }
            }
            lsviewinsert.ItemsSource = imgs.ToList();
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            imgs = new List<string>();
            this.DataContext = item;
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            var select = lsviewinsert.SelectedItem as string;
            if (select != null)
            {
                imgs.RemoveAt(imgs.IndexOf(select));
            }
            lsviewinsert.ItemsSource = imgs.ToList();
        }
    }
}
