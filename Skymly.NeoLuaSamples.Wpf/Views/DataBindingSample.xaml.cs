using System.Windows.Controls;
using System.Windows.Media;

namespace Skymly.NeoLuaSamples.Wpf.Views
{
    /// <summary>
    /// Interaction logic for DataBindingSample
    /// </summary>
    public partial class DataBindingSample : UserControl
    {
        public DataBindingSample()
        { 
            InitializeComponent();
            sliderA.Value = sliderA.Maximum;
        }
    }
}
