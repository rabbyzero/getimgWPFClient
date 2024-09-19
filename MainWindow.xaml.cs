using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace getimgWPFClient
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        GetimgClient restClient = new();
        public MainWindow()
        {
            InitializeComponent();

        }

        public void getImage_Click(object sender, RoutedEventArgs e)
        {
            FLUXSchnell model = new();
            TextToImage<FLUXSchnell> method = new(model);
            BodyParams<FLUXSchnell, TextToImage<FLUXSchnell>> parameters = new();
            parameters.Width = 256;
            parameters.Height = 256;
            parameters.Steps = 1;
            parameters.Seed = 1;
            parameters.Output_format = "jpeg";
            parameters.Response_format = "url";
            parameters.Prompt = promptInputBox.Text;
            RequestBuilder<ImageModel, ModelMethod> request = new(model, method, "key-1234567890 ", parameters);
            parameters.BuildJsonBody(request.request,method);

        }
    }
}