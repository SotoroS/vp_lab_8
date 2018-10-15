namespace vp_lab_8
{
    /// <summary>
    /// Новость
    /// </summary>
    public class News
    {
        private static uint count = 0;

        public static uint Count {
            get
            {
                return count;
            }
        }

        public string title;        // Заголловок
        public string description;  // Описание
        public string date;         // Дата
        public string url;          // URL адресс на новость

        public News(string title, string description, string date, string url)
        {
            this.title = title;
            this.description = description;
            this.date = date;
            this.url = url;

            
            count++; // Увеличиваем количество элементов
        }

    }
}
