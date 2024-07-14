resource "azurerm_mysql_flexible_server" "server" {
  name                              = var.name
  resource_group_name               = var.rg_name
  location                          = var.location
  version                           = "8.0.21"
  administrator_login               = "sqladmin"
  administrator_password            = var.admin_password
  backup_retention_days             = 7
  geo_redundant_backup_enabled      = false
  sku_name                          = "GP_Standard_D2ds_v4"
}

resource "time_sleep" "wait_2mins" {
  depends_on = [azurerm_mysql_flexible_server.server]

  create_duration = "120s"
}

resource "azurerm_mysql_flexible_database" "auth-service-db" {
  depends_on          = [time_sleep.wait_2mins]
  name                = var.authdb_name
  resource_group_name = var.rg_name
  server_name         = azurerm_mysql_flexible_server.server.name
  charset             = "utf8"
  collation           = "utf8_unicode_ci"
}

resource "azurerm_mysql_flexible_database" "blog-service-db" {
  depends_on           = [time_sleep.wait_2mins]
  name                 = var.blogdb_name
  resource_group_name  = var.rg_name
  server_name          = azurerm_mysql_flexible_server.server.name
  charset              = "utf8"
  collation            = "utf8_unicode_ci"
}