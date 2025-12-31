#pragma warning disable ENC01
var builder = WebApplication.CreateBuilder(args);
// 添加MVC控制器和视图服务
builder.Services.AddControllersWithViews();

var app = builder.Build(); // 缺失的核心语句

// 环境判断与错误页配置
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

// 第一步：配置默认文件
var defaultFilesOptions = new DefaultFilesOptions();
defaultFilesOptions.DefaultFileNames.Clear();
defaultFilesOptions.DefaultFileNames.Add("index.html");
app.UseDefaultFiles(defaultFilesOptions);

// 第二步：启用静态文件访问
app.UseStaticFiles();

// 后续中间件配置
app.UseRouting();
app.UseAuthorization();

// 配置默认路由（修正语法错误）
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
#pragma warning restore ENC01