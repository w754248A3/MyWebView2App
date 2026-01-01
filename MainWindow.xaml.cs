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
using Microsoft.Web.WebView2.Core;

namespace MyWebView2App;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
        this.Topmost = true;
        InitWebView2();
    }


    async void InitWebView2(){


        string GetUserDataPath(){


            var s = AppDomain.CurrentDomain.BaseDirectory;


            return System.IO.Path.Combine(s, "MyWebView2App.exe.WebView2");
        }

        var info = new CoreWebView2EnvironmentOptions();

        var s = GetUserDataPath();

        var environment = await CoreWebView2Environment.CreateAsync(userDataFolder:s, options: info);



        await webView2.EnsureCoreWebView2Async(environment);
        webView2.CoreWebView2.SetVirtualHostNameToFolderMapping("mypage.test", 
         @"C:\Users\PC\code\MyWebView2App\dist", CoreWebView2HostResourceAccessKind.DenyCors);
        webView2.CoreWebView2.Navigate("https://mypage.test/index.html");

       
    }
}