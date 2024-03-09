resource "azurerm_mysql_server" "server" {
  name                         = var.name
  resource_group_name          = var.rg_name
  location                     = var.location
  version                      = "8.0"
  administrator_login          = "sqladmin"
  administrator_login_password = var.admin_password
  sku_name   = "B_Gen5_1"
  storage_mb = 5120
  auto_grow_enabled                 = false
  backup_retention_days             = 7
  geo_redundant_backup_enabled      = false
  infrastructure_encryption_enabled = false
  public_network_access_enabled     = true
  ssl_enforcement_enabled           = true
  ssl_minimal_tls_version_enforced  = "TLS1_2"
}

resource "time_sleep" "wait_2mins" {
  depends_on = [azurerm_mysql_server.server]

  create_duration = "120s"
}

resource "azurerm_mysql_database" "auth-service-db" {
  depends_on = [time_sleep.wait_2mins]
  name                = var.authdb_name
  resource_group_name = var.rg_name
  server_name         = azurerm_mysql_server.server.name
  charset             = "utf8"
  collation           = "utf8_unicode_ci"
}

resource "azurerm_mysql_database" "blog-service-db" {
  depends_on = [time_sleep.wait_2mins]
  name                 = var.blogdb_name
  resource_group_name  = var.rg_name
  server_name          = azurerm_mysql_server.server.name
  charset             = "utf8"
  collation           = "utf8_unicode_ci"
}