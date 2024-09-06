namespace PRODUCTS_API.Models
{
    public class cServer
    {

        public static IConfiguration? _configuration;
        public static IWebHostEnvironment? _hostingEnvironment;
        public static bool IsInitialized { get; private set; }
        public static void Initialize(IWebHostEnvironment hostEnvironment, IConfiguration configuration)
        {
            if (IsInitialized) throw new InvalidOperationException("Object already initialized");
            _configuration = configuration;
            _hostingEnvironment = hostEnvironment;
            IsInitialized = true;
        }

    }
}
