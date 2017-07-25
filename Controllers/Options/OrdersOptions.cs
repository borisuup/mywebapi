
namespace MyWebApi.Controllers.Options
{
    public class OrdersOptions
    {
        public OrdersOptions(){
            ConnectionString = "mongodb://localhost:27017";
        }
        public string ConnectionString { get; set; }

        public override string ToString()
        {
            return string.Format("ConnectionString: {0}", ConnectionString);
        }
    }
}