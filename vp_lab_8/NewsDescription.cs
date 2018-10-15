using System;
using System.Diagnostics;
using System.Windows.Forms;

namespace vp_lab_8
{
    public partial class NewsDescription : Form
    {
        private string url;

        public NewsDescription(News news)
        {
            InitializeComponent();

            Text += " - " + news.title;

            textBoxTitle.Text = news.title;
            textBoxDescription.Text = news.description;
            textBoxDate.Text = news.date;

            this.url = news.url;
        }

        /// <summary>
        /// Закрытие окна
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// Открытие новости в браузере
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonOpenBrowser_Click(object sender, EventArgs e)
        {
            Process.Start(url);
        }
    }
}
