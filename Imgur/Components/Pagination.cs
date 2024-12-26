using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using Label = System.Windows.Forms.Label;

namespace Imgur.Components
{
    public partial class Pagination : UserControl
    {
        public int currentPage { get; set; } = 1;
        public int Total 
        {
            get => total;
            set
            {
                total = value;
                Render();
            }
        }
        private int total = 1;
        private int pageSize = 1;
        private int pageCount;
        private int pageRange = 10;

        private PaginationService paginationService;

        public event EventHandler<int> PageChanged;

        public Pagination()
        {
            InitializeComponent();
        }

        public Pagination(int pageSize)
        {
            InitializeComponent();
            this.pageSize = pageSize;
        }
        public Pagination(int total, int pageSize)
        {
            InitializeComponent();
            this.pageSize = pageSize;
            this.total = total;

            this.pageCount = total % pageSize == 0 ? total / pageSize : total / pageSize + 1;

            paginationService = new PaginationService(pageCount, pageRange);
            paginationService.ChangePage(1, RenderPages);
            SelectFinish(paginationService.currentPage);

        }

        private void Render()
        {
            this.pageCount = total % pageSize == 0 ? total / pageSize : total / pageSize + 1;
            paginationService = new PaginationService(pageCount, pageRange);
            paginationService.ChangePage(1, RenderPages);
            SelectFinish(paginationService.currentPage);
        }


        private void SelectFinish(int currentPage)
        {
            var control = flowLayoutPanel1.Controls.OfType<FlowLayoutPanel>().First();
            foreach(Label label in control.Controls)
            {
                bool switchColor = label.Text == currentPage.ToString();
                label.ForeColor = switchColor ? Color.BlueViolet : Color.Black;
                label.BackColor = switchColor ? Color.White : Color.Transparent;
            }

            if(PageChanged != null)
            {
                PageChanged.Invoke(this, currentPage);

            }
         }
                
            
        

        private void ClickPagination(object sender, EventArgs e)
        {
            Label l = (Label)sender;
            var page = paginationService.ChangePage(Convert.ToInt32(l.Text), RenderPages);
            SelectFinish(page);
        }

        
        private void RenderPages(List<int> pages)
        {
            flowLayoutPanel1.Controls.Clear();

            foreach(var text in funcBtndict)
            {
                AddFuncButton(text.Key, text.Value);
            }

            if (!pages.Contains(1))
                AddFirstPage();

            
            AddPages(pages);
            
            
            if (!pages.Contains(pageCount))
                AddLastPage();

            var controls = flowLayoutPanel1.Controls.Cast<Control>()
                .OrderBy(c => c.TabIndex)
                .ToArray();

            flowLayoutPanel1.Controls.Clear();
            flowLayoutPanel1.Controls.AddRange(controls);


        }




        private void ClickFuncButton(object sender, EventArgs e)
        {
            Label l = (Label)sender;
            var currentPage = 0; ;
            var pages = new List<int>();
            switch (l.Text)
            {
                case ">":
                    currentPage = paginationService.ChangePage(Models.PaginationAction.Next, RenderPages);
                    break;
                case "<":
                    currentPage = paginationService.ChangePage(Models.PaginationAction.Previous, RenderPages);
                    break;
                case ">>":
                    currentPage = paginationService.ChangePage(Models.PaginationAction.Forward, RenderPages);
                    break;
                case "<<":
                    currentPage = paginationService.ChangePage(Models.PaginationAction.Backward, RenderPages);
                    break;
            }

            SelectFinish(currentPage);
        }

       

        private Label GenerateLabel(string text)
        {
            return new Label { Text = text, Width = 30, Height = 30, BorderStyle = BorderStyle.FixedSingle, Cursor = Cursors.Hand };
        }

        

        private Dictionary<string, int> funcBtndict = new Dictionary<string, int>
        {
            ["<"] = 2,
            ["<<"] = 3,
            [">"] = 5,
            [">>"] = 6
        };

        private void AddFuncButton(string text, int index)
        {
            var label = GenerateLabel(text);
            label.Click += ClickFuncButton;
            label.TabIndex = index;
            flowLayoutPanel1.Controls.Add(label);
        }


        private void AddFirstPage()
        {
            var label = GenerateLabel("1");
            label.Click += ClickPagination;
            label.TabIndex = 1;
            flowLayoutPanel1.Controls.Add(label);
        }

        private void AddLastPage()
        {
            var label = GenerateLabel(pageCount.ToString());
            label.Click += ClickPagination;
            label.TabIndex = 7;
            flowLayoutPanel1.Controls.Add(label);
        }

        private void AddPages(List<int> pages)
        {
            FlowLayoutPanel panel = new FlowLayoutPanel();
            panel.Width = 36 * pages.Count;
            panel.Height = 30;
            panel.TabIndex = 4;
            foreach(var page in pages)
            {
                var label = GenerateLabel(page.ToString());
                label.Click += ClickPagination;
                panel.Controls.Add(label);
            }
            flowLayoutPanel1.Controls.Add(panel);

        }



    }
}
