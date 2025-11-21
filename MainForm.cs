using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CarWiki;
using Microsoft.EntityFrameworkCore;

namespace CarWiki
{
    public partial class MainForm : Form
    {
        private readonly AppDbContext dbContext;
        public MainForm()
        {
            dbContext = new AppDbContext();
            InitializeComponent();
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            using (var diag = new AddCarForm())
            {
                if (diag.ShowDialog() == DialogResult.OK)
                {
                    var make = diag.Make();
                    var model = diag.Model();
                    var year = diag.Year();
                    var horsePower = diag.HorsePower();
                    var imagePath = diag.ImagePath();
                    var car = new Car(make, model, year, horsePower, imagePath);
                    await dbContext.Cars.AddAsync(car);
                    await dbContext.SaveChangesAsync();
                    await LoadCarsAsync();
                }
            }
        }

        protected override async void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            this.Resize += (_, __) => ApplyResponsiveLayout();
            await LoadCarsAsync();
        }

        private async Task LoadCarsAsync()
        {
            var cars = await dbContext.Cars.AsNoTracking().ToListAsync();

            tableLayoutPanel1.SuspendLayout();
            tableLayoutPanel1.Padding = new Padding(8, 8, 24, 8);
            tableLayoutPanel1.AutoScrollMargin = new Size(0, 8);
            tableLayoutPanel1.Controls.Clear();
            tableLayoutPanel1.RowStyles.Clear();
            tableLayoutPanel1.RowCount = 0;
            tableLayoutPanel1.GrowStyle = TableLayoutPanelGrowStyle.AddRows;

            int columns = GetResponsiveColumnCount();
            ConfigureColumns(columns);
            for (int i = 0; i < cars.Count; i++)
            {
                int row = i / columns, col = i % columns;
                if (col == 0)
                {
                    tableLayoutPanel1.RowCount = row + 1;
                    tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.AutoSize));
                }

                var card = new CarCard { Dock = DockStyle.Fill, Margin = new Padding(8) };
                card.Bind(cars[i]);
                tableLayoutPanel1.Controls.Add(card, col, row);
            }

            tableLayoutPanel1.ResumeLayout();
        }

        private int GetResponsiveColumnCount()
        {
            int availableWidth = Math.Max(1, tableLayoutPanel1.ClientSize.Width - SystemInformation.VerticalScrollBarWidth - tableLayoutPanel1.Padding.Horizontal);
            int targetCardWidth = 360;
            int columns = Math.Max(1, Math.Min(3, availableWidth / targetCardWidth));
            return columns;
        }

        private void ConfigureColumns(int columns)
        {
            if (columns <= 0) columns = 1;
            if (tableLayoutPanel1.ColumnCount == columns && tableLayoutPanel1.ColumnStyles.Count == columns)
            {
                return;
            }
            tableLayoutPanel1.ColumnStyles.Clear();
            tableLayoutPanel1.ColumnCount = columns;
            float pct = 100f / columns;
            for (int i = 0; i < columns; i++)
            {
                tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, pct));
            }
        }

        private void ApplyResponsiveLayout()
        {
            int columns = GetResponsiveColumnCount();
            if (columns <= 0) columns = 1;
            if (tableLayoutPanel1.ColumnCount == columns) return;

            var cards = tableLayoutPanel1.Controls.OfType<CarCard>().ToList();
            tableLayoutPanel1.SuspendLayout();
            tableLayoutPanel1.Controls.Clear();
            tableLayoutPanel1.RowStyles.Clear();
            tableLayoutPanel1.RowCount = 0;
            ConfigureColumns(columns);

            for (int i = 0; i < cards.Count; i++)
            {
                int row = i / columns, col = i % columns;
                if (col == 0)
                {
                    tableLayoutPanel1.RowCount = row + 1;
                    tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.AutoSize));
                }
                var card = cards[i];
                card.Margin = new Padding(8);
                card.Dock = DockStyle.Fill;
                tableLayoutPanel1.Controls.Add(card, col, row);
            }
            tableLayoutPanel1.ResumeLayout();
        }
    }
}
