# Migrations update

Step by step to install and use migration tool.

## Installation

To install tool cli dotnet-ef
 C:\Sources\ProjectBase\ProjectBase.Infrastructure> `dotnet tool install --global dotnet-ef`

To update tool cli dotnet-ef
 C:\Sources\ProjectBase\ProjectBase.Infrastructure> `dotnet tool update --global dotnet-ef`

## Usage

To create a migration, run the following command:
C:\Sources\ProjectBase\ProjectBase.Infrastructure> `dotnet ef migrations add [MigrationName] --startup-project ../ProjectBase.Web`

To Create sql file with update:
C:\Sources\ProjectBase\ProjectBase.Infrastructure> `dotnet ef migrations script [previewMigrationMane] -o lastsql.sql --startup-project ../ProjectBase.Web`

To update database :
C:\Sources\ProjectBase\ProjectBase.Infrastructure> `dotnet ef database update --startup-project ../ProjectBase.Web`

To undo last migration :
C:\Sources\ProjectBase\ProjectBase.Infrastructure> `dotnet ef migrations remove --startup-project ../ProjectBase.Web`