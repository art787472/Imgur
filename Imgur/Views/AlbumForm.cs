using Imgur.Components;
using Imgur.Contract;
using Imgur.Presenter;
using imgurAPI.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Imgur.Views
{
    public partial class AlbumForm : Form, IAlbumView, GallerySearchView
    {
        private IAlbumPresenter _albumPresenter;
        private GallerySearchPresenter _galleryPresenter;
        private Pagination pagination = new Pagination(4);
        public AlbumForm()
        {
            InitializeComponent();
            _albumPresenter = new AlbumPresenter(this);
            _galleryPresenter = new GallerySearchFormPresenter(this);
            pagination.PageChanged += Pagination_PageChanged;
            this.paginationBox.Controls.Add(pagination);

            _albumPresenter.GetAlbums("art787472");
        }

        private void MemoryCollect()
        {
            foreach (var control in flowLayoutPanel1.Controls)
            {
                var item = (GalleryItem)control;
                item.pictureBox1.Image = null;
                item.pictureBox1.Dispose();
                item.Dispose();
            }

            flowLayoutPanel1.Controls.Clear();
            GC.Collect();
        }

        private void Pagination_PageChanged(object sender, int e)
        {
            MemoryCollect();
            _galleryPresenter.SelectPage(e);
        }

        public void GetAlblumsFinish(List<KeyValuePair<string, string>> titles)
        {
            albumComboBox.DataSource = titles;
            albumComboBox.DisplayMember = "Value";
        }

       

        public void GetAlbumFinish(GalleryModel.Datum data)
        {
            MemoryCollect();
            List<GalleryModel.Datum> imagesData = new List<GalleryModel.Datum>();
            foreach (var img in data.images)
            {
                var imgData = new GalleryModel.Datum();
                imgData.title = img.title;
                imgData.comment_count = img.comment_count;
                imgData.views = img.views;
                imgData.ups = img.ups;
                imgData.cover = img.id;
                GalleryItem newItem = new GalleryItem(imgData);
                newItem.Enabled = false;
                imagesData.Add(imgData);
                flowLayoutPanel1.Controls.Add(newItem);
            }

            _galleryPresenter.data = imagesData.ToArray();
            pagination.Total = imagesData.Count;

        }

        public void SearchFinished(GalleryModel.Datum[] data)
        {
            throw new NotImplementedException();
        }

        public void PageChangeFinish(GalleryModel.Datum[] data)
        {
            foreach (var item in data)
            {
                GalleryItem newItem = new GalleryItem(item);
                flowLayoutPanel1.Controls.Add(newItem);
            }
        }

        private async void  albumComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox comboBox = (ComboBox)sender;
            string albumHash = string.Empty;
            if(comboBox.SelectedItem is KeyValuePair<string, string> item)
            {
                albumHash = item.Key;
            }
            var callback = await _albumPresenter.GetAlbum(albumHash);
            callback.Invoke();

        }
    }
}
