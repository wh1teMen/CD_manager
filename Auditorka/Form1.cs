using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Auditorka
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
           
        }
        DriveInfo[] drives = DriveInfo.GetDrives();
        List<Disk> diskList = new List<Disk>();
        private void Paint_line(object sender, PaintEventArgs e)
        {
            DoubleBuffered = true;
            Graphics g = e.Graphics;
            Pen pn_Green = new Pen(Brushes.Green, 12);
            Pen pn_fons = new Pen(Brushes.Gray, 12);
            Pen pn_red = new Pen(Brushes.Red, 12);
            Pen pn_fons2 = new Pen(Brushes.Black, 1);
            if (diskList.Count > 0)
            {
                int step_y = 0;
                foreach (var item in diskList)
                {                  
                   
                    step_y +=25;
                    var remains = ((item.FreeSize*100)/item.FullSize);
                     if(remains < 30)
                     {
                        g.DrawRectangle(pn_fons, 40, step_y-25, 100,12);
                        g.DrawRectangle(pn_red, 40, step_y-25, remains,12);

                     }
                     else 
                     {
                        g.DrawRectangle(pn_fons,40, step_y-25, 100, 12);
                        g.DrawRectangle(pn_Green, 40, step_y-25, remains, 12);

                     }                   

                }
            }


        }
       

        private void add_List_Disk()
        {
            if (drives != null)
            {
                for (int i = 0; i < drives.Length; i++)
                {
                    string Name_C = drives.ElementAt(i).Name.ToString();
                    long Size_C = ((drives.ElementAt(i).TotalSize / 1024) / 1024) / 1024;
                    long FreeSize_C = ((drives.ElementAt(i).TotalFreeSpace / 1024) / 1024) / 1024;
                    var disk = new Disk(Name_C, FreeSize_C, Size_C);
                    diskList.Add(disk);
                }
            }

        }
        private void Size_window()
        {
            
            if (drives != null)
            {
                Rectangle screen = Screen.PrimaryScreen.WorkingArea;
                int w = 270;
                int h = 60+(20*drives.Length);
                this.Size = new Size(w, h);
                this.MaximumSize = this.MinimumSize = this.Size;
                this.MinimizeBox = false;
                this.MaximizeBox = false;
            }
        }
        private void printLAble()
        {
            int step_y = 0;
            foreach (var item in diskList)
            {
                step_y += 24;
                string sizeTmp = "";
                sizeTmp += item.freeSize.ToString() + "/" + item.fullSize.ToString() +"Gb";
                this.Controls.Add(Add_lable_name(item.Name,30, 0, step_y-21));
                this.Controls.Add(Add_lable_name(sizeTmp,90, 150, step_y-21));
            }

        }
        private Label Add_lable_name(string nameLable, int width, int x,int y)
        {
            var lable_ = new Label();
            lable_.Text = nameLable;
            lable_.Font = new Font("Arial Black", 10, FontStyle.Bold);
            lable_.Width = width;
            lable_.Location = new Point(x, y);
            return lable_;
        }     
        private void Form1_Load(object sender, EventArgs e)
        {
           Size_window();
            add_List_Disk();
            printLAble();           
            this.Paint += Paint_line;
        }
    }
}
