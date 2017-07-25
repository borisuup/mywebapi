
namespace MyWebApi.Controllers.Options
{
    public class AboutOptions
    {
        public AboutOptions(){
            HostName = System.Environment.MachineName;
        }
        public string Version { get; set; }
        public string HostName { get; set;}
    }
}