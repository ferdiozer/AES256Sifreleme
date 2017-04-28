using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace aesSifreleme
{
    public partial class AesForm : Form
    {
        public AesForm()
        {
            InitializeComponent();
        }
        AESsifreleme aes = new AESsifreleme();
        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnSifrele_Click(object sender, EventArgs e)
        {
            if (rtbMetin.Text == string.Empty)
            {
                MessageBox.Show("Çözümlenecek veri bulunamadı!");
            }
            else
            {
                rtbSifreli.Text = aes.AESsifrele(rtbMetin.Text);
            }

            
        }

        private void btnSifreCoz_Click(object sender, EventArgs e)
        {
            if (rtbSifreli.Text == string.Empty)
            {
                MessageBox.Show("Çözülecek bir şifre bulunamadı!");
            }
            else
            {
                rtbCozulmus.Text = aes.AESsifre_Coz(rtbSifreli.Text);
            }

        }
    }
}
