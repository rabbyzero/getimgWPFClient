﻿using RestSharp;
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
using System.IO;


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
            
            var response_format = response_formatComboBox.Text;

            FLUXSchnell model = new();
            TextToImage<FLUXSchnell> method = new(model);
            BodyParams<FLUXSchnell, TextToImage<FLUXSchnell>> parameters = new()
            {
                width = int.Parse(widthInputBox.Text),
                height = int.Parse(heightInputBox.Text),
                steps = int.Parse(stepsInputBox.Text),
                seed = int.Parse(seedInputBox.Text),
                output_format = output_formatComboBox.Text,
                response_format = response_format,

                prompt = promptInputBox.Text
            };
            RequestBuilder<ImageModel, ModelMethod> request = new(model, method, keyInputBox.Text, parameters);
            parameters.BuildJsonBody(request.request,method);
            
            var response = restClient.client.Post(request.request);
            
            responsePreview.Text = response.Content;


            Uri imageUrl = null;
            if (response_format == "url")
            {
                imageUrlTextBox.Text = JsonSerializer.Deserialize<ApiResponse.Success>(response.Content)!.url;
                imageUrl = new Uri(imageUrlTextBox.Text);
            }
            BitmapImage image = new BitmapImage();
            image.BeginInit();
            if (response_format == "url")
            {
                image.UriSource = imageUrl;
            }
            else
            {
                byte[] binaryData = Convert.FromBase64String(JsonSerializer.Deserialize<ApiResponse.Success>(response.Content)!.image);
                image.StreamSource = new MemoryStream(binaryData);
            }
            image.UriSource = imageUrl;
            image.EndInit();
            mainImage.Source = image;
        }

        private void responsePreview_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}