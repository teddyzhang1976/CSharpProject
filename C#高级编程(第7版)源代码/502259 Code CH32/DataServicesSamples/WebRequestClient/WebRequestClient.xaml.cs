using System;
using System.IO;
using System.Net;
using System.Text;
using System.Windows;

namespace Wrox.ProCSharp.DataServices
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class WebRequestClientWindow : Window
    {
        public WebRequestClientWindow()
        {
            InitializeComponent();
        }

        private void OnRequest(object sender, RoutedEventArgs e)
        {
            HttpWebRequest request = WebRequest.Create(textUrl.Text) as HttpWebRequest;
            if (checkJSON.IsChecked == true)
            {
                request.Accept = "application/json";
            }
            if (checkPOST.IsChecked == true)
            {
                request.Method = "POST";
                if (checkJSON.IsChecked == true)
                {
                    request.ContentType = "application/json";
                }
                else
                {
                    request.ContentType = "application/atom+xml";
                }
                Stream requestStream = request.GetRequestStream();
                StreamWriter writer = new StreamWriter(requestStream);
                writer.Write(textInput.Text);
               // request.ContentLength = textInput.Text.Length;
                writer.Close();
            }
            request.BeginGetResponse((ar) =>
                {
                    try
                    {
                        using (var ms = new MemoryStream())
                        {
                            const int bufferSize = 1024;
                            byte[] buffer = new byte[bufferSize];
                            HttpWebResponse response = request.EndGetResponse(ar) as HttpWebResponse;

                            Stream responseStream = response.GetResponseStream();
                            int count;
                            while ((count = responseStream.Read(buffer, 0, bufferSize)) > 0)
                            {
                                ms.Write(buffer, 0, count);
                            }
                            responseStream.Close();
                            byte[] dataRead = ms.ToArray();
                            string data = UnicodeEncoding.ASCII.GetString(dataRead, 0, dataRead.Length);
                            Dispatcher.BeginInvoke(new Action<string>(s =>
                                {
                                    textResult.Text = data;
                                }), data);
                        }
                    }
                    catch (WebException ex)
                    {
                        Dispatcher.Invoke(new Action<string>(s =>
                            {
                                textResult.Text = s;
                            }), ex.Message);
                    }

                }, null);
        }
    }
}
