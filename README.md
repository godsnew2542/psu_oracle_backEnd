# psu_oracle_backEnd

## install FrameworkCore not V6

1. Microsoft.EntityFrameworkCore
2. Microsoft.EntityFrameworkCore.Relational
3. Microsoft.EntityFrameworkCore.Design
4. Microsoft.EntityFrameworkCore.Tools
5. Oracle.EntityFrameworkCore

Scaffold-DbContext "USER ID=<system>;PASSWORD=<pass>;DATA SOURCE=<localhost:1521/XE>" Oracle.EntityFrameworkCore -Schemas <SYSTEM> -OutputDir <Models>

## ModelsEntities_1

Scaffold-DbContext "USER ID=<system>;PASSWORD=<pass>;DATA SOURCE=<localhost:1521/XE>" Oracle.EntityFrameworkCore -Schemas <SYSTEM> -OutputDir <ModelsEntities> -f

## ModelsEntities_2

Scaffold-DbContext "USER ID=<system>;PASSWORD=<pass>;DATA SOURCE=<localhost:1521/XE>" Oracle.EntityFrameworkCore -Schemas <SYSTEM> -OutputDir <ModelsEntitiesCentral> -Context ModelContextCentral

# appsettings.json

```json
 "ConnectionStrings": {
    "DefaultConnection": "Data Source=(DESCRIPTION=(ADDRESS=(PROTOCOL=TCP)(HOST=<localhost>)(PORT=1521))(CONNECT_DATA=(SERVICE_NAME=<name>)));User Id=<system>;Password=<pass>;"
  },
```

# Startup.cs

```C#
// ModelsEntities
services.AddDbContext<ModelContext>
    (options => options.UseOracle
        (Configuration.GetConnectionString("DefaultConnection"))
    );

// ModelsEntitiesCentral
services.AddDbContext<ModelContextCentral>
    (options => options.UseOracle
        (Configuration.GetConnectionString("DefaultConnection"))
    );
```

# \_Imports.razor

```C#
@inject ModelContext _context
@inject ModelContextCentral _contextCentral

@inject NavigationManager NavigationManager // Topage
@inject IJSRuntime JS // JS
```

# EX to page

```C#
private void Topage()
{
    NavigationManager.NavigateTo("/page");
}
```

# EX Parameter

```C#
@page "/page/{LoadID:decimal}" // .razor

[Parameter]
public decimal LoadID { get; set; } = 0; // .cs
```

# EX OnInitialized / OnAfterRenderAsync

```C#
protected  override Task OnInitializedAsync(){}
protected override void OnInitialized(){}
protected override async Task OnAfterRenderAsync(bool firstRender)
{
    if (!string.IsNullOrEmpty(StaffID)){
        // ...

        // ข้อมูลมีการเปลี่ยนแปลง บอก ui run ใหม่
        StateHasChanged();
    }
}
```

# EX Add/update/delete

```C#
private async Task function(int RequestID){
    var Request = _context.Requests.Where(c => c.RequestId == RequestID).FirstOrDefault();
    // Add
    _context.Requests.Add(Request);
    // Update
    _context.Update(Request);
    // delete
    _context.Requests.Remove(Request);

    // updata in db
    await _context.SaveChangesAsync();
}
```

# EX \_Host.cshtml

```html
<!-- css -->
<!-- bootstrap v.5 -->
<link rel="stylesheet" href="~/css/bootstrap/bootstrap.min.css" />

<!-- icon fontawesome -->
<link
  rel="stylesheet"
  href="https://pro.fontawesome.com/releases/v5.10.0/css/all.css"
  integrity="sha384-AYmEC3Yw5cVb3ZcuHtOA93w35dYTsvhLPVnYs9eStHfGJvOvKxVfELGroGkvsg+p"
  crossorigin="anonymous"
/>
<link rel="stylesheet" href="~/css/icon/fontawesome.css" />

<!-- Add the base CSS plus Solid + Brands styles **after previous versions** -->
<link href="~/css/icon/fontawesomeV6/fontawesome.css" rel="stylesheet" />
<link href="~/css/icon/fontawesomeV6/brands.css" rel="stylesheet" />
<link href="~/css/icon/fontawesomeV6/solid.css" rel="stylesheet" />

<!-- js -->
<!-- jquery -->
<script src="~/js/jquery.min.js"></script>
<script
  type="text/javascript"
  src="https://code.jquery.com/jquery-1.12.0.min.js"
></script>

<!-- bootstrap -->
<script src="~/js/bootstrap.min.js"></script>

<!-- icon -->
<script defer src="~/js/icon/all.js"></script>
```
