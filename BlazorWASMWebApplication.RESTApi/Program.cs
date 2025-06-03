using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<ContactsDataBaseContext>(optionsBuilder => optionsBuilder.UseNpgsql(
                    builder.Configuration.GetConnectionString("ContactsDataBaseConection"),
                                options => options.EnableRetryOnFailure(
                                    maxRetryCount: 3,
                                    maxRetryDelay: TimeSpan.FromMilliseconds(100),
                                    errorCodesToAdd: null))
                            .UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking),
                        ServiceLifetime.Transient);


builder.Services.AddControllers();

var app = builder.Build();

//app.UseHttpsRedirection();
//app.UseAuthorization();
app.UseCors(x => x
    .AllowAnyMethod()
    .AllowAnyHeader()
    .SetIsOriginAllowed(origin => true) // allow any origin  
    .AllowCredentials());               // allow credentials 
//app.UseCors("Open");
app.MapControllers();

app.Run();
