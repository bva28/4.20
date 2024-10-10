using System.Data;
using System.Windows.Forms;
using static System.Windows.Forms.DataFormats;

namespace View
{
    /// <summary>
    /// Класс BasicForm.
    /// </summary>
    partial class BasicForm
    {
        /// <summary>
        ///  Необходимая переменная дизайнера.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Кнопка "Добавить".
        /// </summary>
        private Button _buttonAddTransport;

        /// <summary>
        /// Кнопка "Удалить".
        /// </summary>
        private Button _buttonRemoveTransport;

        /// <summary>
        /// Кнопка "Найти".
        /// </summary>
        private Button _buttonFindTransport;

        /// <summary>
        /// Кнопка "Сбросить".
        /// </summary>
        private Button _buttonResetTransport;

        /// <summary>
        /// Кнопка "Сохранить".
        /// </summary>
        private Button _buttonSaveTransport;

        /// <summary>
        /// Кнопка "Открыть".
        /// </summary>
        private Button _buttonOpenTransport;

        /// <summary>
        /// Таблица для транспорта.
        /// </summary>
        private DataGridView _gridControlTransport;

        /// <summary>
        /// GroupBox для транспорта.
        /// </summary>
        private GroupBox _groupBoxTransport;

        /// <summary>
        ///  Метод для явного освобождения ресурсов.
        /// </summary>
        /// <param name="disposing">true если ресурсы необходимо
        /// удалить,иначе false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Метод инициализации компонентов (кнопки,текстовые поля и т.д.)
        /// </summary>
        private void InitializeComponent()
        {
            _groupBoxTransport = new GroupBox();
            _gridControlTransport = new DataGridView();
            
            _buttonAddTransport = new Button();
            _buttonRemoveTransport = new Button();
            _buttonFindTransport = new Button();
            _buttonResetTransport = new Button();
            _buttonSaveTransport = new Button();
            _buttonOpenTransport = new Button();
            // 
            // gridControlTransport
            // 
            _gridControlTransport.BackgroundColor = SystemColors.ButtonHighlight;
            _gridControlTransport.Name = "gridControlTransport";
            _gridControlTransport.Dock = DockStyle.Fill;
            _gridControlTransport.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            _gridControlTransport.DefaultCellStyle.ForeColor = Color.Black;
            _gridControlTransport.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            _gridControlTransport.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            _gridControlTransport.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            // 
            // buttonAddTransport
            // 
            _buttonAddTransport.BackColor = SystemColors.ButtonHighlight;
            _buttonAddTransport.ForeColor = SystemColors.ActiveCaptionText;
            _buttonAddTransport.Location = new Point(525, 390);
            _buttonAddTransport.Name = "buttonAddTransport";
            _buttonAddTransport.Size = new Size(100, 30);
            _buttonAddTransport.TabIndex = 1;
            _buttonAddTransport.Text = "Добавить";
            _buttonAddTransport.UseVisualStyleBackColor = false;
            // 
            // buttonRemoveTransport
            // 
            _buttonRemoveTransport.BackColor = SystemColors.ButtonHighlight;
            _buttonRemoveTransport.ForeColor = SystemColors.ActiveCaptionText;
            _buttonRemoveTransport.Location = new Point(650, 390);
            _buttonRemoveTransport.Name = "removeTransportButton";
            _buttonRemoveTransport.Size = new Size(100, 30);
            _buttonRemoveTransport.TabIndex = 2;
            _buttonRemoveTransport.Text = "Удалить";
            _buttonRemoveTransport.UseVisualStyleBackColor = false;
            // 
            // _buttonFindTransport
            // 
            _buttonFindTransport.BackColor = SystemColors.ButtonHighlight;
            _buttonFindTransport.ForeColor = SystemColors.ActiveCaptionText;
            _buttonFindTransport.Location = new Point(50, 390);
            _buttonFindTransport.Name = "_buttonFindTransport";
            _buttonFindTransport.Size = new Size(100, 30);
            _buttonFindTransport.TabIndex = 2;
            _buttonFindTransport.Text = "Найти";
            _buttonFindTransport.UseVisualStyleBackColor = false;
            // 
            // _buttonResetTransport
            // 
            _buttonResetTransport.BackColor = SystemColors.ButtonHighlight;
            _buttonResetTransport.ForeColor = SystemColors.ActiveCaptionText;
            _buttonResetTransport.Location = new Point(170, 390);
            _buttonResetTransport.Name = "_buttonResetTransport";
            _buttonResetTransport.Size = new Size(100, 30);
            _buttonResetTransport.TabIndex = 2;
            _buttonResetTransport.Text = "Сбросить";
            _buttonResetTransport.UseVisualStyleBackColor = false;
            // 
            // _buttonSaveTransport
            // 
            _buttonSaveTransport.BackColor = SystemColors.ButtonHighlight;
            _buttonSaveTransport.ForeColor = SystemColors.ActiveCaptionText;
            _buttonSaveTransport.Location = new Point(50, 20);
            _buttonSaveTransport.Name = "_buttonSaveTransport";
            _buttonSaveTransport.Size = new Size(100, 30);
            _buttonSaveTransport.TabIndex = 2;
            _buttonSaveTransport.Text = "Сохранить";
            _buttonSaveTransport.UseVisualStyleBackColor = false;
            // 
            // _buttonOpenTransport
            // 
            _buttonOpenTransport.BackColor = SystemColors.ButtonHighlight;
            _buttonOpenTransport.ForeColor = SystemColors.ActiveCaptionText;
            _buttonOpenTransport.Location = new Point(170, 20);
            _buttonOpenTransport.Name = "_buttonOpenTransport";
            _buttonOpenTransport.Size = new Size(100, 30);
            _buttonOpenTransport.TabIndex = 2;
            _buttonOpenTransport.Text = "Открыть";
            _buttonOpenTransport.UseVisualStyleBackColor = false;
            // 
            // groupBoxTransport
            // 
            _groupBoxTransport.Location = new Point(50, 60);
            _groupBoxTransport.Name = "groupBoxTransport";
            _groupBoxTransport.Size = new Size(700, 320);
            _groupBoxTransport.TabIndex = 0;
            _groupBoxTransport.TabStop = false;
            _groupBoxTransport.Text = "Список транспорта";
            _groupBoxTransport.Controls.Add(_gridControlTransport);
            // 
            // BasicForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.None;
            BackColor = SystemColors.ControlLightLight;
            ClientSize = new Size(800, 450);
            Controls.Add(_groupBoxTransport);
            Controls.Add(_buttonAddTransport);
            Controls.Add(_buttonRemoveTransport);
            Controls.Add(_buttonFindTransport);
            Controls.Add(_buttonResetTransport);
            Controls.Add(_buttonSaveTransport);
            Controls.Add(_buttonOpenTransport);
            ForeColor = Color.Bisque;
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Name = "BasicForm";
            MaximizeBox = false;
            MinimizeBox = false;
        }

        #endregion
    }
}
