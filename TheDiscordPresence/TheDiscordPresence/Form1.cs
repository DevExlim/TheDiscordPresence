using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DiscordRPC;
using DiscordRPC.Logging;

namespace TheDiscordPresence
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public DiscordRpcClient client;
        bool initalized = false;

        private void button1_Click(object sender, EventArgs e)
        {
            if (initalized == false)
            {
                MessageBox.Show("You need to initialize app first!");
            }
            else
            {
                client.SetPresence(new DiscordRPC.RichPresence()
                {
                    Details = $"{textBox2.Text}",
                    State = $"{textBox1.Text}",
                    Timestamps = Timestamps.Now,
                    Assets = new Assets()
                    {
                        LargeImageKey = $"{textBox4.Text}",
                        LargeImageText = "TheDiscordPresence",
                        SmallImageKey = $"{textBox5.Text}"
                    }
                });
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            initalized = true;
            client = new DiscordRpcClient($"{textBox3.Text}");
            client.Logger = new ConsoleLogger() { Level = LogLevel.Warning };
            client.Initialize();
        }
    }
}
