using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace vp_lab_8
{
    public partial class Main : Form
    {
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
            textBoxDescription.Text = rootTag.Element(XName.Get("description")).Value;

            // Добавляем название столбцов
            listView.Items.Clear();
            listView.Columns.Clear();

            listView.Columns.Add("Заголовок");
            listView.Columns.Add("Описание");
            listView.Columns.Add("Дата публикации");
            listView.Columns.Add("Ссылка");

            // Формируем таблицу новостей
            foreach (XElement element in rootTag.Elements())
            {
                if (element.Name.ToString().ToLower() == "item")
                {
                    // Заполнение таблицы
                    XElement title = element.Element(XName.Get("title"));
                    ListViewItem item = new ListViewItem(title.Value);

                    XElement description = element.Element(XName.Get("description"));
                    item.SubItems.Add(description.Value);

                    XElement date = element.Element(XName.Get("pubDate"));
                    item.SubItems.Add(date.Value);

                    XElement link = element.Element(XName.Get("link"));
                    item.SubItems.Add(link.Value);

                    listView.Items.Add(item);
                }
            }

            // Изменение размеров колонок списка
            listView.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
            listView.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
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

        /// <summary>
        /// Событие вызываемое при ЛКМ по узлу дерева
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void treeView_AfterSelect(object sender, TreeViewEventArgs e)
        {
            // Получаем объект связанный с узлом
            object tag = e.Node.Tag;

            // Проверяем на пренадлежность к классу XElement
            if (tag is XElement)
            {
                // Приведение типа
                XElement element = (XElement)tag;
             
                if (element.Name.ToString().ToLower() == "item")
                {
                    // Добавляем название столбцов
                    listView.Items.Clear();
                    listView.Columns.Clear();

                    listView.Columns.Add("Заголовок");
                    listView.Columns.Add("Описание");
                    listView.Columns.Add("Дата публикации");
                    listView.Columns.Add("Ссылка");

                    // Заполнение таблицы
                    XElement title = element.Element(XName.Get("title"));
                    ListViewItem item = new ListViewItem(title.Value);

                    XElement description = element.Element(XName.Get("description"));
                    item.SubItems.Add(description.Value);

                    XElement date = element.Element(XName.Get("pubDate"));
                    item.SubItems.Add(date.Value);

                    XElement link = element.Element(XName.Get("link"));
                    item.SubItems.Add(link.Value);

                    listView.Items.Add(item);
                }
            }
        }

        private void Main_Load(object sender, EventArgs e)
        {

        }
    }
}
