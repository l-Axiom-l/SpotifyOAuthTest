using Microsoft.Web.WebView2.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SpotifyOAuthTest
{
    public partial class Browser : Form
    {
        public Browser()
        {
            InitializeComponent();
            Start();
        }

        async void Start()
        {
            WebView2 view = new WebView2();
            FormClosed += (x,y) => view.Dispose();
            await view.EnsureCoreWebView2Async();
            while (Form.ActiveForm == null) { await Task.Delay(10); };

            Debug.WriteLine("Test:" + Form.ActiveForm);
            view.Size = Form.ActiveForm.ClientSize;
            Form.ActiveForm.Controls.Add(view);
            view.Show();
            view.CoreWebView2.Navigate("https://accounts.spotify.com/authorize?client_id=7790ce9e6c5a41f3bd39666898ede546&response_type=code&scope=user-modify-playback-state user-read-currently-playing&redirect_uri=http://localhost:8888/callback");
        }
    }
}
