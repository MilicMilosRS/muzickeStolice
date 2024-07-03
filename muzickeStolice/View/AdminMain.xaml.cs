using System.Windows;

namespace muzickeStolice.View
{
    public partial class AdminMain : Window
    {
        public AdminMain()
        {
            InitializeComponent();
        }

        private void CreateDeloButton_Click(object sender, RoutedEventArgs e)
        {
            CreateMuzickoDeloWindow createMuzickoDeloWindow = new CreateMuzickoDeloWindow();
            createMuzickoDeloWindow.ShowDialog();
        }
    }
}
