using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ChuffedFarm
{
    public partial class Frm_Main : Form
    {

        private PlantState  PlantState = PlantState.Nothing;
        private CPictureBox cpbxSeed;
        private int intAmount;

        public Frm_Main()
        {
            InitializeComponent();
        }
    
        private void pbxSeed_MouseEnter(object sender, EventArgs e)
        {
            this.pbxInseminate.Image = ChuffedFarm.Properties.Resources.播种1;
        }

        private void pbxSeed_MouseLeave(object sender, EventArgs e)
        {
            this.pbxInseminate.Image = ChuffedFarm.Properties.Resources.播种;
        }

        private void pbxVegetate_MouseEnter(object sender, EventArgs e)
        {
            this.pbxVegetate.Image = ChuffedFarm.Properties.Resources.生长1;
        }

        private void pbxVegetate_MouseLeave(object sender, EventArgs e)
        {
            this.pbxVegetate.Image = ChuffedFarm.Properties.Resources.生长;
        }

        private void pbxBlossomOut_MouseEnter(object sender, EventArgs e)
        {
            this.pbxBlossomOut.Image = ChuffedFarm.Properties.Resources.开花1;
        }

        private void pbxBlossomOut_MouseLeave(object sender, EventArgs e)
        {
            this.pbxBlossomOut.Image = ChuffedFarm.Properties.Resources.开花;
        }

        private void pbxMakeFruitage_MouseEnter(object sender, EventArgs e)
        {
            this.pbxMakeFruitage.Image = ChuffedFarm.Properties.Resources.结果1;
        }

        private void pbxMakeFruitage_MouseLeave(object sender, EventArgs e)
        {
            this.pbxMakeFruitage.Image = ChuffedFarm.Properties.Resources.结果;
        }

        private void pbxHarvest_MouseEnter(object sender, EventArgs e)
        {
            this.pbxHarvest.Image = ChuffedFarm.Properties.Resources.收获1;
        }

        private void pbxHarvest_MouseLeave(object sender, EventArgs e)
        {
            this.pbxHarvest.Image = ChuffedFarm.Properties.Resources.收获;
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            if (this.cpbxSeed != null)//若已生成CPictureBox控件实例
            {
                if (this.Bounds.Contains(Cursor.Position))//若光标在窗体内
                {
                    if (this.cpbxSeed.IsInseminate == false)//若种子还未种下
                    {
                        if (this.PlantState == PlantState.Inseminate)//若是种植状态
                        {
                            this.cpbxSeed.Location = new Point(e.X-20 , e.Y-40 );
                        }
                    }
                }
            }
        }

        private void Form1_Click(object sender, EventArgs e)
        {
            if (this.cpbxSeed != null)
            {
                this.cpbxSeed.IsInseminate = true;//表示种下
            }
        }

        private void cpbxSeed_Click(object sender, EventArgs e)
        {
            if (this.cpbxSeed != null)
            {
                this.cpbxSeed.IsInseminate = true;//表示种下
            }
        }

        private void pbxInseminate_Click(object sender, EventArgs e)
        {
            //什么时候可以种植
            if (PlantState != PlantState.Nothing && PlantState != PlantState.Harvest&&PlantState!= PlantState.Inseminate)
            {
                MessageBox.Show("还未收获，无法播种!");
                return;
            }
            //
            this.PlantState = PlantState.Inseminate;
            this.cpbxSeed = new CPictureBox();
            //
            this.cpbxSeed.BackColor = System.Drawing.Color.Transparent;
            this.cpbxSeed.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.cpbxSeed.Image = ChuffedFarm.Properties.Resources.seed2;
            this.cpbxSeed.Size = new System.Drawing.Size(ChuffedFarm.Properties.Resources.seed2.Width, ChuffedFarm.Properties.Resources.seed2.Height);//52.28
            this.cpbxSeed.Location = new System.Drawing.Point(this.pbxInseminate.Location.X-50,this.pbxInseminate.Location.Y - 80);
            //
            this.cpbxSeed.TabStop = true;
            this.cpbxSeed.IsInseminate = false;//刚刚创建种子实例，还未种下
            this.cpbxSeed.Click += new System.EventHandler(this.cpbxSeed_Click);
            this.Controls.Add(this.cpbxSeed);
            //
            tipSeed.SetToolTip(this.cpbxSeed, "这是种子");
        }

        private void pbxVegetate_Click(object sender, EventArgs e)
        {
            if (PlantState == PlantState.Nothing)
            {
                MessageBox.Show("还未播种，怎么长啊","信息提示！");
                return;
            }
            if (PlantState == PlantState.BlossomOut)
            {
                MessageBox.Show("正在开花，不能进入生长期！", "信息提示！");
                return;
            }
            if (PlantState == PlantState.MakeFruitage)
            {
                MessageBox.Show("正在结果，不能进入生长期！", "信息提示！");
                return;
            }

            if (PlantState == PlantState.Harvest)
            {
                MessageBox.Show("农场里都没有农作物了，怎么长呀！", "信息提示！");
                return;
            }

            this.PlantState = PlantState.Vegetate;
            
            IEnumerable<Control> cons = this.GetCPictureBoxes();
            foreach (CPictureBox cpbx in cons)
            {
                tipSeed.SetToolTip(cpbx, "");//已经开始生长，不再是种子，无需提示
                cpbx.Size = new Size(ChuffedFarm.Properties.Resources.grow.Width, ChuffedFarm.Properties.Resources.grow.Height);
                cpbx.Image = ChuffedFarm.Properties.Resources.grow;   
            }
        }

        private void pbxBlossomOut_Click(object sender, EventArgs e)
        {
            if (PlantState == PlantState.Nothing)
            {
                MessageBox.Show("还未播种，能开花吗？", "信息提示！");
                return;
            }

            if (PlantState == PlantState.Inseminate)
            {
                MessageBox.Show("刚刚播完种，还未生长，能开花吗？", "信息提示！");
                return;
            }
            if (PlantState == PlantState.MakeFruitage)
            {
                MessageBox.Show("正在结果，不能开花了！", "信息提示！");
                return;
            }
            if (PlantState == PlantState.Harvest)
            {
                MessageBox.Show("农场里都没有农作物了，怎么开花呀！", "信息提示！");
                return;
            }

            this.PlantState = PlantState.BlossomOut;
            IEnumerable<Control> cons = this.GetCPictureBoxes();
            foreach (CPictureBox cpbx in cons)
            {
                cpbx.Image = ChuffedFarm.Properties.Resources.bloom;
            }
        }

        private void pbxMakeFruitage_Click(object sender, EventArgs e)
        {
            if (PlantState == PlantState.Nothing)
            {
                MessageBox.Show("还未播种，能结果吗？", "信息提示！");
                return;
            }

            if (PlantState == PlantState.Inseminate)
            {
                MessageBox.Show("刚刚播完种，还未生长，能结果吗？", "信息提示！");
                return;
            }

            if (PlantState == PlantState.Vegetate)
            {
                MessageBox.Show("还处在生长期，并未开花，能结果吗？", "信息提示！");
                return;
            }

            if (PlantState == PlantState.Harvest)
            {
                MessageBox.Show("农场里都没有农作物了，怎么结果呀！", "信息提示！");
                return;
            }

            this.PlantState = PlantState.MakeFruitage;
            IEnumerable<Control> cons = this.GetCPictureBoxes();
            foreach (CPictureBox cpbx in cons)
            {
                cpbx.Image = ChuffedFarm.Properties.Resources.fruit;
            }
        }

        private void pbxHarvest_Click(object sender, EventArgs e)
        {
            if (PlantState == PlantState.Nothing)
            {
                MessageBox.Show("还未播种，能收获吗？", "信息提示！");
                return;
            }

            if (PlantState == PlantState.Inseminate)
            {
                MessageBox.Show("刚刚播完种，还未生长，能收获吗？", "信息提示！");
                return;
            }

            if (PlantState == PlantState.Vegetate)
            {
                MessageBox.Show("还处在生长期，并未开花，能收获吗？", "信息提示！");
                return;
            }

            if (PlantState == PlantState.BlossomOut)
            {
                MessageBox.Show("正在花期，并未结果，能收获吗？", "信息提示！");
                return;
            }


            if (PlantState == PlantState.Harvest)
            {
                MessageBox.Show("已经收过了！", "信息提示！");
                return;
            }

            IEnumerable<Control> cons = this.GetCPictureBoxes();
            foreach (CPictureBox cpbx in cons)
            {
                intAmount++;
                cpbx.Dispose();
            }
            if (cons.Count<Control>() > 0)
            {
                pbxHarvest_Click(sender, e);
            }
            this.PlantState = PlantState.Harvest;
            lbAmount.Text = "你的仓库里有" + intAmount.ToString()+"个果实！";
        }
        
        /// <summary>
        /// 获取动态生成的自定义PictureBox控件
        /// </summary>
        /// <returns></returns>
        private IEnumerable<Control> GetCPictureBoxes()
        {
            return this.Controls.Cast<Control>().Where(con => (con.GetType()==typeof(CPictureBox)));//Linq查询技术
        }
    }
}