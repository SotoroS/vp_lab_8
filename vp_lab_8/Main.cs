using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Windows.Forms;
using System.Xml.Linq;

namespace vp_lab_8
{
    public partial class Main : Form
    {
        List<News> news = new List<News>();

        public Main()
        {
            InitializeComponent();

            // Загрузка ленты
            XElement rootTag = XElement.Load("https://news.yandex.ru/world.rss").Element(XName.Get("channel")); ;

            // Создание корневого элемента
            TreeNode rootNode = new TreeNode(rootTag.Name.ToString());

            // Поиск дочерних элементов корневого элемента
            FindChildrenTags(rootNode, rootTag);

            //// Добавление корневого элемента в дерево
            //treeView.Nodes.Add(rootNode);

            // Формируем заголовок окна
            Text = rootTag.Element(XName.Get("title")).Value + " " + rootTag.Element(XName.Get("lastBuildDate")).Value;

            // Формирование описания
            textBoxDescription.Text = rootTag.Element(XName.Get("description")).Value.Trim();

            // Формируем таблицу новостей
            foreach (XElement el in rootTag.Elements())
            {
                if (el.Name.ToString().ToLower() == "item")
                {
                    // Добавляем новость в список
                    news.Add(
                        new News(el.Element(XName.Get("title")).Value,
                            el.Element(XName.Get("description")).Value,
                            el.Element(XName.Get("pubDate")).Value,
                            el.Element(XName.Get("link")).Value
                        ));
                }
            }

            var query = from n in news select n;

            foreach (News n in query) listBox.Items.Add(n.title);
        }

        /// <summary>
        /// Поиск и добавление дочерних элементов
        /// </summary>
        /// <param name="node">Корневой узел</param>
        /// <param name="tag">Корневой тег</param>
        private void FindChildrenTags(TreeNode node, XElement tag)
        {
            // Связь узла тега
            node.Tag = tag;

            // Получение дочерних элементов
            IEnumerable<XElement> childTags = tag.Elements();

            if (childTags != null)
            {
                foreach (XElement childTag in childTags)
                {
                    // Создание дочернего узла
                    TreeNode childNode = new TreeNode(childTag.Name.ToString());

                    // Добавление поддочерних элементов
                    FindChildrenTags(childNode, childTag);

                    // Добавление дочернего узла в дерево
                    node.Nodes.Add(childNode);
                }
            }
        }

        private void listBox_Click(object sender, EventArgs e)
        {
            (new NewsDescription(news[((ListBox)sender).SelectedIndex])).Show();
        }
    }
}
