using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsProjekt
{
    public partial class PlayerControl : UserControl
    {
        public PlayerControl()
        {
            InitializeComponent();
        }
        public override bool Equals(object obj)
        {
            var item = obj as PlayerControl;
            return tbName.Text.Equals(item.tbName.Text);
        }
        public override int GetHashCode() => (tbName.Text + tbPosition.Text).GetHashCode();
    }
}
