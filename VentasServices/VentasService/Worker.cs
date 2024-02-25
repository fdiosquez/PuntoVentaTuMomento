using Microsoft.Extensions.Configuration;

namespace VentasService
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;
        private readonly string _connectionString;
        private Timer _timer;
        private bool FlagFirstTime = true;
        public Worker(ILogger<Worker> logger)
        {
            // Leer el valor del nuevo valor agregado
            IConfiguration configuration = new ConfigurationBuilder()
           .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
           .Build();
            
            _logger = logger;

            General._SYS_UBICACION_DB = configuration["database"];
            General._SUCURSAL = configuration["sucursal"];
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            
                
            while (!stoppingToken.IsCancellationRequested)
            {

                _logger.LogInformation("=====================================================");
                _logger.LogInformation("Ventas Services iniciado : {time}", DateTimeOffset.Now);
                _logger.LogInformation("=====================================================");

                _logger.LogInformation("BD : {dato}", General._SYS_UBICACION_DB);
                _logger.LogInformation("SUCURSAL : {dato}", General._SUCURSAL);

                if (FlagFirstTime)
                {
                    General.Log("---------Ventas Services Conectado!", "INFO");

                    FlagFirstTime=false;
                }
                

                Orquestador.SubirPedidos(_logger);
                Orquestador.BajarProductos(_logger);

                await Task.Delay(TimeSpan.FromMinutes(10), stoppingToken);
            }
        }
    }
}
