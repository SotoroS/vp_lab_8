namespace vp_lab_8
{
    partial class Main
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            this.textBoxDescription = new System.Windows.Forms.TextBox();
            this.listView = new System.Windows.Forms.ListView();
            this.SuspendLayout();
            // 
            // textBoxDescription
            // 
            this.textBoxDescription.Location = new System.Drawing.Point(12, 8);
            this.textBoxDescription.Multiline = true;
            this.textBoxDescription.Name = "textBoxDescription";
            this.textBoxDescription.ReadOnly = true;
            this.textBoxDescription.Size = new System.Drawing.Size(1174, 41);
            this.textBoxDescription.TabIndex = 2;
            // 
            // listView
            // 
            this.listView.Activation = System.Windows.Forms.ItemActivation.OneClick;
            this.listView.AllowColumnReorder = true;
            this.listView.FullRowSelect = true;
            this.listView.HoverSelection = true;
            this.listView.Location = new System.Drawing.Point(12, 55);
            this.listView.Name = "listView";
            this.listView.ShowItemToolTips = true;
            this.listView.Size = new System.Drawing.Size(1174, 538);
            this.listView.TabIndex = 1;
            this.listView.UseCompatibleStateImageBehavior = false;
            this.listView.View = System.Windows.Forms.View.Details;
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(1198, 605);
            this.Controls.Add(this.textBoxDescription);
            this.Controls.Add(this.listView);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Main";
            this.Text = "Yandex.Новости: В мире";
            this.Load += new System.EventHandler(this.Main_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox textBoxDescription;
        private System.Windows.Forms.ListView listView;
    }
}

