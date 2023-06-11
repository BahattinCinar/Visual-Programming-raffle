using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using System.Collections;

namespace Final_Odev
{
    public partial class Form1 : Form
    {
        ArrayList aL = new ArrayList();
        
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string exit, usernames;
            
            try
            {
                exit = Interaction.InputBox("Cikmak icin hangi butonu kullanmak istiyorsunuz", "Cikis butonu secme ekrani", "x", 125, 125);

                for (int i = 0; ; )
                {
                    usernames = Interaction.InputBox("Cekilise katilicak insanlarin isimlerini giriniz ", "Cekilis giris ekrani", "", 125, 125);
                    
                    if (usernames == exit)
                    {
                        break;
                    }
                    else
                    {
                        i++;
                        aL.Add(usernames);
                        listBox1.Items.Add($"{i}.Katilimci :{usernames}");
                    }
                }

            }
            catch (OverflowException error1)
            {
                MessageBox.Show($"Lutfen limitler dahilinde giriniz. {error1}");
            }
            catch (FormatException error2)
            {
                MessageBox.Show($"Lutfen giris turunuzu dogru giriniz. {error2}");
            }
            catch (Exception error3)
            {
                MessageBox.Show($"Bilinmeyen hatayla karsilastiniz. {error3}");
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            listBox2.Visible = false;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                int winnum, wincount, a = 1;
                Random rnd = new Random();

                wincount = int.Parse(Interaction.InputBox("Cekilisi kac kisi kazanicak ?", "Cekilis kazanan sayisi", "3", 125, 125));

                string[] winners = new string[wincount];

                for (int i = 0; i <= wincount - 1; i++)
                {
                    winnum = rnd.Next(0, aL.Count);
                    winners[i] = aL[winnum].ToString();
                    aL.RemoveAt(winnum);
                    listBox2.Items.Add(a + ". Kazanan : " + aL[i]);
                    a++;
                }
            }
            catch(OverflowException error1)
            {
                MessageBox.Show($"Lutfen limitler dahilinde giriniz. {error1}");
            }
            catch(FormatException error2)
            {
                MessageBox.Show($"Lutfen giris turunuzu dogru giriniz. {error2}");
            }
            catch (Exception error3)
            {
                MessageBox.Show($"Bilinmeyen hatayla karsilastiniz. {error3}");
            }
            finally
            {
                MessageBox.Show("Cekilisiniz Sona Ermistir.");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            listBox2.Visible = true;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                string selected = listBox1.SelectedItem.ToString();
                listBox1.Items.Remove(listBox1.SelectedItem);
                aL.Remove(selected);
            }
            catch (OverflowException error1)
            {
                MessageBox.Show($"Lutfen limitler dahilinde giriniz. {error1}");
            }
            catch (FormatException error2)
            {
                MessageBox.Show($"Lutfen giris turunuzu dogru giriniz. {error2}");
            }
            catch (Exception error3)
            {
                MessageBox.Show($"Bilinmeyen hatayla karsilastiniz. {error3}");
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            listBox2.Items.Clear();
            aL.Clear();
            listBox2.Visible = false;
        }
    }
}
