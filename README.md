# psu_oracle_backEnd

## install FrameworkCore
1. Microsoft.EntityFrameworkCore
2. Microsoft.EntityFrameworkCore.Relational
3. Microsoft.EntityFrameworkCore.Design
4. Microsoft.EntityFrameworkCore.Tools
5. Oracle.EntityFrameworkCore

Scaffold-DbContext "USER ID=<system>;PASSWORD=< >;DATA SOURCE=<localhost:1521/XE>" Oracle.EntityFrameworkCore -Schemas <SYSTEM> -OutputDir <Models>
