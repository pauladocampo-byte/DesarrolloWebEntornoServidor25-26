var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

// ==================== Rutas Friends (Area + original) ====================

// Punto 5: /Friends/View/{name} debe ir al controlador del área "Special"
app.MapAreaControllerRoute(
    name: "friends_view_special",
    areaName: "Special",
    pattern: "Friends/View/{name}",
    defaults: new { controller = "Friends", action = "View" }
);

// Rutas FriendsController original
app.MapControllerRoute(
    name: "friends_root",
    pattern: "Friends",
    defaults: new { controller = "Friends", action = "Index" }
);

app.MapControllerRoute(
    name: "friends_view_original",
    pattern: "Friends/ViewOriginal/{name}",
    defaults: new { controller = "Friends", action = "View" }
);

app.MapControllerRoute(
    name: "friends_edit",
    pattern: "Friends/Edit/{id:int}",
    defaults: new { controller = "Friends", action = "Edit" }
);

// ==================== Rutas Products ====================

// /Products/All -> Products.Index
app.MapControllerRoute(
    name: "products_all",
    pattern: "Products/All",
    defaults: new { controller = "Products", action = "Index" }
);

// /Products/Sony-Vaio -> Products.View("Sony-Vaio")
app.MapControllerRoute(
    name: "products_view",
    pattern: "Products/{id}",
    defaults: new { controller = "Products", action = "View" }
);

// /Products/Category/Ultrabooks -> Products.ByCategory("Ultrabooks")
app.MapControllerRoute(
    name: "products_category",
    pattern: "Products/Category/{category}",
    defaults: new { controller = "Products", action = "ByCategory" }
);

// ==================== Ruta por defecto ====================
// "/" -> Products/Index (equivalente a /Products/All en esta práctica)
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Products}/{action=Index}/{id:int?}"
);

app.Run();
