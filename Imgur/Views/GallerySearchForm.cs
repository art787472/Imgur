using Imgur.Components;
using Imgur.Contract;

using Imgur.Presenter;
using imgurAPI;
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
    public partial class GallerySearchForm : Form, GallerySearchView
    {
        
        private GallerySearchPresenter presenter;
        private Pagination pagination = new Pagination(4);
        public GallerySearchForm()
        {
            InitializeComponent();
            presenter = new GallerySearchFormPresenter(this);
            pagination.PageChanged += Pagination_PageChanged;
            this.paginationBox.Controls.Add(pagination);

        }

        private void Pagination_PageChanged(object sender, int e)
        {
            MemoryCollect();
            presenter.SelectPage(e);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MemoryCollect();
            presenter.Search(Models.ContentFormType.Search, textBox1.Text);
            
        }

        public void PageChangeFinish(GalleryModel.Datum[] data)
        {
            foreach (var item in data)
            {
                GalleryItem newItem = new GalleryItem(item);
                flowLayoutPanel1.Controls.Add(newItem);
            }
        }

        public void SearchFinished(GalleryModel.Datum[] data)
        {
            var renderData = data.Take(4).ToArray();
            foreach (var item in renderData)
            {
                GalleryItem newItem = new GalleryItem(item);
                flowLayoutPanel1.Controls.Add(newItem);
            }

            
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

        private void GallerySearchForm_Load(object sender, EventArgs e)
        {

        }

        private void 我的收藏ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form favForm = new GalleryFavoriteForm();
            favForm.Show();

        }

        public void AddFavoriteFinish(bool isFavorite)
        {
            throw new NotImplementedException();
        }

        public void GetFavoriteFinish(GalleryModel.Datum[] data)
        {
            var renderData = data.Take(4).ToArray();
            foreach (var item in renderData)
            {
                GalleryItem newItem = new GalleryItem(item);
                flowLayoutPanel1.Controls.Add(newItem);
            }
            

            pagination.Total = data.Length;
        }

        private void 檔案上傳ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form form = new ImageUploadForm();
            form.Show();
        }

        private void 我的相簿ToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            Form form = new AlbumForm();
            form.Show();
        }
    }
}
