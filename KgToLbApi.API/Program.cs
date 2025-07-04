var builder = WebApplication.CreateBuilder(args);

// 👉 Servicios principales
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// 👉 Política de CORS para desarrollo
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
    {
        policy.AllowAnyOrigin()
              .AllowAnyMethod()
              .AllowAnyHeader();
    });
});

var app = builder.Build();

// 👉 Usa CORS antes de Routing
app.UseCors("AllowAll");

// 👉 Swagger siempre activo en dev (o siempre mientras pruebas)
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "KgToLbApi v1");
        // c.RoutePrefix = string.Empty; // Si quieres que Swagger sea en la raíz: https://localhost:7023/
    });
}

// 👉 Forzar HTTPS
app.UseHttpsRedirection();

// 👉 Seguridad
app.UseAuthorization();

// 👉 Mapea controladores
app.MapControllers();

// 👉 Ejecuta
app.Run();
