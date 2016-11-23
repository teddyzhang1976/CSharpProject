using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.Runtime.InteropServices;

namespace DominateHornVocalization
{
    public partial class Frm_Main : Form
    {

        public Frm_Main()
        {
            InitializeComponent();
        }

        protected enum Tone//枚举 五线谱
        {
            REST = 0,
            A = 220,
            B = 247,
            C = 262,
            D = 294,
            E = 330,
            F = 349,
            G = 392,
        }

        protected enum Duration//枚举 发音时间
        {
            WHOLE = 1200,
            HALF = WHOLE / 2,
            QUARTER = HALF / 2,
            EIGHTH = QUARTER / 2,
            SIXTEENTH = EIGHTH / 2,
        }

        protected struct Note
        {
            Tone toneVal; 		//初始化一个Tone对象
            Duration durVal; 		//初始化一个Duration对象
            public Note(Tone frequency, Duration time) 			//定义一个Note方法
            {
                toneVal = frequency; 	//为变量toneVal赋值
                durVal = time; 		//为变量durVal赋值
            }
            public Tone NoteTone { get { return toneVal; } set { toneVal = value; } }		//定义一个Tone类型的属性
            public Duration NoteDuration { get { return durVal; } set { durVal = value; } }	//定义一个Duration类型的属性
        }

        protected void Play(Note tune)
        {
            if (tune.NoteTone == Tone.REST) 					//当没有选择RadioButton按钮时
                Thread.Sleep((int)tune.NoteDuration); 			//将当前线程挂起指定的时间
            else										//当选定某一个RadioButton按钮时
                //通过控制台扬声器播放具有指定频率和持续时间的声音
                Console.Beep((int)tune.NoteTone, (int)tune.NoteDuration);
        }

        private void PlayMic(int a)
        {
            Note note = new Note();
            switch (a)
            {
                case 1:
                    note.NoteTone = Tone.A;
                    break;
                case 2:
                    note.NoteTone = Tone.B;
                    break;
                case 3:
                    note.NoteTone = Tone.C;
                    break;
                case 4:
                    note.NoteTone = Tone.D;
                    break;
                case 5:
                    note.NoteTone = Tone.E;
                    break;
                case 6:
                    note.NoteTone = Tone.F;
                    break;
                case 7:
                    note.NoteTone = Tone.G;
                    break;
                default:
                    break;
            }
            if (this.radioButton1.Checked)
            {
                note.NoteDuration = Duration.WHOLE;
            }
            else if (this.radioButton2.Checked)
            {
                note.NoteDuration = Duration.HALF;
            }
            else if (this.radioButton3.Checked)
            {
                note.NoteDuration = Duration.QUARTER;
            }
            else if (this.radioButton4.Checked)
            {
                note.NoteDuration = Duration.EIGHTH;
            }
            else if (this.radioButton5.Checked)
            {
                note.NoteDuration = Duration.SIXTEENTH;
            }
            Play(note);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            PlayMic(2);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            PlayMic(3);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            PlayMic(4);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            PlayMic(5);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            PlayMic(6);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            PlayMic(7);
        }
        private void button1_Click(object sender, EventArgs e)
        {
            PlayMic(1);
        }
    }
}
