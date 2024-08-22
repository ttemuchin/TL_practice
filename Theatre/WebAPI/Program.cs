using Microsoft.EntityFrameworkCore;
using Infrastructure.Foundation;
try
{
    var builder = WebApplication.CreateBuilder( args );

    var connectionString = builder.Configuration.GetConnectionString( "MSSQLSpotlight" );
    builder.Services.AddDbContext<TheatreDbContext>( options =>
    {
        options.UseSqlServer( connectionString, b => b.MigrationsAssembly( typeof( TheatreDbContext ).Assembly.FullName ) );//"Infrastructure.Migrations"
    } );

    //builder.Services.AddApplication().AddInfrastructure();

    builder.Services.AddControllers();
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen();

    WebApplication app = builder.Build();
    if ( app.Environment.IsDevelopment() )
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }

    app.UseAuthorization();

    app.MapControllers();

    app.Run();

}
catch ( Exception ex )
{
    Console.WriteLine( ex.Message );
}
finally
{
    Console.WriteLine( "Close application" );
}