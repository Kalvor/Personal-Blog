resource "azurerm_mssql_server" "server" {
  name                         = var.name
  resource_group_name          = var.rg_name
  location                     = var.location
  version                      = "12.0"
  administrator_login          = "personalblog_admin"
  administrator_login_password = var.admin_password
}

resource "azurerm_mysql_database" "auth-service-db" {
  depends_on = [azurerm_mssql_server.server]
  name                = var.authdb_name
  resource_group_name = var.rg_name
  server_name         = azurerm_mssql_server.server.name
  charset             = "utf8"
  collation           = "utf8_unicode_ci"

  lifecycle {
    prevent_destroy = true
  }
}

resource "azurerm_mysql_database" "blog-service-db" {
  depends_on = [azurerm_mssql_server.server]
  name                 = var.blogdb_name
  resource_group_name  = var.rg_name
  server_name          = azurerm_mssql_server.server.name
  charset             = "utf8"
  collation           = "utf8_unicode_ci"
  lifecycle {
    prevent_destroy = true
  }
}