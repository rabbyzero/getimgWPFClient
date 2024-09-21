using RestSharp;
using System.Text;
using System.Text.Json;
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
        GetimgClient directClient = new();
        GetimgClient? proxyClient;
        GetimgClient? restClient;
        public MainWindow()
        {
            InitializeComponent();
        }

        public void getImageButton_Click(object sender, RoutedEventArgs e)
        {
            if (proxyInputBox.Text != "")
            {
                proxyClient = new GetimgClient(proxyInputBox.Text);
                restClient = proxyClient;
            }
            else
            {
                restClient = directClient;
            }
            
            FLUXSchnell model = new();
            TextToImage<FLUXSchnell> method = new(model);
            BodyParams<FLUXSchnell, TextToImage<FLUXSchnell>> parameters = new()
            {
                Width = 256,
                Height = 256,
                Steps = 1,
                Seed = 1,
                Output_format = "jpeg",
                Response_format = "url",
                Prompt = promptInputBox.Text
            };
            RequestBuilder<ImageModel, ModelMethod> request = new(model, method, keyInputBox.Text, parameters);
            parameters.BuildJsonBody(request.request,method);
            
            var response = restClient.client.Post(request.request);
            
            responsePreview.Text = response.Content;
            //{"cost":0.0000393216,"seed":1,"url":"https://api-images-getimg.b74c4cef8e39fc0d1de2c7604852a487.r2.cloudflarestorage.com/org-3dvzUYC7UREJp4GZor7nZ/key-AjnzucfYwIPMjbANBJgb6/req-VAJgAQ7W8rtIDHHnUn1NB.jpeg?X-Amz-Algorithm=AWS4-HMAC-SHA256&X-Amz-Credential=cc8699d8ce09388bb5461b1e1bf500e8%2F20240921%2Fus-east-1%2Fs3%2Faws4_request&X-Amz-Date=20240921T135929Z&X-Amz-Expires=3600&X-Amz-Signature=16924c253f806d44541256123c248ffb665a09eb4b86ec7e2741bbf3990dc9a5&X-Amz-SignedHeaders=host"}

            var imageUrl = new Uri(JsonSerializer.Deserialize<ApiResponse.Success>(response.Content)!.url);
            BitmapImage image = new BitmapImage();
            image.BeginInit();
            image.UriSource = imageUrl;
            image.EndInit();
            mainImage.Source = image;
        }
    }
}