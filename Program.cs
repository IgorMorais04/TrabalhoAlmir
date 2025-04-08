using TrabalhoAlmir.Infraestrutura;
using TrabalhoAlmir.Model;

namespace TrabalhoAlmir {
    public class Program {
        public static void Main(string[] args) {
            var builder = WebApplication.CreateBuilder(args);

            // Adiciona o serviço de CORS
            builder.Services.AddCors(options => {
                options.AddPolicy("PermitirReact", policy => {
                    policy.WithOrigins("http://localhost:3000")
                          .AllowAnyHeader()
                          .AllowAnyMethod();
                });
            });

            // Add services to the container.
            IMvcBuilder mvcBuilder = builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            IServiceCollection serviceCollection = builder.Services.AddTransient<IVeiculosRepository, VeiculosRepository>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment()) {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            // Aplica o CORS antes da autorização
            app.UseCors("PermitirReact");

            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}
