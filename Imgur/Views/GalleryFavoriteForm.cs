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
    public partial class GalleryFavoriteForm : Form, GallerySearchView
    {

        private Pagination pagination = new Pagination(4);
        private GallerySearchPresenter presenter;
        public GalleryFavoriteForm()
        {
            InitializeComponent();
            presenter = new GallerySearchFormPresenter(this);
            pagination.PageChanged += Pagination_PageChanged;
            this.paginationBox.Controls.Add(pagination);

            presenter.Search(Models.ContentFormType.Favorite, "art787472");
        }

        private void Pagination_PageChanged(object sender, int e)
        {
            MemoryCollect();
            presenter.SelectPage(e);
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

        public void SearchFinished(GalleryModel.Datum[] data)
        {
            var renderData = data.Take(4).ToArray();
            foreach (var item in renderData)
            {
                GalleryItem newItem = new GalleryItem(item);
                flowLayoutPanel1.Controls.Add(newItem);
            }

            pagination.Total = data.Length;
        }

        public void PageChangeFinish(GalleryModel.Datum[] data)
        {
            foreach (var item in data)
            {
                GalleryItem newItem = new GalleryItem(item);
                flowLayoutPanel1.Controls.Add(newItem);
            }
        }
    }
}
