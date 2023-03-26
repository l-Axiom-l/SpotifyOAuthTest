using System.Diagnostics;
using System.Net;
using System.Reflection;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.Json;
using Microsoft.Web.WebView2;
using Microsoft.Web.WebView2.WinForms;

namespace SpotifyOAuthTest
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            Start();
        }
        
        async void Start()
        {
            WebView2 view = new WebView2();
            await view.EnsureCoreWebView2Async();
            while(Form.ActiveForm == null) { await Task.Delay(10); };

            Debug.WriteLine("Test:" + Form.ActiveForm);
            view.Size = Form.ActiveForm.ClientSize;
            Form.ActiveForm.Controls.Add(view);
            view.Show();
            view.CoreWebView2.Navigate("https://accounts.spotify.com/authorize?client_id=7790ce9e6c5a41f3bd39666898ede546&response_type=code&scope=user-modify-playback-state\r\n&redirect_uri=http://localhost:8888/callback");
            HttpListener listener = new HttpListener();
            listener.Prefixes.Add("http://localhost:8888/callback/");
            listener.Start();
            HttpListenerContext context = await listener.GetContextAsync();
            listener.Stop();
            listener.Abort();
            view.Dispose();
            string AuthCode = context.Request.QueryString.Get(0);
            string head = Base64Encode("7790ce9e6c5a41f3bd39666898ede546:4b20a8ae5d0044b8a636c6cee9c75e03");
            StringContent content = new StringContent($"grant_type=authorization_code&code={AuthCode}&redirect_uri=http://localhost:8888/callback", Encoding.UTF8, "application/x-www-form-urlencoded");
            string con;
            using (HttpClient client = new HttpClient())
            {
                client.DefaultRequestHeaders.Add("Authorization", "Basic " + head);
                HttpResponseMessage m = await client.PostAsync("https://accounts.spotify.com/api/token", content);
                con = await m.Content.ReadAsStringAsync();
            };
            string AccessToken = con.Split(',')[0].Split(':')[1].Trim('"').Trim('"');
            //content = new StringContent($"Content-Type=application/json&Authorization: Bearer {AccessToken}", Encoding.UTF8, "application/json");
            using(HttpClient client = new HttpClient())
            {
                client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", AccessToken);
                var test = await client.PutAsync("https://api.spotify.com/v1/me/player/pause", null);
            }
        }

        public string Base64Encode(string plainText)
        {
            var plainTextBytes = System.Text.Encoding.UTF8.GetBytes(plainText);
            return System.Convert.ToBase64String(plainTextBytes);
        }
    }
}